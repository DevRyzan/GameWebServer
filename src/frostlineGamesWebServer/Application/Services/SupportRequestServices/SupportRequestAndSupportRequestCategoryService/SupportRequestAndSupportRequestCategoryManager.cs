using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.SupportRequestServices.SupportRequestAndSupportRequestCategoryService;

public class SupportRequestAndSupportRequestCategoryManager : ISupportRequestAndSupportRequestCategoryService
{
    private readonly ISupportRequestAndSupportRequestCategoryRepository _supportRequestAndSupportRequestCategoryRepository;

    public SupportRequestAndSupportRequestCategoryManager(ISupportRequestAndSupportRequestCategoryRepository supportRequestAndSupportRequestCategoryRepository)
    {
        _supportRequestAndSupportRequestCategoryRepository = supportRequestAndSupportRequestCategoryRepository;
    }


    #region CRUD Services
    public async Task<SupportRequestAndSupportRequestCategory> Create(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory)
    {
        SupportRequestAndSupportRequestCategory _supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.AddAsync(supportRequestAndSupportRequestCategory);
        return _supportRequestAndSupportRequestCategory;
    }
    public async Task<SupportRequestAndSupportRequestCategory> Delete(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory)
    {
        SupportRequestAndSupportRequestCategory _supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.UpdateAsyncTrackerClear(supportRequestAndSupportRequestCategory);
        return _supportRequestAndSupportRequestCategory;
    }
    public async Task<SupportRequestAndSupportRequestCategory> Remove(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory)
    {
        SupportRequestAndSupportRequestCategory? _supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.DeleteAsync(supportRequestAndSupportRequestCategory);
        return _supportRequestAndSupportRequestCategory;
    }
    public async Task<SupportRequestAndSupportRequestCategory> Update(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory)
    {
        SupportRequestAndSupportRequestCategory? _supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.UpdateAsyncTrackerClear(supportRequestAndSupportRequestCategory);
        return _supportRequestAndSupportRequestCategory;
    }
    #endregion

    #region Single Value Services
    public async Task<SupportRequestAndSupportRequestCategory> GetById(int id)
    {
        SupportRequestAndSupportRequestCategory? supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(x => x.Id.Equals(id));
        return supportRequestAndSupportRequestCategory;
    }
    public async Task<SupportRequestAndSupportRequestCategory> GetByIdByStatusTrue(int id)
    {
        SupportRequestAndSupportRequestCategory? supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return supportRequestAndSupportRequestCategory;
    }
    public async Task<SupportRequestAndSupportRequestCategory> GetByRequestId(int requestId)
    {
        SupportRequestAndSupportRequestCategory? supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(x => x.SupportRequestId.Equals(requestId));
        return supportRequestAndSupportRequestCategory;
    }

    #region Status True
    public async Task<SupportRequestAndSupportRequestCategory> GetByRequestIdByStatusTrue(int requestId)
    {
        SupportRequestAndSupportRequestCategory? supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(x => x.SupportRequestId.Equals(requestId) && x.Status == true);
        return supportRequestAndSupportRequestCategory;
    }
    #endregion

    #endregion

    #region List Services
    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetByActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> paginate = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetInActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> supportRequestAndSupportRequestCategory = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return supportRequestAndSupportRequestCategory;
    }
    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> paginate = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListByCategoryId(int categoryId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> paginate = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(
            index: index, 
            size: size,   
            predicate: x => x.SupportRequestCategoryId.Equals(categoryId),
            include: t => t.Include(u => u.SupportRequest).Include(u => u.SupportRequestCategory)
        );
        return paginate;
    }


    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListBySupportRequestId(int supportRequestId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> paginate = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(
            index: index, 
            size: size,   
            predicate: x => x.SupportRequestId.Equals(supportRequestId),
            include: t => t.Include(u => u.SupportRequest).Include(u => u.SupportRequestCategory)
        );

        return paginate;
    }

    #region Status True
    public async Task<IPaginate<SupportRequestAndSupportRequestCategory>> GetListByCategoryIdByStatusTrue(int categoryId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndSupportRequestCategory> paginate = await _supportRequestAndSupportRequestCategoryRepository.GetListAsync(x => x.SupportRequestCategoryId.Equals(categoryId) && x.Status == true, index: index, size: size);
        return paginate;
    }

    #endregion
    #endregion

}

