using Application.Features.SupportRequestFeatures.Tags.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.Tags.Rules;

public class TagBusinessRules : BaseBusinessRules
{
    private readonly ITagRepository _tagRepository;

    public TagBusinessRules(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public virtual async Task TagListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(TagMessages.TagListDontExists);
    }
    public virtual async Task TagIdShouldBeExist(int id)
    {
        Tag? result = await _tagRepository.GetAsync(t => t.Id == id);
        if (result == null) throw new BusinessException(TagMessages.TagDontExists);
    }
    public virtual Task TagShouldBeExist(Tag? tag)
    {
        if (tag is null) throw new BusinessException(TagMessages.TagDontExists);
        return Task.CompletedTask;
    }
    public async Task TagStatusShouldBeFalse(int id)
    {
        var tag = await _tagRepository.GetAsync(x => x.Id.Equals(id));
        if (tag.Status == true) throw new BusinessException(TagMessages.TagStatusIsNotFalse);
    }
    public async Task TagNameShouldBeNotExists(string name)
    {
        Tag? result = await _tagRepository.GetAsync(t => t.Name.Equals(name));
        if (result != null) throw new BusinessException(TagMessages.TagAlreadyExists);
    }
}
