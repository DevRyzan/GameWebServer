using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.EmailAuthenticatorService;
using AutoMapper;
using MediatR;

namespace Application.Feature.UserFeatures.Users.Queries.GetByIsVerifiedUser;

public class GetByIsVerifiedUserQueryHandler : IRequestHandler<GetByIsVerifiedUserQueryRequest, GetByIsVerifiedUserQueryResponse>
{
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public GetByIsVerifiedUserQueryHandler(IEmailAuthenticatorService emailAuthenticatorService, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _emailAuthenticatorService = emailAuthenticatorService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<GetByIsVerifiedUserQueryResponse> Handle(GetByIsVerifiedUserQueryRequest request, CancellationToken cancellationToken)
    {

        await _userBusinessRules.UserIdShouldBeEmailAtAuthenticator(request.UserId);
        bool isVerified = await _emailAuthenticatorService.IsVerified(request.UserId);

        return new() { IsVerified = isVerified };
    }
}
