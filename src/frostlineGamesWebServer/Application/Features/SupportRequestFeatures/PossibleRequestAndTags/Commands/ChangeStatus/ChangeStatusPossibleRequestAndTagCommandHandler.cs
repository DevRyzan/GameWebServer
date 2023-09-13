using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.ChangeStatus;

public class ChangeStatusPossibleRequestAndTagCommandHandler : IRequestHandler<ChangeStatusPossibleRequestAndTagCommandRequest, ChangeStatusPossibleRequestAndTagCommandResponse>
{
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

    public ChangeStatusPossibleRequestAndTagCommandHandler(IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
    {
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
    }

    public async Task<ChangeStatusPossibleRequestAndTagCommandResponse> Handle(ChangeStatusPossibleRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagIdShouldBeExist(request.Id);
        PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetById(request.Id);

        possibleRequestAndTag.Status = possibleRequestAndTag.Status == true ? false : true;
        possibleRequestAndTag.UpdatedDate = DateTime.Now;

        PossibleRequestAndTag changeStatusPossibleRequestAndTag = await _possibleRequestAndTagService.Update(possibleRequestAndTag);

        ChangeStatusPossibleRequestAndTagCommandResponse mappedResponse = _mapper.Map<ChangeStatusPossibleRequestAndTagCommandResponse>(changeStatusPossibleRequestAndTag);
        return mappedResponse;

    }
}
