using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;

namespace Application.Services.SupportRequestServices.SupportRequestCategoryService;

public class SupportRequestCategoryManager : ISupportRequestCategoryService
{
    private readonly ISupportRequestCategoryRepository _supportRequestCategoryRepository;

    public SupportRequestCategoryManager(ISupportRequestCategoryRepository supportRequestCategoryRepository)
    {
        _supportRequestCategoryRepository = supportRequestCategoryRepository;
    }

    #region CRUD Services
    public async Task<SupportRequestCategory?> Create(SupportRequestCategory? supportRequestCategory)
    {
        SupportRequestCategory? _supportRequestCategory = await _supportRequestCategoryRepository.AddAsync(supportRequestCategory);
        return _supportRequestCategory;
    }
    public async Task<SupportRequestCategory?> Delete(SupportRequestCategory? supportRequestCategory)
    {
        SupportRequestCategory? _supportRequestCategory = await _supportRequestCategoryRepository.UpdateAsyncTrackerClear(supportRequestCategory);
        return _supportRequestCategory;
    }
    public async Task<SupportRequestCategory?> Remove(SupportRequestCategory? supportRequestCategory)
    {
        SupportRequestCategory _supportRequestCategory = await _supportRequestCategoryRepository.DeleteAsync(supportRequestCategory);
        return _supportRequestCategory;
    }
    public async Task<SupportRequestCategory?> Update(SupportRequestCategory? supportRequestCategory)
    {
        SupportRequestCategory? _supportRequestCategory = await _supportRequestCategoryRepository.UpdateAsyncTrackerClear(supportRequestCategory);
        return _supportRequestCategory;
    }
    #endregion

    #region Single Value Service
    public async Task<SupportRequestCategory?> GetById(int? id)
    {
        SupportRequestCategory? supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(x => x.Id.Equals(id));
        return supportRequestCategory;
    }
    public async Task<SupportRequestCategory?> GetByName(string name)
    {
        SupportRequestCategory? supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(x => x.Name.Equals(name));
        return supportRequestCategory;
    }

    #region Status True
    public async Task<SupportRequestCategory?> GetByIdByStatusTrue(int id)
    {
        SupportRequestCategory? supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return supportRequestCategory;
    }
    public async Task<SupportRequestCategory?> GetByNameByStatusTrue(string name)
    {
        SupportRequestCategory supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(x => x.Name.Equals(name) && x.Status == true);
        return supportRequestCategory;
    }
    #endregion
    #endregion

    #region List Services
    public async Task<IPaginate<SupportRequestCategory>> GetByActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestCategory> supportRequestCategory = await _supportRequestCategoryRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return supportRequestCategory;
    }
    public async Task<IPaginate<SupportRequestCategory>> GetByInActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestCategory> paginate = await _supportRequestCategoryRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestCategory>> GetList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestCategory> supportRequestCategory = await _supportRequestCategoryRepository.GetListAsync(index: index, size: size);
        return supportRequestCategory;
    }
    #endregion

}
