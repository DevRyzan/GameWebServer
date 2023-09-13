using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Caching;
using Domain.Entities.SupportRequests;
using MediatR;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByTagIdPossibleRequest;
public class GetByTagIdPossibleRequestQuery : IRequest<PossibleRequestDto>, ICachableRequest //, ISecuredRequest
{
    public GetByTagIdPossibleRequestDto GetByTagIdPossibleRequestDto { get; set; }

    //public string[] Roles => new[] { Admin, PossibleRequestGet };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByTagIdPossibleRequestQuery ({GetByTagIdPossibleRequestDto.TagId}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";


    public class GetByTagIdPossibleRequestQueryHandler : IRequestHandler<GetByTagIdPossibleRequestQuery, PossibleRequestDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

        public GetByTagIdPossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<PossibleRequestDto> Handle(GetByTagIdPossibleRequestQuery request, CancellationToken cancellationToken)
        {

            await _possibleRequestBusinessRules.TagIdShouldBeExist(request.GetByTagIdPossibleRequestDto.TagId);
            Tag tag = await _tagService.GetById(request.GetByTagIdPossibleRequestDto.TagId);

            await _possibleRequestBusinessRules.TagIdShouldBeExist(request.GetByTagIdPossibleRequestDto.TagId);
            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetByTagId(request.GetByTagIdPossibleRequestDto.TagId);

            await _possibleRequestBusinessRules.PossibleRequestIdShouldBeExist(possibleRequestAndTag.PossibleRequestId);
            PossibleRequest possibleRequest = await _possibleRequestService.GetById(possibleRequestAndTag.PossibleRequestId);

            PossibleRequestDto possibleRequestDto = _mapper.Map<PossibleRequestDto>(possibleRequest);
            possibleRequestDto.PossibleRequestAndTagId = possibleRequestAndTag.Id;
            possibleRequestDto.PossibleRequestAndTagStatus = possibleRequestAndTag.Status;

            return possibleRequestDto;


        }
    }
}