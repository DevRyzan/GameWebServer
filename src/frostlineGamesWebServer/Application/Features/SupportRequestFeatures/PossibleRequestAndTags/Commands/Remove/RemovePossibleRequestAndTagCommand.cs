using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants.OperationClaim;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Remove;

public class RemovePossibleRequestAndTagCommand : IRequest<RemovedPossibleRequestAndTagDto>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, PossibleRequestAndTagRemove };

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string? CacheKey { get; }
    public string? CacheGroupKey => "GetPossibleRequestAndTags";
    public class RemovePossibleRequestAndTagCommandHandler : IRequestHandler<RemovePossibleRequestAndTagCommand, RemovedPossibleRequestAndTagDto>
    {

        private readonly IPossibleRequestService _possibleRequestService;
        private readonly ITagService _tagService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

        public RemovePossibleRequestAndTagCommandHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
        }

        public async Task<RemovedPossibleRequestAndTagDto> Handle(RemovePossibleRequestAndTagCommand request, CancellationToken cancellationToken)
        {
            await _possibleRequestAndTagBusinessRules.PossibleRequestIdShouldBeExist(request.Id);

            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetById(request.Id);

            PossibleRequestAndTag mappedPossibleRequestAndTag = _mapper.Map<PossibleRequestAndTag>(request);

            await _possibleRequestAndTagService.Remove(possibleRequestAndTag);

            RemovedPossibleRequestAndTagDto removedPossibleAndTagRequestDto = _mapper.Map<RemovedPossibleRequestAndTagDto>(mappedPossibleRequestAndTag);
            removedPossibleAndTagRequestDto.Status = possibleRequestAndTag.Status;
            removedPossibleAndTagRequestDto.PossibleRequestId = possibleRequestAndTag.PossibleRequestId;
            removedPossibleAndTagRequestDto.TagId = possibleRequestAndTag.TagId;


            return removedPossibleAndTagRequestDto;

        }
    }
}
