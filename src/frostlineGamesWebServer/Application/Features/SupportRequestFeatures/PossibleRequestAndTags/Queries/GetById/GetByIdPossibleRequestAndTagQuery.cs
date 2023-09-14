using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Caching;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetById;

public class GetByIdPossibleRequestAndTagQuery : IRequest<PossibleRequestAndTagDto>, ICachableRequest //, ISecuredRequest
{
    public GetByIdSupportRequestAndTagDto GetByIdSupportRequestAndTagDto { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestAndTagGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByIdPossibleRequestAndTagQuery ({GetByIdSupportRequestAndTagDto.Id}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";


    public class GetByIdPossibleRequestAndTagQueryHandler : IRequestHandler<GetByIdPossibleRequestAndTagQuery, PossibleRequestAndTagDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly ITagService _tagService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestAndTagBusinessRules _possibleRequestBusinessRules;

        public GetByIdPossibleRequestAndTagQueryHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<PossibleRequestAndTagDto> Handle(GetByIdPossibleRequestAndTagQuery request, CancellationToken cancellationToken)
        {
            await _possibleRequestBusinessRules.PossibleRequestAndTagIdShouldBeExist(request.GetByIdSupportRequestAndTagDto.Id);
            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetById(request.GetByIdSupportRequestAndTagDto.Id);

            var tag = await _tagService.GetById(possibleRequestAndTag.TagId);
            var possibleRequest = await _possibleRequestService.GetById(possibleRequestAndTag.PossibleRequestId);

            await _possibleRequestBusinessRules.TagIdShouldBeExist(tag.Id);
            await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(possibleRequest.Id);

            PossibleRequestAndTagDto possibleRequestAndTagDto = _mapper.Map<PossibleRequestAndTagDto>(possibleRequestAndTag);
            possibleRequestAndTagDto.PossibleRequestName = possibleRequest.RequestName;
            possibleRequestAndTagDto.PossibleRequestTitle = possibleRequest.Title;
            possibleRequestAndTagDto.PossibleRequestComment = possibleRequest.Comment;
            possibleRequestAndTagDto.TagName = tag.Name;

            return possibleRequestAndTagDto;

        }
    }
}
