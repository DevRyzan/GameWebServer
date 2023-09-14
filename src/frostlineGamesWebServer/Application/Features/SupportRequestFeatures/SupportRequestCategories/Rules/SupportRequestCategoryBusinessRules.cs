using Application.Feature.UserFeatures.Auths.Constans;
using Application.Features.SupportRequestFeatures.SupportRequestCategories.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Rules;

public class SupportRequestCategoryBusinessRules : BaseBusinessRules
{
    private readonly ISupportRequestCategoryRepository _supportRequestCategoryRepository;

    public SupportRequestCategoryBusinessRules(ISupportRequestCategoryRepository supportRequestCategoryRepository)
    {
        _supportRequestCategoryRepository = supportRequestCategoryRepository;
    }

    public virtual async Task SupportRequestShouldBeExistWhenSelected(int? id)
    {
        SupportRequestCategory? result = await _supportRequestCategoryRepository.GetAsync(a => a.Id == id);
        if (result == null) throw new BusinessException(SupportRequestCategoryMessages.SupportRequestCategoryDontExists);
    }

    public virtual Task SupportRequestCategoryShouldBeExist(SupportRequestCategory supportRequestCategory)
    {
        if (supportRequestCategory is null) throw new BusinessException(SupportRequestCategoryMessages.SupportRequestCategoryDontExists);
        return Task.CompletedTask;
    }
    public virtual async Task SupportRequestShouldBeNotExistWhenCreated(string name)
    {
        SupportRequestCategory? supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(a => a.Name == name);
        if (supportRequestCategory != null) throw new BusinessException(SupportRequestCategoryMessages.SupportRequestCategoryExists);
    }
    public virtual async Task SupportRequestCategoryListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(AuthMessages.PageRequestDontSuccess);

    }
}
