using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;
using Application.Services.SupportRequestServices.SupportRequestAndTagService;
using Application.Services.SupportRequestServices.SupportRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Entities.SupportRequests;
using Domain.Enums;
using MediatR;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Create;
public class CreateSupportRequestAndTagCommandHandler : IRequestHandler<CreateSupportRequestAndTagCommandRequest, CreateSupportRequestAndTagCommandResponse>
{
    private readonly ISupportRequestAndTagService _supportRequestAndTagService;
    private readonly ITagService _tagService;
    private readonly ISupportRequestService _supportRequestService;
    private readonly SupportRequestAndTagBusinessRules _supportRequestAndTagBusinessRules;
    private readonly IMapper _mapper;

    public CreateSupportRequestAndTagCommandHandler(ISupportRequestAndTagService supportRequestAndTagService, SupportRequestAndTagBusinessRules supportRequestAndTagBusinessRules, IMapper mapper, ITagService tagService, ISupportRequestService supportRequestService)
    {
        _supportRequestAndTagService = supportRequestAndTagService;
        _supportRequestAndTagBusinessRules = supportRequestAndTagBusinessRules;
        _mapper = mapper;
        _tagService = tagService;
        _supportRequestService = supportRequestService;
    }

    public async Task<CreateSupportRequestAndTagCommandResponse> Handle(CreateSupportRequestAndTagCommandRequest request, CancellationToken cancellationToken)
    {
        await _supportRequestAndTagBusinessRules.SupportRequestIdShouldBeExistWhenCreating(request.CreatedSupportRequestAndTagDto.SupportRequestId);
        await _supportRequestAndTagBusinessRules.TagIdShouldBeExistWhenCreating(request.CreatedSupportRequestAndTagDto.TagId);
        await _supportRequestAndTagBusinessRules.SupportRequestAndTagCannotRepeat(request.CreatedSupportRequestAndTagDto.SupportRequestId, request.CreatedSupportRequestAndTagDto.TagId);

        SupportRequestAndTag mappedSupportRequestAndTag = _mapper.Map<SupportRequestAndTag>(request);
        mappedSupportRequestAndTag.Code = UIDGenerator.GenerateUID(modelName: "SupportRequestAndTag");
        mappedSupportRequestAndTag.Status = true;
        mappedSupportRequestAndTag.CreatedDate = DateTime.Now;

        SupportRequestAndTag createdSupportRequestAndTag = await _supportRequestAndTagService.Create(mappedSupportRequestAndTag);

        List<SupportRequestAndTag> supportRequestAndTags = await _supportRequestAndTagService.GetListByRequestId(createdSupportRequestAndTag.SupportRequestId);

        List<Tag> tags = await _tagService.GetListByTagIds(supportRequestAndTags.Select(x => x.TagId).ToList());
        SupportRequest supportRequest = await _supportRequestService.GetById(request.CreatedSupportRequestAndTagDto.SupportRequestId);

        int lowCount = 0; int mediumCount = 0; int highCount = 0;

        foreach (var tag in tags)
        {
            int tagPriority = Convert.ToInt32(tag.TagPriority);

            if (tagPriority == (int)SupportRequestPriority.Low)
            {
                lowCount++;
                if (lowCount >= 2)
                {
                    supportRequest.SupportRequestPriority = SupportRequestPriority.Low;
                }
            }
            else if (tagPriority == (int)SupportRequestPriority.Medium)
            {
                mediumCount++;
                if (mediumCount >= 2)
                {
                    supportRequest.SupportRequestPriority = SupportRequestPriority.Medium;
                }
            }
            else if (tagPriority == (int)SupportRequestPriority.High)
            {
                highCount++;
                if (highCount >= 2)
                {
                    supportRequest.SupportRequestPriority = SupportRequestPriority.High;
                }
            }
        }
        supportRequest.Status = true;
        await _supportRequestService.Update(supportRequest);

        CreateSupportRequestAndTagCommandResponse createdSupportRequestAndTagDto = _mapper.Map<CreateSupportRequestAndTagCommandResponse>(createdSupportRequestAndTag);

        return createdSupportRequestAndTagDto;
    }
}


