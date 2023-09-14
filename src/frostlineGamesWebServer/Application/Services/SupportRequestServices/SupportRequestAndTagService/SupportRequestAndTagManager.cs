using Application.Services.Repositories.SupportRequestRepositories;
using Core.Persistence.Paging;
using Domain.Entities.SupportRequests;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.SupportRequestServices.SupportRequestAndTagService;

public class SupportRequestAndTagManager : ISupportRequestAndTagService
{
    private readonly ISupportRequestAndTagRepository _supportRequestAndTagRepository;

    public SupportRequestAndTagManager(ISupportRequestAndTagRepository supportRequestAndTagRepository)
    {
        _supportRequestAndTagRepository = supportRequestAndTagRepository;
    }

    #region CRUD Services
    public async Task<SupportRequestAndTag> Create(SupportRequestAndTag supportRequestAndTag)
    {
        SupportRequestAndTag? _supportRequestAndTag = await _supportRequestAndTagRepository.AddAsync(supportRequestAndTag);
        return _supportRequestAndTag;
    }
    public async Task<List<SupportRequestAndTag>> CreateList(List<SupportRequestAndTag> supportRequestAndTagList)
    {
        List<SupportRequestAndTag> list = await _supportRequestAndTagRepository.AddRangeAsync(entity: supportRequestAndTagList);
        return list;
    }
    public async Task<SupportRequestAndTag> Delete(SupportRequestAndTag supportRequestAndTag)
    {
        SupportRequestAndTag? _supportRequestAndTag = await _supportRequestAndTagRepository.UpdateAsyncTrackerClear(supportRequestAndTag);
        return _supportRequestAndTag;
    }
    public async Task<SupportRequestAndTag> Remove(SupportRequestAndTag supportRequestAndTag)
    {
        SupportRequestAndTag? _supportRequestAndTag = await _supportRequestAndTagRepository.DeleteAsync(supportRequestAndTag);
        return _supportRequestAndTag;
    }
    public async Task<SupportRequestAndTag> Update(SupportRequestAndTag supportRequestAndTag)
    {
        SupportRequestAndTag? _supportRequestAndTag = await _supportRequestAndTagRepository.UpdateAsyncTrackerClear(supportRequestAndTag);
        return _supportRequestAndTag;
    }
    #endregion

    #region Single Value Service
    public async Task<SupportRequestAndTag> GetById(int id)
    {
        SupportRequestAndTag? supportRequestAndTag = await _supportRequestAndTagRepository.GetAsync(x => x.Id.Equals(id));
        return supportRequestAndTag;
    }

    #region Status True
    public async Task<SupportRequestAndTag> GetByIdByStatusTrue(int id)
    {
        SupportRequestAndTag? supportRequestAndTag = await _supportRequestAndTagRepository.GetAsync(x => x.Id.Equals(id) && x.Status == true);
        return supportRequestAndTag;
    }
    #endregion
    #endregion

    #region List Service
    public async Task<IPaginate<SupportRequestAndTag>> GetByActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(x => x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndTag>> GetByInActiveList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(x => x.Status == false, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndTag>> GetList(int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndTag>> GetListByRequestId(int requestId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(x => x.SupportRequestId.Equals(requestId), index: index, size: size);
        return paginate;
    }
    public async Task<List<SupportRequestAndTag>> GetListByRequestId(int requestId)
    {
        List<SupportRequestAndTag> supportRequestAndTags = await _supportRequestAndTagRepository.GetListAsyncWithOutPaginate(x => x.SupportRequestId.Equals(requestId));
        return supportRequestAndTags;
    }
    public async Task<IPaginate<SupportRequestAndTag>> GetListByRequestIdByStatusTrue(int requestId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(x => x.SupportRequestId.Equals(requestId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    public async Task<IPaginate<SupportRequestAndTag>> GetListByTagId(int tagId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(
            index: index,
            size: size,
            predicate: x => x.TagId.Equals(tagId),
            include: t => t.Include(u => u.Request).ThenInclude(u =>u.UserDetail).ThenInclude(e => e.User)); 
        return paginate;
    }
    public async Task<List<SupportRequestAndTag>> GetListByTagIdWithoutPaginate(int tagId)
    {
        List<SupportRequestAndTag> list = await _supportRequestAndTagRepository.GetListAsyncWithOutPaginate(x => x.TagId.Equals(tagId));
        return list;
    }

    #region Status True
    public async Task<IPaginate<SupportRequestAndTag>> GetListByTagIdByStatusTrue(int tagId, int index = 0, int size = 10)
    {
        IPaginate<SupportRequestAndTag> paginate = await _supportRequestAndTagRepository.GetListAsync(x => x.TagId.Equals(tagId) && x.Status == true, index: index, size: size);
        return paginate;
    }
    #endregion

    #endregion

}
