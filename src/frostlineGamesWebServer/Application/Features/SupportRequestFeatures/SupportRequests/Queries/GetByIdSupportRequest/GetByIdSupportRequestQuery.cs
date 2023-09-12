using Application.Features.SupportRequestFeatures.SupportRequests.Rules;
using Application.Service.UserDetailService;
using Application.Services.SupportRequestServices.SupportRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetByIdSupportRequest;

public class GetByIdSupportRequestQuery : IRequestHandler<GetByIdSupportRequestRequest, GetByIdSupportRequestResponse>
{
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestBusinessRules _supportRequestBusinessRules;
    private readonly IUserDetailService _userDetailService;

    public GetByIdSupportRequestQuery(ISupportRequestService supportRequestService, IMapper mapper, SupportRequestBusinessRules supportRequestBusinessRules, IUserDetailService userDetailService)
    {
        _supportRequestService = supportRequestService;
        _mapper = mapper;
        _supportRequestBusinessRules = supportRequestBusinessRules;
        _userDetailService = userDetailService;
    }

    public async Task<GetByIdSupportRequestResponse> Handle(GetByIdSupportRequestRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestBusinessRules.SupportRequestShouldBeExist(request.GetByIdSupportRequestDto.Id);
        SupportRequest supportRequest = await _supportRequestService.GetById(request.GetByIdSupportRequestDto.Id);

        var userDetail = await _userDetailService.GetById(supportRequest.UserDetailId);

        GetByIdSupportRequestResponse supportRequestDto = _mapper.Map<GetByIdSupportRequestResponse>(supportRequest);
        supportRequestDto.UserId = (Guid)userDetail.UserId;
        return supportRequestDto;
    }
}
