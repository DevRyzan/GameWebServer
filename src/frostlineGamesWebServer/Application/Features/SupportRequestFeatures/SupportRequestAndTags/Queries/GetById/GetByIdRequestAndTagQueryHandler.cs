using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Domain.Entities.SupportRequests;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetById;

public class GetByIdRequestAndTagQueryHandler : IRequestHandler<GetByIdRequestAndTagQueryRequest, GetByIdRequestAndTagQueryResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly IMapper _mapper;
    private readonly SupportRequestAndTagBusinessRules _businessRules;

    public GetByIdRequestAndTagQueryHandler(ISupportRequestAndTagService supportRequestAndTagService, IMapper mapper, SupportRequestAndTagBusinessRules businessRules, ITagService tagService, ISupportRequestService supportRequestService)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _mapper = mapper;
        _businessRules = businessRules;
        _tagService = tagService;
        _supportRequestService = supportRequestService;
    }

    public async Task<GetByIdRequestAndTagQueryResponse> Handle(GetByIdRequestAndTagQueryRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.SupportRequestAndTagIdShouldExistWhenSelected(request.GetByIdSupportRequestAnTagDto.Id);

        SupportRequestAndTag supportRequestsAndTags = await _supportRequestAndTagService.GetById(request.GetByIdSupportRequestAnTagDto.Id);

        var tag = await _tagService.GetById(supportRequestsAndTags.TagId);
        var supportRequest = await _supportRequestService.GetById(supportRequestsAndTags.SupportRequestId);

        await _businessRules.SupportRequestIdShouldExist(supportRequest.Id);
        await _businessRules.TagIdShouldExist(tag.Id);


        GetByIdRequestAndTagQueryResponse mappedResponse = _mapper.Map<GetByIdRequestAndTagQueryResponse>(supportRequestsAndTags);
        mappedResponse.TagName = tag.Name;
        mappedResponse.SupportRequestTitle = supportRequest.SupportRequestTitle;
        mappedResponse.SupportRequestComment = supportRequest.SupportRequestComment;

        return mappedResponse;
    }
}

