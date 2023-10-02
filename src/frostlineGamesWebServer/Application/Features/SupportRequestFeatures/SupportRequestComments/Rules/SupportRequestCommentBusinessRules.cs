using Application.Features.SupportRequestFeatures.SupportRequestComments.Constants;
using Application.Features.SupportRequestFeatures.SupportRequests.Constants;
using Application.Services.Repositories.BardRepositories;
using Application.Services.Repositories.SupportRequestRepositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities.SupportRequests;

namespace Application.Features.SupportRequestFeatures.SupportRequestComments.Rules;

public class SupportRequestCommentBusinessRules : BaseBusinessRules
{
    private readonly ISupportRequestCommentRepository _supportRequestCommentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBardRepository _bardRepository;
    private readonly ISupportRequestRepository _supportRequestRepository;

    public SupportRequestCommentBusinessRules(ISupportRequestCommentRepository supportRequestCommentRepository, IUserRepository userRepository, IBardRepository bardRepository, ISupportRequestRepository supportRequestRepository)
    {
        _supportRequestCommentRepository = supportRequestCommentRepository;
        _userRepository = userRepository;
        _bardRepository = bardRepository;
        _supportRequestRepository = supportRequestRepository;
    }

    public virtual async Task SupportRequestCommentIdShouldBeExist(int? id)
    {
        SupportRequestComment supportRequestComment = await _supportRequestCommentRepository.GetAsync(a => a.Id.Equals(id));
        if (supportRequestComment == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestCommentDoesNotExist);
    }

    public virtual async Task SupportRequestIdShouldBeExistByRequestId(int? id)
    {
        SupportRequestComment supportRequestComment = await _supportRequestCommentRepository.GetAsync(a => a.SupportRequestId.Equals(id));
        if (supportRequestComment == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestDoesNotExist);
    }

    public virtual async Task UserShouldBeExistsWhenSelected(Guid? userId)
    {
        User? result = await _userRepository.GetAsync(b => b.Id.Equals(userId));

        if (result == null) throw new BusinessException(SupportRequestMessages.UserDonNotExists);
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

    public virtual async Task SupportRequestCommnetIdShouldBeExistByRequestId(int? id)
    {
        SupportRequestComment supportRequestComment = await _supportRequestCommentRepository.GetAsync(a => a.Id.Equals(id));
        if (supportRequestComment == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestDoesNotExist);
    }
    public virtual async Task UserIdShouldBeExist(Guid userId)
    {
        var user = await _userRepository.GetAsync(x => x.Id == userId);
        if (user == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestUserIdControl);
    }
    public virtual Task SupportRequestCommentShouldBeExist(SupportRequestComment supportRequestComment)
    {

        if (supportRequestComment == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestCommentDoesNotExist);
        return Task.CompletedTask;
    }

    public virtual async Task SupportRequestIdShouldBeExist(int supportRequestId)
    {
        SupportRequest supportRequest = await _supportRequestRepository.GetAsync(a => a.Id.Equals(supportRequestId));
        if (supportRequest == null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestDoesNotExists);
    }
    public virtual async Task SupportRequestShouldBeCanWriteTrue(int supportRequestId)
    {
        SupportRequest supportRequest = await _supportRequestRepository.GetAsync(a => a.Id.Equals(supportRequestId));
        if (supportRequest.CanWriteBack == false) throw new BusinessException(SupportRequestCommentMessages.SupportRequestShouldBeCanWriteTrue);
    }
    public virtual async Task SupportRequestShouldBeAssigned(int supportRequestId)
    {
        SupportRequest supportRequest = await _supportRequestRepository.GetAsync(a => a.Id.Equals(supportRequestId));
        if (supportRequest.AssignedUserId is null) throw new BusinessException(SupportRequestCommentMessages.SupportRequestShouldBeAssigned);
    }

    public virtual async Task SupportRequestCommentShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(SupportRequestCommentMessages.PageRequestDontSuccess);
    }

    public virtual async Task BardIdShouldBeExist(int? bardId)
    {
        var bard = await _bardRepository.GetAsync(a => a.Id.Equals(bardId));
        if (bard == null) throw new BusinessException(SupportRequestCommentMessages.BardDoesNotExist);
    }

    public async Task UserShouldBeExist(Guid userId)
    {
        var user = await _userRepository.GetAsync(x => x.Id.Equals(userId));
        if (user == null) throw new BusinessException(SupportRequestCommentMessages.UserShouldBeExist);
    }

    public async Task BardShouldBeExist(Guid userId)
    {
        var bard = await _bardRepository.GetAsync(x => x.UserId.Equals(userId));
        if (bard == null) throw new BusinessException(SupportRequestCommentMessages.BardShouldBeExist);
    }
}
