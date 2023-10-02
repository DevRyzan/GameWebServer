using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using AutoMapper;
using Core.Application.Caching;
using Core.Application.Generator;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants.OperationClaim;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Create;

public class CreatePossibleRequestAndTagCommand : IRequest<CreatedPossibleRequestAndTagDto>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }

    public string[] Roles => new[] { Admin, PossibleRequestAndTagAdd };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string? CacheKey { get; }
    public string? CacheGroupKey => "GetPossibleRequestAndTags";

    public class CreatePossibleRequestAndTagCommandHandler : IRequestHandler<CreatePossibleRequestAndTagCommand, CreatedPossibleRequestAndTagDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly ITagService _tagService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestAndTagBusinessRules _possibleRequestBusinessRules;

        public CreatePossibleRequestAndTagCommandHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<CreatedPossibleRequestAndTagDto> Handle(CreatePossibleRequestAndTagCommand request, CancellationToken cancellationToken)
        {
            await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(request.PossibleRequestId);

            await _possibleRequestBusinessRules.TagIdShouldBeExist(request.TagId);


            PossibleRequestAndTag mappedPossibleRequestAndTag = _mapper.Map<PossibleRequestAndTag>(request);

            mappedPossibleRequestAndTag.Code = UIDGenerator.GenerateUID(modelName: "PossibleRequestAndTag");
            mappedPossibleRequestAndTag.Status = true;
            mappedPossibleRequestAndTag.CreatedDate = DateTime.Now;

            PossibleRequestAndTag createdPossibleRequestAndTag = await _possibleRequestAndTagService.Create(mappedPossibleRequestAndTag);


            CreatedPossibleRequestAndTagDto createdPossibleRequestAndTagDto = _mapper.Map<CreatedPossibleRequestAndTagDto>(createdPossibleRequestAndTag);


            createdPossibleRequestAndTagDto.CreatedDate = DateTime.UtcNow;
            createdPossibleRequestAndTagDto.PossibleRequestId = request.PossibleRequestId;
            createdPossibleRequestAndTagDto.TagId = request.TagId;
            createdPossibleRequestAndTagDto.Status = true;

            return createdPossibleRequestAndTagDto;



        }
    }
}
