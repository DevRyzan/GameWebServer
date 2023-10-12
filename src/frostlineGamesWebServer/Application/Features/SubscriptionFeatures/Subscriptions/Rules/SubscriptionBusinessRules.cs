using Application.Features.SubscriptionFeatures.Subscriptions.Constants;
using Application.Services.Repositories.SubscriptionRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities.Subscriptions;
using Domain.Enums;

namespace Application.Features.SubscriptionFeatures.Subscriptions.Rules;

public class SubscriptionBusinessRules : BaseBusinessRules
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUserRepository _userRepository;

    public SubscriptionBusinessRules(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
    {
        _subscriptionRepository = subscriptionRepository;
        _userRepository = userRepository;
    }


    public virtual Task SubscriptionShouldBeExist(Subscription subscription)
    {
        if (subscription is null) throw new BusinessException(SubscriptionMessages.SubscriptionDontExists);
        return Task.CompletedTask;
    }
    public async Task SubscriptionIdShouldBeExist(int id)
    {
        Subscription subscription = await _subscriptionRepository.GetAsync(x => x.Id.Equals(id));
        if (subscription == null) throw new BusinessException(SubscriptionMessages.SubscriptionShouldBeExist);
    }
    public virtual async Task UserShouldBeExistsWhenSelected(Guid? userId)
    {
        User? result = await _userRepository.GetAsync(b => b.Id == userId);
        if (result == null) throw new BusinessException(SubscriptionMessages.UserDontExists);
    }
    public virtual async Task SubscriptionShouldBeExistWhenSelected(int id)
    {
        Subscription? result = await _subscriptionRepository.GetAsync(t => t.Id == id);
        if (result == null) throw new BusinessException(SubscriptionMessages.SubscriptionDontExists);
    }
    public Task SubscriptionTypeShouldBeExist(SubscriptionType? subscriptionType)
    {
        if (subscriptionType == null) throw new BusinessException(SubscriptionMessages.SubscriptionTypeShouldBeExists);
        return Task.CompletedTask;
    }
    public virtual async Task SubscriptionListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(SubscriptionMessages.SubscriptionListDontExists);
    }
}
