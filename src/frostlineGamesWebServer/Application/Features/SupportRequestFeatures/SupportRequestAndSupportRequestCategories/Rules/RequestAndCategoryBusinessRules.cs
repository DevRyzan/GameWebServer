using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Rules;

public class RequestAndCategoryBusinessRules : BaseBusinessRules
{
    private readonly ISupportRequestAndSupportRequestCategoryRepository _supportRequestAndSupportRequestCategoryRepository;
    private readonly ISupportRequestRepository _supportRequestRepository;
    private readonly ISupportRequestCategoryRepository _supportRequestCategoryRepository;

    public RequestAndCategoryBusinessRules(ISupportRequestAndSupportRequestCategoryRepository supportRequestAndSupportRequestCategoryRepository, ISupportRequestRepository supportRequestRepository, ISupportRequestCategoryRepository supportRequestCategoryRepository)
    {
        _supportRequestAndSupportRequestCategoryRepository = supportRequestAndSupportRequestCategoryRepository;
        _supportRequestRepository = supportRequestRepository;
        _supportRequestCategoryRepository = supportRequestCategoryRepository;
    }

    public async virtual Task SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelected(int id)
    {
        SupportRequestAndSupportRequestCategory result = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestAndSupportRequestCategoryNotExists);
    }
    public async virtual Task SupportRequestAndSupportRequestCategoryIdShouldExistWhenSelectedRequestId(int requestId)
    {
        SupportRequestAndSupportRequestCategory result = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(b => b.SupportRequestId == requestId);

        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestNotExists);
    }

    public async virtual Task SupportRequestIdShouldBeExist(int supportRequestId)
    {
        var result = await _supportRequestRepository.GetAsync(b => b.Id == supportRequestId);

        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestNotExists);
    }

    public async virtual Task SupportRequestCategoryIdShouldBeExist(int supportRequestIdCategoryId)
    {
        var result = await _supportRequestCategoryRepository.GetAsync(b => b.Id == supportRequestIdCategoryId);

        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestCategoryIdDontExist);
    }

    public async virtual Task SupportRequestAndSupportRequestCategoryIdShouldNotExistWhenCreating(SupportRequestAndSupportRequestCategory supportRequestAndSupportRequestCategory)
    {
        SupportRequestAndSupportRequestCategory result = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(a => a.SupportRequestId == supportRequestAndSupportRequestCategory.SupportRequestId && a.SupportRequestCategoryId == supportRequestAndSupportRequestCategory.SupportRequestCategoryId);

        if (result != null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestAndSupportRequestCategoryExists);
    }

    public async virtual Task SupportRequestIdShouldBeExistWhenRequestAndCategoryCreating(int id)
    {
        SupportRequest? result = await _supportRequestRepository.GetAsync(a => a.Id == id);
        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestIdDontExist);
    }

    public async virtual Task SupportRequestAndSupportRequestCategoryStatusShouldBeFalse(int id)
    {
        SupportRequestAndSupportRequestCategory? result = await _supportRequestAndSupportRequestCategoryRepository.GetAsync(a => a.Id == id);
        if (result.Status == true) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestAndSupportRequestCategoryStatusIsNotFalse);
    }


    public async virtual Task SupportRequestCategoryIdShouldBeExistWhenRequestAndCategoryCreating(int id)
    {
        SupportRequestCategory? result = await _supportRequestCategoryRepository.GetAsync(a => a.Id == id);
        if (result == null) throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.SupportRequestCategoryIdDontExist);
    }

    public virtual async Task SupportRequestAndSupportRequestCategoryListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 1)
            throw new BusinessException(SupportRequestAndSupportRequestCategoryMessages.PageRequestDontSuccess);
    }

}

