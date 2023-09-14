using Core.Persistence.Repositories;
using Core.Security.Entities;  

namespace Domain.Entities.Users;

public class UserDetail : Entity<int>
{
    public Guid? UserId { get; set; }
    public int? BasketId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Adress { get; set; }
    public bool? IsOnline { get; set; }
    public bool? IsBanned { get; set; }
    public DateTime? LoggedDate { get; set; }
    public User User { get; set; }
    public ICollection<BannedAndUserDetail> BannedAndUserDetails { get; set; }
    //public ICollection<UserDetailImageFile> UserDetailImageFiles { get; set; }
    //public ICollection<SupportRequest> SupportRequests { get; set; }

    public UserDetail()
    {

    }
    //public UserDetail()
    //{
    //    UserId = Convert.ToInt32(string.Empty);
    //    BasketId = Convert.ToInt32(string.Empty);
    //    PhoneNumber = string.Empty;
    //    Address = string.Empty;
    //    IsOnline = false;
    //    IsBanned = false;
    //    BannedAndUserDetails = new HashSet<BannedAndUserDetail>();
    //}
    public UserDetail(Guid? userId, int? basketId, string? phoneNumber, string? address, bool? ısOnline, bool ısBanned, DateTime? loggedDate, User user, ICollection<BannedAndUserDetail> bannedAndUserDetails)
    {
        UserId = userId;
        BasketId = basketId;
        PhoneNumber = phoneNumber;
        Adress = address;
        IsOnline = ısOnline;
        IsBanned = ısBanned;
        LoggedDate = loggedDate;
        User = user;
        BannedAndUserDetails = bannedAndUserDetails;
    }
 
    public UserDetail(int id, Guid? userId, int? basketId, string? phoneNumber, string? address, bool? ısOnline, bool ısBanned, DateTime? loggedDate, User user, ICollection<BannedAndUserDetail> bannedAndUserDetails) : this()
 
    {
        Id = id;
        UserId = userId;
        BasketId = basketId;
        PhoneNumber = phoneNumber;
        Adress = address;
        IsOnline = ısOnline;
        IsBanned = ısBanned;
        LoggedDate = loggedDate;
        User = user;
        BannedAndUserDetails = bannedAndUserDetails;
    }


    public static implicit operator UserDetail(List<UserDetail> v)
    {
        throw new NotImplementedException();
    }
}
