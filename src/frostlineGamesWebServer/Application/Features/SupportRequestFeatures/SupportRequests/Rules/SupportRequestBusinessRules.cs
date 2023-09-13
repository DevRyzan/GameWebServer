using Application.Feature.UserFeatures.Auths.Constans;
using Application.Features.SupportRequestFeatures.SupportRequests.Constants;
using Application.Services.Repositories.BardRepositories;
using Application.Services.Repositories.SupportRequestRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Enums;
using Persistence.Models;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Rules;

public class SupportRequestBusinessRules : BaseBusinessRules
{
    private readonly ISupportRequestRepository _supportRequestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ISupportRequestCategoryRepository _supportRequestCategoryRepository;
    private readonly IBardRepository _bardRepository;


    public SupportRequestBusinessRules(ISupportRequestRepository supportRequestRepository, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, IUserDetailRepository userDetailRepository, ISupportRequestCategoryRepository supportRequestCategoryRepository, IBardRepository bardRepository)
    {
        _supportRequestRepository = supportRequestRepository;
        _userRepository = userRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userDetailRepository = userDetailRepository;
        _supportRequestCategoryRepository = supportRequestCategoryRepository;
        _bardRepository = bardRepository;
    }
    public virtual async Task SupportRequestShouldBeExist(int id)
    {
        var result = await _supportRequestRepository.GetAsync(x => x.Id.Equals(id));
        if (result == null) throw new BusinessException(SupportRequestMessages.SupportRequestShouldBeExist);

    }
    public virtual async Task SupportRequestShouldBeNotAssigned(int id)
    {
        var result = await _supportRequestRepository.GetAsync(a => a.Id.Equals(id));
        if (result.AssignedUserId is not null) throw new BusinessException(SupportRequestMessages.SupportRequestShouldBeNotAssigned);

    }
    public virtual async Task SupportRequestShouldBeExistWhenSelectedByUserId(Guid userId)
    {
        var detail = await _userDetailRepository.GetAsync(predicate: a => a.UserId.Equals(userId));

        var result = await _supportRequestRepository.GetAsync(predicate: a => a.UserDetail.UserId == userId);

        if (result == null) throw new BusinessException(SupportRequestMessages.SupportRequestShouldBeExist);
    }
    public virtual async Task<bool> IfBardExistTakeBardsNickname(Guid userId)
    {
        Bard? result = await _bardRepository.GetAsync(a => a.UserId == userId);
        if (result != null)
            if (result.Status == true)
                return true;
        return false;
    }

    public async Task UserIsAssigned(Guid userId)
    {
        var supportRequest = await _supportRequestRepository.GetAsync(x => x.AssignedUserId.Equals(userId));
        if (supportRequest == null) throw new BusinessException(SupportRequestMessages.UserNotAssignedForSupportRequest);
    }
    public async Task SupportRequestEmailShouldBeExists(string? email)
    {
        var supportRequest = await _supportRequestRepository.GetAsync(u => u.UserEmail == email);
        if (supportRequest != null) throw new BusinessException(SupportRequestMessages.SupportRequestEmailShouldBeExists);
    }
    public Task SupportRequestListShouldBeExists(IPaginate<SupportRequest>? supportRequestList)
    {
        if (supportRequestList.Count == 0) throw new BusinessException(SupportRequestMessages.SupportRequestListShouldBeExists);
        return Task.CompletedTask;
    }

    public Task SupportRequesStatusTypeShouldBeExists(SupportRequestStatusType? supportRequestStatusType)
    {
        if (supportRequestStatusType == null) throw new BusinessException(SupportRequestMessages.SupportRequestStatusTypeShouldBeValid);
        return Task.CompletedTask;
    }

    //public virtual async Task SupportRequestBardIdShouldBeExist(int? bardId)
    //{
    //    Bard? bard = await _bardRepository.GetAsync(x => x.Id == bardId);
    //    if (bard == null) throw new BusinessException(SupportRequestMessages.BardDonNottExists);
    //}

    public virtual async Task SupportRequestCatogryIdShouldBeExists(int? categoryId)
    {
        var supportRequestCategory = await _supportRequestCategoryRepository.GetAsync(x => x.Id.Equals(categoryId));
        if (supportRequestCategory == null) throw new BusinessException(SupportRequestMessages.SupportRequestCategoryDonNotExists);
    }
    //public async Task UserShouldBeEmployee(Guid userId)
    //{
    //    User? result = await _userRepository.GetAsync(b => b.Id.Equals(userId));
    //    Employee employee = await _employeeRepository.GetAsync(a => a.UserId.Equals(result.Id));

    //    if (employee == null) throw new BusinessException(SupportRequestMessages.UserShouldBeEmployee);
    //}
    public virtual async Task UserShouldBeExistsWhenSelected(Guid? userId)
    {
        User? result = await _userRepository.GetAsync(b => b.Id.Equals(userId));

        if (result == null) throw new BusinessException(SupportRequestMessages.UserDonNotExists);
    }
    public virtual async Task AssignedUserIdShouldBeExistsWhenSelected(Guid? assignedUserId)
    {
        User? result = await _userRepository.GetAsync(b => b.Id.Equals(assignedUserId));
        //UserOperationClaim role = await _userOperationClaimRepository.GetAsync(a => a.UserId.Equals(assignedUserId));
        if (result == null) throw new BusinessException(SupportRequestMessages.UserDonNotExists);
    }
    public virtual async Task SupportRequestListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(AuthMessages.PageRequestDontSuccess);

    }
    //public async Task UserShouldBeEmployee(Guid userId)
    //{
    //    User? result = await _userRepository.GetAsync(b => b.Id.Equals(userId));
    //    Employee employee = await _employeeRepository.GetAsync(a => a.UserId.Equals(result.Id));

    //    if (employee == null) throw new BusinessException(SupportRequestMessages.UserShouldBeEmployee);
    //}

    public virtual Task BardShouldBeExistWhenSupportRequestCreating(Bard bard)
    {
        if (bard == null) throw new BusinessException(SupportRequestMessages.BardDonNottExists);
        return Task.CompletedTask;

    }

    public async Task CheckIPValid(string userIP)
    {

        char chrFullStop = '.';
        string[] arrOctets = userIP.Split(chrFullStop);
        if (arrOctets.Length != 4)
        {
            throw new BusinessException(SupportRequestMessages.CheckIpValidFalse);
        }
        short MAXVALUE = 255;
        int temp;
        foreach (string strOctet in arrOctets)
        {
            if (strOctet.Length > 3)
            {
                throw new BusinessException(SupportRequestMessages.CheckIpValidFalse);
            }

            temp = int.Parse(strOctet);
            if (temp > MAXVALUE)
            {
                throw new BusinessException(SupportRequestMessages.CheckIpValidFalse);
            }
        }
    }

    public async Task StatusShouldBeFalse(int id)
    {
        var supportRequest = await _supportRequestRepository.GetAsync(x => x.Id.Equals(id));
        if (supportRequest.Status == true) throw new BusinessException(SupportRequestMessages.StatusShouldBeFalse);
    }
}
