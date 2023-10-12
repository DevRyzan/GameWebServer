using Application.Feature.UserFeatures.Users.Rules;
using Application.Service.EmailAuthenticatorService;
using Core.Persistence.Paging;
using Core.Security.Entities;
using AutoMapper;
using MediatR;
using Application.Services.UserServices.UserService;

namespace Application.Feature.UserFeatures.Users.Queries.GetListUserByVerify;

public class GetListUserByVerifyQueryHandler : IRequestHandler<GetListUserByVerifyQueryRequest, GetListResponse<GetListUserByVerifyQueryResponse>>
{
    private readonly IUserService? _userService;
    private readonly IEmailAuthenticatorService _emailAuthenticatorService;
    private readonly IMapper? _mapper;
    private readonly UserBusinessRules? _userBusinessRules;

    public GetListUserByVerifyQueryHandler(IUserService? userService, IEmailAuthenticatorService emailAuthenticatorService, IMapper? mapper, UserBusinessRules? userBusinessRules)
    {
        _userService = userService;
        _emailAuthenticatorService = emailAuthenticatorService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<GetListResponse<GetListUserByVerifyQueryResponse>> Handle(GetListUserByVerifyQueryRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserListShouldBeListedWhenSelected(request.PageRequest.Page, request.PageRequest.PageSize);

        IPaginate<EmailAuthenticator> result = await _emailAuthenticatorService.GetListByVerified(request.IsVerified, index:request.PageRequest.Page, size: request.PageRequest.PageSize);


        GetListResponse<GetListUserByVerifyQueryResponse> mappedResponse = _mapper.Map<GetListResponse<GetListUserByVerifyQueryResponse>>(result);

        foreach(var item in mappedResponse.Items)
        {
            var user = await _userService.GetById(item.UserId);
            await _userBusinessRules.UserIdShouldExistWhenSelected(user.Id);

            item.Email = user.Email;
            item.FirstName = user.FirstName;
            item.LastName = user.LastName;
            item.Status = user.Status;

            item.CreatedDate = user.CreatedDate;
            item.UpdatedDate = user.UpdatedDate;
            item.DeletedDate = user.DeletedDate;

        }
        TimeSpan.FromSeconds(10);
        return mappedResponse;
    }
}
