using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants;
using Application.Services.Repositories.SupportRequestRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;

public class PossibleRequestAndTagBusinessRules : BaseBusinessRules
{
    private readonly IPossibleRequestRepository _possibleRequestRepository;
    private readonly IPossibleRequestAndTagRepository possibleRequestAndTagRepository;
    private readonly ITagRepository _tagRepository;

    public PossibleRequestAndTagBusinessRules(IPossibleRequestRepository possibleRequestRepository, IPossibleRequestAndTagRepository possibleRequestAndTagRepository, ITagRepository tagRepository)
    {
        _possibleRequestRepository = possibleRequestRepository;
        this.possibleRequestAndTagRepository = possibleRequestAndTagRepository;
        _tagRepository = tagRepository;
    }

    public virtual async Task PossibleRequestIdShouldBeExist(int? id)
    {
        PossibleRequest? possibleRequest = await _possibleRequestRepository.GetAsync(a => a.Id.Equals(id));
        if (possibleRequest == null) throw new BusinessException(PossibleRequestAndTagMessages.PossibleRequestDoesNotExist);
    }

    public virtual async Task TagIdShouldBeExist(int? id)
    {
        Tag? tag = await _tagRepository.GetAsync(a => a.Id.Equals(id));
        if (tag == null) throw new BusinessException(PossibleRequestAndTagMessages.TagIdDontExists);
    }

    public virtual async Task PossibleRequestAndTagIdShouldBeExist(int? id)
    {
        PossibleRequestAndTag? possibleRequestAndTag = await possibleRequestAndTagRepository.GetAsync(a => a.Id.Equals(id));
        if (possibleRequestAndTag == null) throw new BusinessException(PossibleRequestAndTagMessages.PossibleRequestAndTagDoesNotExist);
    }

    public virtual async Task PossibleRequestAndTagShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(PossibleRequestAndTagMessages.PageRequestDontSuccess);
    }
}
