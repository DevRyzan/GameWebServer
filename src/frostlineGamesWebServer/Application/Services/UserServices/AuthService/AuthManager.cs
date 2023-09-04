using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Emailling.EmailServices;
using Core.Emailling.MailToEmail;
using Core.Emailling.Models;
using Core.Security.EmailAuthenticator;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Application.Service.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly TokenOptions _tokenOptions;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
        private readonly IEmailService _emailService;
        private readonly IMailService _mailService;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, IEmailAuthenticatorRepository emailAuthenticatorRepository, IEmailAuthenticatorHelper emailAuthenticatorHelper, IConfiguration configuration, IEmailService emailService, IMailService mailService)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _emailAuthenticatorHelper = emailAuthenticatorHelper; 
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _emailService = emailService;
            _mailService = mailService;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IList<OperationClaim> operationClaims =
                await _userOperationClaimRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.UserId == user.Id)
                .Select(p => new OperationClaim
                {
                    Id = p.OperationClaimId,
                    Name = p.OperationClaim.Name
                })
                .ToListAsync();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task DeleteOldRefreshTokens(Guid userId)
        {
            ICollection<RefreshToken> refreshTokens = await _refreshTokenRepository
                .Query()
                .AsNoTracking()
                .Where(r => r
                .UserId == userId && r
                .Revoked == null && r
                .Expires >= DateTime.UtcNow && r
                .CreatedDate.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow)
                .ToListAsync();

            await _refreshTokenRepository.DeleteRangeAsync(refreshTokens);
        }

        public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(r => r.Token == token);
            return refreshToken;
        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null)
        {
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReasonRevoked = reason;
            refreshToken.ReplacedByToken = replacedByToken;
            await _refreshTokenRepository.UpdateAsync(refreshToken);
        }

        public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            await RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
        {
            RefreshToken childToken = await _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken);

            if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
                await RevokeRefreshToken(childToken, ipAddress, reason);
            else await RevokeDescendantRefreshTokens(childToken, ipAddress, reason);
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            EmailAuthenticator emailAuthenticator = new()
            {
                UserId = user.Id,
                ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };
            return emailAuthenticator;
        }

        public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email)
                await verifyAuthenticatorCodeWithEmail(user, authenticatorCode);
            //else if (user.AuthenticatorType is AuthenticatorType.Otp)
            //    await verifyAuthenticatorCodeWithOtp(user, authenticatorCode);
        }

        private async Task verifyAuthenticatorCodeWithEmail(User user, string authenticatorCode)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);
            if (emailAuthenticator.ActivationKey != authenticatorCode)
                throw new BusinessException("Authenticator code is invalid.");

            emailAuthenticator.ActivationKey = null;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
        }

        //private async Task verifyAuthenticatorCodeWithOtp(User user, string authenticatorCode)
        //{
        //    OtpAuthenticator otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

        //    bool result = await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);

        //    if (!result)
        //        throw new BusinessException("Authenticator code is invalid.");
        //}
        public async Task SendAuthenticatorCode(User user)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email) await sendAuthenticatorCodeWithEmail(user);
        }
        private async Task<Unit> sendAuthenticatorCodeWithEmail(User user)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

            string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();

            emailAuthenticator.ActivationKey = authenticatorCode;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            _emailService.SendEmail(new Email
            {
                To = user.Email,
                Subject = "FrostlinmeGamesLogin",
                Body = $"Enter your authenticator code: {authenticatorCode}"
            });
            return Unit.Value;
        }
        public async Task SendAuthenticatorCodeForPasswordChange(User user)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email) await sendAuthenticatorCodeForPasswordChangeWithEmail(user);
        }
        private async Task<Unit> sendAuthenticatorCodeForPasswordChangeWithEmail(User user)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();

            if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

            emailAuthenticator.ActivationKey = authenticatorCode;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            _mailService.SendAuthCodePasswordWillChangeMail(email: user.Email, authCode: authenticatorCode);

            return Unit.Value;
        }
        public async Task SendPasswordChangedMailToEmail(User user)
        {
            if (user.AuthenticatorType is AuthenticatorType.Email) await sendPasswordChangedMailWithEmail(user);
        }


        public async Task SendLinkForForgotPasswordToEmail(User? user)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

            _mailService.SendLinkForForgotPasswordToEMail(user.Email);

        }











        private async Task<Unit> sendPasswordChangedMailWithEmail(User user)
        {
            EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

            if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

            _mailService.SendPasswordChangedMail(user.Email);


            return Unit.Value;
        }
    }
}

