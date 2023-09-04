using Application.Feature.UserFeatures.Auths.Dtos;
using Application.Feature.UserFeatures.Auths.Rules;
using Application.Service.AuthService;
using AutoMapper;
using Core.Application.Transaction;
using Core.Security.Entities;
using MediatR; 
namespace Application.Feature.UserFeatures.Auths.Commands.RevokeToken;

public class RevokeTokenCommand : IRequest<RevokedTokenDto>, ITransactionalRequest
{
    public string Token { get; set; }
    public string IPAddress { get; set; }
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokedTokenDto>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        public RevokeTokenCommandHandler(IAuthService authService, IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _authService = authService;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RevokedTokenDto> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.Token);

            await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
            await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

            await _authService.RevokeRefreshToken(refreshToken, request.IPAddress);

            RevokedTokenDto revokedTokenDto = _mapper.Map<RevokedTokenDto>(refreshToken);
            return revokedTokenDto;
        }
    }
}
