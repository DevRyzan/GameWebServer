using Application.Features.SupportRequestFeatures.PossibleRequests.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Rules;

public class PossibleRequestBusinessRules : BaseBusinessRules
{
    private readonly IPossibleRequestRepository _possibleRequestRepository;
    private readonly IPossibleRequestAndTagRepository _possibleRequestAndTagRepository;
    private readonly ITagRepository _tagRepository;

    public PossibleRequestBusinessRules(IPossibleRequestRepository possibleRequestRepository, IPossibleRequestAndTagRepository possibleRequestAndTagRepository, ITagRepository tagRepository)
    {
        _possibleRequestRepository = possibleRequestRepository;
        _possibleRequestAndTagRepository = possibleRequestAndTagRepository;
        _tagRepository = tagRepository;
    }

    public virtual async Task PossibleRequestIdShouldBeExist(int? id)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.Id.Equals(id));
        if (possibleRequest == null) throw new BusinessException(PossibleRequestMessages.PossibleRequestDoesNotExist);
    }

    public virtual async Task PossibleRequestNameShouldNotBeExistWithId(string name, int id)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.RequestName == name && a.Id != id);
        if (possibleRequest != null) throw new BusinessException(PossibleRequestMessages.PossibleRequestNameAlreadyExists);
    }
    public virtual async Task<bool> IfPossibleRequestAndTagExistSendTagIdAndStatus(int possibleRequestId)
    {
        PossibleRequestAndTag? result = await _possibleRequestAndTagRepository.GetAsync(a => a.PossibleRequestId == possibleRequestId);
        if (result != null)
            return true;
        return false;
    }

    public async Task PossibleRequestStatusShouldBeFalse(int id)
    {
        var possibleRequest = await _possibleRequestRepository.GetAsync(x => x.Id.Equals(id));
        if (possibleRequest.Status == true) throw new BusinessException(PossibleRequestMessages.PossibleRequestStatusIsNotFalse);
    }

    public async Task PossibleRequestShouldNotBeExistInPossibleRequestAndTag(int possibleRequestId)
    {
        var possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(x => x.PossibleRequestId.Equals(possibleRequestId));
        if (possibleRequestAndTag != null) throw new BusinessException(PossibleRequestMessages.PossibleRequestShouldBeNotExistInPossibleRequestAndTag);
    }

    public virtual async Task PossibleRequestNameShouldNotBeExist(string name)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.RequestName == name);
        if (possibleRequest != null) throw new BusinessException(PossibleRequestMessages.PossibleRequestNameAlreadyExists);
    }

    public virtual async Task TagIdShouldBeExist(int? tagId)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await _possibleRequestAndTagRepository.GetAsync(a => a.TagId.Equals(tagId));
        if (possibleRequestAndTag == null) throw new BusinessException(PossibleRequestMessages.TagIdDontExists);
    }
    public virtual Task PossibleRequestAndTagShouldBeExist(PossibleRequestAndTag? possibleRequestAndTag)
    {
        if (possibleRequestAndTag == null) throw new BusinessException(PossibleRequestMessages.PossibleRequestAndTagDoesNotExist);
        return Task.CompletedTask;
    }

    public virtual async Task PossibleRequestShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(PossibleRequestMessages.PageRequestDontSuccess);
    }

    public virtual async Task PossibleRequestNameShouldBeExist(string name)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.RequestName == name);
        if (possibleRequest == null) throw new BusinessException(PossibleRequestMessages.PossibleRequestNameDontExists);
    }

    public virtual async Task TagNameShouldBeExist(string name)
    {
        Tag? tag = await _tagRepository.GetAsync(a => a.Name == name);
        if (tag == null) throw new BusinessException(PossibleRequestMessages.TagNameDontExists);
    }
}
