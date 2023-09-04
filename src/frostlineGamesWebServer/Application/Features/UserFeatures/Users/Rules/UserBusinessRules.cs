using Application.Feature.UserFeatures.Auths.Constans;
using Application.Service.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Pipelines.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities.Users;

namespace Application.Feature.UserFeatures.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
    private readonly IUserDetailRepository _userDetailRepository;

    public UserBusinessRules(IUserRepository userRepository, IUserDetailRepository userDetailRepository, IEmailAuthenticatorRepository emailAuthenticatorRepository)
    {
        _userRepository = userRepository;
        _userDetailRepository = userDetailRepository;
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
    }

    public virtual async Task UserIdShouldExistWhenSelected(Guid id)
    {
        User? result = await _userRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(AuthMessages.UserDontExists);
    }

    public virtual async Task UserShouldBeHaveAuthenticatorType(Guid userId)
    {
        User user = await _userRepository.GetAsync(a => a.Id.Equals(userId) && a.AuthenticatorType > 0);
        if (user == null) throw new BusinessException(AuthMessages.UserShouldHaveAuthenticatorType);
    }
    public virtual async Task UserShouldBeVerifyEmail(Guid userId)
    {
        EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(a => a.UserId.Equals(userId) && a.IsVerified.Equals(true));
        if (emailAuthenticator == null) throw new BusinessException(AuthMessages.UserShouldBeVerified);
    }
    public virtual async Task UserDetailIdShouldExistWhenSelected(int id)
    {
        UserDetail? result = await _userDetailRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(AuthMessages.UserDetailDontExists);
    }
    public virtual async Task UserListShouldBeListedWhenSelected(int page, int pageSize)
    {
        if (page < 0 || pageSize < 0)
            throw new BusinessException(AuthMessages.PageRequestDontSuccess);
    }
    public Task UserShouldBeExist(User? user)
    {
        if (user is null) throw new BusinessException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }
    public Task UserPasswordShouldBeMatch(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }
    public Task UserNewPasswordShouldBeDiffrent(User user, string password)
    {
        if (HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.UserNewPasswordShouldBeDiffrent);
        return Task.CompletedTask;
    }
    //public async Task UserNickNameShouldBeNotExists(string nickName)
    //{
    //    User? user = await _userRepository.GetAsync(u => u.Email == nickName);
    //    if (user != null) throw new BusinessException("User Nickname already exists.");
    //}
    public virtual async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user != null) throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }
    public virtual async Task UserEmailShouldBeExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user == null) throw new BusinessException(AuthMessages.UserMailDontExists);
    }
    public virtual async Task FirstNameShouldBeExists(string firstName)
    {
        User? user = await _userRepository.GetAsync(u => u.FirstName == firstName);
        if (user == null) throw new BusinessException(AuthMessages.UserFirstNameDontExist);
    }

    public virtual async Task LastNameShouldBeExists(string lastName)
    {
        User? user = await _userRepository.GetAsync(u => u.LastName == lastName);
        if (user == null) throw new BusinessException(AuthMessages.UserLastNameDontExist);
    }

    public async Task EmailShouldBeExist(string email)
    {
        User? user = await _userRepository.GetAsync(x => x.Email.Equals(email));
        if (user == null) throw new BusinessException(AuthMessages.EmailShouldBeExists);
    }
    public virtual async Task UserStatusShouldBeTrue(bool status)
    {
        if (status = !true) throw new BusinessException(AuthMessages.UserStatusShouldBeTrue);

    }

    public async Task UserIdShouldBeEmailAtAuthenticator(Guid userId)
    {
        EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(x => x.UserId.Equals(userId));
        if (emailAuthenticator == null) throw new BusinessException(AuthMessages.UserIdShouldBeEmailAtAuthenticator);
    }
}
