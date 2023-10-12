using Application.Feature.UserFeatures.Auths.Dtos;
using Application.Feature.UserFeatures.Auths.Rules;
using Application.Service.AuthService;
using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Application.Services.UserServices.UserDetailService;
using AutoMapper;
using Core.Application.Generator;
using Core.Application.Transaction;
using Core.Emailling.MailToEmail;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities.Users;
using MediatR;

namespace Application.Feature.UserFeatures.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>, ITransactionalRequest
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string? RegisteredIP { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authservice;
        private readonly IUserDetailService _userDetailService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authservice, IUserDetailService userDetailService, AuthBusinessRules authBusinessRules, IMapper mapper, IMailService mailService, IEmailAuthenticatorRepository emailAuthenticatorRepository)
        {
            _userRepository = userRepository;
            _authservice = authservice;
            _userDetailService = userDetailService;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
            _mailService = mailService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
            //await _authBusinessRules.UserNickNameShouldBeNotExists(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
            //User newUser= _mapper.Map<User>(request);
            User newUser = new()
            {
                Id= Guid.NewGuid(),
                Email = request.UserForRegisterDto.Email,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisterType = RegisterType.RegisterLogin,
                Code = UIDGenerator.GenerateUID(modelName: "User"),
                Status = true
            }; 

            User createdUser = await _userRepository.AddAsync(newUser);

                                               
            UserDetail newUserDetail = new()
            {
                UserId = newUser.Id,
                Code = newUser.Code,
                IsBanned = false,
                Status = true
            };
            await _userDetailService.Create(newUserDetail);
            createdUser.Status = false; 

            AccessToken createdAccessToken = await _authservice.CreateAccessToken(createdUser);

            RefreshToken createdRefreshToken = await _authservice.CreateRefreshToken(createdUser, request.RegisteredIP);

            RefreshToken addedRefreshToken = await _authservice.AddRefreshToken(createdRefreshToken);
            
            RegisteredDto registeredDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken
            };

            _mailService.SendMailForRegisterUser(createdUser.Email);
            return registeredDto;
        }
    }
}
