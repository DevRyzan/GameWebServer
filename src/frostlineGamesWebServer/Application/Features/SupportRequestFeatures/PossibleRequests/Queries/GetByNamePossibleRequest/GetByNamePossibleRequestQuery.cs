using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequests.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using AutoMapper;
using Core.Application.Caching;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByNamePossibleRequest;

public class GetByNamePossibleRequestQuery : IRequest<PossibleRequestDto>, ICachableRequest
{
    public GetByNamePossibleRequestDto GetByNamePossibleRequestDto { get; set; }


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string CacheKey => $"GetByNamePossibleRequestQuery ({GetByNamePossibleRequestDto.Name}) ";
    public string? CacheGroupKey => "GetPossibleRequestAndTags";



    public class GetByNamePossibleRequestQueryHandler : IRequestHandler<GetByNamePossibleRequestQuery, PossibleRequestDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestBusinessRules _possibleRequestBusinessRules;

        public GetByNamePossibleRequestQueryHandler(IPossibleRequestService possibleRequestService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestBusinessRules possibleRequestBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestBusinessRules = possibleRequestBusinessRules;
        }

        public async Task<PossibleRequestDto> Handle(GetByNamePossibleRequestQuery request, CancellationToken cancellationToken)
        {
            await _possibleRequestBusinessRules.PossibleRequestNameShouldBeExist(request.GetByNamePossibleRequestDto.Name);
            PossibleRequest possibleRequest = await _possibleRequestService.GetByName(request.GetByNamePossibleRequestDto.Name);

            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetByPossibleRequestId(possibleRequest.Id);

            PossibleRequestDto possibleRequestDto = _mapper.Map<PossibleRequestDto>(possibleRequest); 
            
            var result = await _possibleRequestBusinessRules.IfPossibleRequestAndTagExistSendTagIdAndStatus(possibleRequest.Id);

            if (result)
            {
                possibleRequestDto.PossibleRequestAndTagId = possibleRequestAndTag.Id;
                possibleRequestDto.PossibleRequestAndTagStatus = possibleRequestAndTag.Status;
            }

            return possibleRequestDto;


        }
    }
}
