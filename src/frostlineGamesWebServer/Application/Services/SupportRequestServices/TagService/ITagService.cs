using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Domain.Enums;

namespace Application.Services.SupportRequestServices.TagService;

public interface ITagService
{
    #region CRUD Services
    Task<Tag> Create(Tag tag);
    Task<Tag> Update(Tag tag);
    Task<Tag> Remove(Tag tag);
    Task<Tag> Delete(Tag tag);
    #endregion

    #region Single Value Services
    Task<Tag?> GetByName(string name);
    Task<Tag?> GetById(int? id);

    #region Status True
    Task<Tag?> GetByNameStatusTrue(string name);
    Task<Tag?> GetByIdStatusTrue(int? id);
    #endregion

    #endregion

    #region List Services
    Task<IPaginate<Tag>> GetList(int index = 0, int size = 10);
    Task<IPaginate<Tag>> GetListByTagPriority(TagPriority tagPriority, int index = 0, int size = 10);
    Task<List<Tag>> GetListByTagIds(List<int> tagIds);

    #region Status True
    Task<IPaginate<Tag>> GetListStatusTrue(int index = 0, int size = 10);
    #endregion

    #endregion

}
