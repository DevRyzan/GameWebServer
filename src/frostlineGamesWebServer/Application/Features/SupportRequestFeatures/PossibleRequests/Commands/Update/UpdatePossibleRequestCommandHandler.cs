using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;


public class UpdatePossibleRequestCommandHandler : IRequestHandler<UpdatePossibleRequestCommandRequest, UpdatedPossibleRequestCommandResponse>
{
    private readonly IPossibleRequestService _possibleRequestService;
    private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
    private readonly IMapper _mapper;
    private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

    public UpdatePossibleRequestCommandHandler(IPossibleRequestService possibleRequestService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
    {
        _possibleRequestService = possibleRequestService;
        _possibleRequestAndTagService = possibleRequestAndTagService;
        _mapper = mapper;
        _possibleRequestBusinessRules = possibleRequestBusinessRules;
    }

    public async Task<UpdatedPossibleRequestCommandResponse> Handle(UpdatePossibleRequestCommandRequest request, CancellationToken cancellationToken)
    {
        await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.UpdatedPossibleRequestDto.Id);
        await _possibleRequestBusinessRules.PossibleRequestNameShouldNotBeExistWithId(request.UpdatedPossibleRequestDto.RequestName, request.UpdatedPossibleRequestDto.Id);

        PossibleRequest possibleRequest = await _possibleRequestService.GetById(request.UpdatedPossibleRequestDto.Id);

        possibleRequest.RequestName = request.UpdatedPossibleRequestDto.RequestName;
        possibleRequest.Title = request.UpdatedPossibleRequestDto.Title;
        possibleRequest.Comment = request.UpdatedPossibleRequestDto.Comment;
        possibleRequest.SupportRequestCategoryId = request.UpdatedPossibleRequestDto.SupportRequestCategoryId;
        possibleRequest.Status = request.UpdatedPossibleRequestDto.Status;

        PossibleRequest updatedPossibleRequest = await _possibleRequestService.Update(possibleRequest);


        UpdatedPossibleRequestCommandResponse response = _mapper.Map<UpdatedPossibleRequestCommandResponse>(updatedPossibleRequest);
        return response;

    }
}