using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Service.AuthService;

public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(User user);
    Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    Task<RefreshToken?> GetRefreshTokenByToken(string token);
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    Task DeleteOldRefreshTokens(Guid userId);
    Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);

    Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null,
                            string? replacedByToken = null);
    Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string dress);
    Task<EmailAuthenticator> CreateEmailAuthenticator(User user);
   // Task<OtpAuthenticator> CreateOtpAuthenticator(User user);
   // Task<string> ConvertSecretKeyToString(byte[] secretKey);
    Task VerifyAuthenticatorCode(User user, string authenticatorCode);
    Task SendAuthenticatorCode(User user);
    Task SendAuthenticatorCodeForPasswordChange(User user);
    Task SendPasswordChangedMailToEmail(User user);
    Task SendLinkForForgotPasswordToEmail(User? user);
}
