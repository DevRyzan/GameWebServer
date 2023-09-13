using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Rules;

public class SupportRequestAndTagBusinessRules : BaseBusinessRules
{
    private readonly ISupportRequestAndTagRepository _supportRequestAndTagRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ISupportRequestRepository _supportRequestRepository;

    public SupportRequestAndTagBusinessRules(ISupportRequestAndTagRepository supportRequestAndTagRepository, ITagRepository tagRepository, ISupportRequestRepository supportRequestRepository)
    {
        _supportRequestAndTagRepository = supportRequestAndTagRepository;
        _tagRepository = tagRepository;
        _supportRequestRepository = supportRequestRepository;
    }

    public async virtual Task SupportRequestAndTagIdShouldExistWhenSelected(int id)
    {
        SupportRequestAndTag result = await _supportRequestAndTagRepository.GetAsync(a => a.Id == id);

        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.SupportRequestAndTagNotExists);
    }

    public async virtual Task SupportRequestIdShouldExist(int requestId)
    {
        SupportRequest result = await _supportRequestRepository.GetAsync(a => a.Id == requestId);

        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.SupportRequestIdShouldExist);
    }
    public async virtual Task SupportRequestAndTagCannotRepeat(int requestId, int tagId)
    {
        IPaginate<SupportRequestAndTag> result = await _supportRequestAndTagRepository.GetListAsync(a => a.SupportRequestId == requestId);

        foreach (var item in result.Items)
        {
            if (item.TagId.Equals(tagId))
                throw new BusinessException(SupportRequestAndTagMessages.AlreadySupportRequestHasThisTag);
        }
    }

    public async virtual Task SupportRequestAndTagListCannotRepeat(int requestId, List<int> tagIds)
    {
        IPaginate<SupportRequestAndTag> result = await _supportRequestAndTagRepository.GetListAsync(a => a.SupportRequestId == requestId);

        foreach (var item in result.Items)
        {
            if (tagIds.Contains(item.TagId))
                throw new BusinessException(SupportRequestAndTagMessages.AlreadySupportRequestHasThisTag);
        }
    }
    public async virtual Task TagIdShouldExist(int tagId)
    {
        Tag result = await _tagRepository.GetAsync(a => a.Id == tagId);

        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.TagIdShouldExist);
    }

    public async virtual Task SupportRequestAndTagIdShouldNotExistWhenCreating(SupportRequestAndTag supportRequestAndTag)
    {
        SupportRequestAndTag result = await _supportRequestAndTagRepository.GetAsync(a => a.SupportRequestId == supportRequestAndTag.SupportRequestId && a.TagId == supportRequestAndTag.TagId);

        if (result != null) throw new BusinessException(SupportRequestAndTagMessages.SupportRequestAndTagExists);
    }

    public async virtual Task TagIdShouldBeExistWhenCreating(int id)
    {
        Tag result = await _tagRepository.GetAsync(a => a.Id == id);
        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.TagDontExist);
    }

    public async virtual Task SupportRequestIdShouldBeExistWhenCreating(int id)
    {
        SupportRequest result = await _supportRequestRepository.GetAsync(a => a.Id == id);
        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.SupportRequestDontExist);
    }

    public virtual async Task SupportRequestAndTagListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(SupportRequestAndTagMessages.PageRequestDontSuccess);
    }
    public async Task StatusShouldBeFalse(int id)
    {
        var supportRequestAndTag = await _supportRequestAndTagRepository.GetAsync(x => x.Id.Equals(id));
        if (supportRequestAndTag.Status == true) throw new BusinessException(SupportRequestAndTagMessages.StatusShouldBeFalse);
    }

    public async virtual Task TagIdListShouldBeExistWhenCreating(List<int> tagIds)
    {

        Tag result = await _tagRepository.GetAsync(a => tagIds.Contains(a.Id));
        if (result == null) throw new BusinessException(SupportRequestAndTagMessages.TagDontExist);
    }

    public async Task TagIdShouldBeMinimumOne(List<int> tagIds)
    {

    }

}