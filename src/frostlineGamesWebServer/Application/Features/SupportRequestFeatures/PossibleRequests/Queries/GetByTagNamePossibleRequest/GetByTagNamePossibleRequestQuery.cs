using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Caching;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByTagNamePossibleRequest;

public class GetByTagNamePossibleRequestQuery : IRequest<PossibleRequestDto>, ICachableRequest
{
    public GetByTagNamePossibleRequestDto GetByTagNamePossibleRequestDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByTagNamePossibleRequestQuery ({GetByTagNamePossibleRequestDto.TagName}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";



    public class GetByTagNamePossibleRequestQueryHandler : IRequestHandler<GetByTagNamePossibleRequestQuery, PossibleRequestDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly ITagService _tagService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

        public GetByTagNamePossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<PossibleRequestDto> Handle(GetByTagNamePossibleRequestQuery request, CancellationToken cancellationToken)
        {
            await _possibleRequestBusinessRules.TagNameShouldBeExist(request.GetByTagNamePossibleRequestDto.TagName);
            Tag tag = await _tagService.GetByName(request.GetByTagNamePossibleRequestDto.TagName);

            await _possibleRequestBusinessRules.TagIdShouldBeExist(tag.Id);
            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetByTagId(tag.Id);

            await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(possibleRequestAndTag.PossibleRequestId);
            PossibleRequest possibleRequest = await _possibleRequestService.GetById(possibleRequestAndTag.PossibleRequestId);

            PossibleRequestDto possibleRequestDto = _mapper.Map<PossibleRequestDto>(possibleRequest);
            possibleRequestDto.PossibleRequestAndTagId = possibleRequestAndTag.Id;
            possibleRequestDto.PossibleRequestAndTagStatus = possibleRequestAndTag.Status;

            return possibleRequestDto;

        }
    }
}
