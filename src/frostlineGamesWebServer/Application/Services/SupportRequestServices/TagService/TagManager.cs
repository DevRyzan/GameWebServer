using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Domain.Enums;

namespace Application.Services.SupportRequestServices.TagService;

public class TagManager : ITagService
{
    public ITagRepository _tagRepository;

    public TagManager(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    #region CRUD Service
    public async Task<Tag> Create(Tag tag)
    {
        Tag createdTag = await _tagRepository.AddAsync(tag);
        return createdTag;
    }
    public async Task<Tag> Delete(Tag tag)
    {
        Tag updatedTag = await _tagRepository.UpdateAsyncTrackerClear(tag);
        return updatedTag;
    }
    public async Task<Tag> Update(Tag tag)
    {
        Tag updatedTag = await _tagRepository.UpdateAsyncTrackerClear(tag);
        return updatedTag;
    }
    public async Task<Tag> Remove(Tag tag)
    {
        Tag removedTag = await _tagRepository.DeleteAsync(tag);
        return removedTag;
    }
    #endregion

    #region Single Value Service
    public async Task<Tag?> GetById(int? id)
    {
        Tag? tag = await _tagRepository.GetAsync((t) => t.Id.Equals(id));
        return tag;
    }
    public async Task<Tag?> GetByName(string name)
    {
        Tag? tag = await _tagRepository.GetAsync((t) => t.Name.Equals(name));
        return tag;
    }

    #region StatusTrue
    public async Task<Tag?> GetByNameStatusTrue(string name)
    {
        Tag? tag = await _tagRepository.GetAsync(t => t.Name.Equals(name) && t.Status.Equals(true));
        return tag;
    }
    public async Task<Tag?> GetByIdStatusTrue(int? id)
    {
        Tag? tag = await _tagRepository.GetAsync(t => t.Id.Equals(id) && t.Status == true);
        return tag;
    }
    #endregion

    #endregion

    #region List Service
    public async Task<IPaginate<Tag>> GetList(int index = 0, int size = 10)
    {
        IPaginate<Tag> tags = await _tagRepository.GetListAsync(index, size);
        return tags;
    }
    public async Task<List<Tag>> GetListByTagIds(List<int> tagIds)
    {
        List<Tag> tags = await _tagRepository.GetListAsyncWithOutPaginate(x => tagIds.Contains(x.Id));
        return tags;
    }
    public async Task<IPaginate<Tag>> GetListByTagPriority(TagPriority tagPriority, int index = 0, int size = 10)
    {
        IPaginate<Tag> tags = await _tagRepository.GetListAsync(a => a.TagPriority.Equals(Convert.ToInt32(tagPriority)), index: index, size: size);
        return tags;
    }

    #region Status True
    public async Task<IPaginate<Tag>> GetListStatusTrue(int index = 0, int size = 10)
    {
        IPaginate<Tag> tags = await _tagRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return tags;
    }
    #endregion
    #endregion

}
