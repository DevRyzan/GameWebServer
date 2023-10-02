using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.SupportRequests;
using Domain.Enums;
using MediatR;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.CreateList;
public class CreateListSupportRequestAndTagCommandHandler : IRequestHandler<CreateListSupportRequestAndTagCommandRequest, List<CreateListSupportRequestAndTagCommandResponse>>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public CreateListSupportRequestAndTagCommandHandler(ISupportRequestAndTagService supportRequestAndTagService, ITagService tagService, ISupportRequestService supportRequestService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _tagService = tagService;
        _supportRequestService = supportRequestService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<CreateListSupportRequestAndTagCommandResponse>> Handle(CreateListSupportRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndTagBusinessRules.SupportRequestIdShouldBeExistWhenCreating(request.SupportRequestId);
        await _supportRequestAndTagBusinessRules.TagIdListShouldBeExistWhenCreating(request.TagIds);
        await _supportRequestAndTagBusinessRules.SupportRequestAndTagListCannotRepeat(request.SupportRequestId, request.TagIds);

        List<SupportRequestAndTag> supportRequestAndTagsList = new List<SupportRequestAndTag>();

        for (int i = 0; i < request.TagIds.Count; i++)
        {
            SupportRequestAndTag _supportRequestAndTagsList = new SupportRequestAndTag();

            _supportRequestAndTagsList.SupportRequestId = request.SupportRequestId;
            _supportRequestAndTagsList.TagId = request.TagIds[i];
            _supportRequestAndTagsList.Code = UIDGenerator.GenerateUID(modelName: "SupportRequestAndTag");
            _supportRequestAndTagsList.Status = true;
            supportRequestAndTagsList.Add(_supportRequestAndTagsList);
        }

        List<SupportRequestAndTag> createdSupportRequestAndTagList = await _supportRequestAndTagService.CreateList(supportRequestAndTagsList);

        List<SupportRequestAndTag> supportRequestAndTags = await _supportRequestAndTagService.GetListByRequestId(request.SupportRequestId);

        List<Tag> tagList = await _tagService.GetListByTagIds(supportRequestAndTags.Select(x => x.TagId).ToList());

        SupportRequest supportRequest = await _supportRequestService.GetById(request.SupportRequestId);

        List<int> tagIds = new List<int>();

        foreach (var item in tagList)
            tagIds.Add(Convert.ToInt32(item.TagPriority));

        if (tagIds.Average() < 0.5)
            supportRequest.SupportRequestPriority = SupportRequestPriority.Low;
        if (tagIds.Average() < 1.5)
            supportRequest.SupportRequestPriority = SupportRequestPriority.Medium;
        else
            supportRequest.SupportRequestPriority = SupportRequestPriority.High;


        supportRequest.Status = true;
        await _supportRequestService.Update(supportRequest);

        List<CreateListSupportRequestAndTagCommandResponse> mappedResponse = _mapper.Map<List<CreateListSupportRequestAndTagCommandResponse>>(createdSupportRequestAndTagList);


        return mappedResponse;
    }
}
