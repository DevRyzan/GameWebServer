using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using AutoMapper;
using Core.Application.Caching;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequests.Constants.OperationClaim;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Create;

public class CreatePossibleRequestCommand : IRequest<CreatedPossibleRequestDto>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public string RequestName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public bool Status { get; set; }
    public string[] Roles => new[] { Admin, PossibleRequestAdd };


    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequests";

    public class CreatePossibleRequestCommandHandler : IRequestHandler<CreatePossibleRequestCommand, CreatedPossibleRequestDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

        public CreatePossibleRequestCommandHandler(IPossibleRequestService possibleRequestService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<CreatedPossibleRequestDto> Handle(CreatePossibleRequestCommand request, CancellationToken cancellationToken)
        {

            await _possibleRequestBusinessRules.PossibleRequestNameShouldNotBeExist(request.RequestName);

            PossibleRequest mappedPossibleRequest = _mapper.Map<PossibleRequest>(request);

            mappedPossibleRequest.Code = UIDGenerator.GenerateUID(modelName: "PossibleRequest");
            mappedPossibleRequest.Status = true;
            mappedPossibleRequest.CreatedDate = DateTime.Now;

            PossibleRequest createdPossibleRequest = await _possibleRequestService.Create(mappedPossibleRequest);

            CreatedPossibleRequestDto createdPossibleRequestDto = _mapper.Map<CreatedPossibleRequestDto>(createdPossibleRequest);

            return createdPossibleRequestDto;

        }
    }
}
