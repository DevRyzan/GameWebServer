using Core.Persistence.Repositories; 

namespace Domain.Entities.Users;

public class BannedAndUserDetail : Entity<int>
{
    public int UserDetailId { get; set; }
    public int BannedId { get; set; }

    public UserDetail UserDetail { get; set; }
    public Banned Banned { get; set; }
    public DateTime? BeginingBanDate { get; set; }
    public DateTime? EndingBanDate { get; set; }

    public BannedAndUserDetail()
    {

    }
    //public BannedAndUserDetail()
    //{
    //    UserDetailId = Convert.ToInt32(string.Empty);
    //    BannedId = Convert.ToInt32(string.Empty);
    //}
    public BannedAndUserDetail(int userDetailId, int bannedId, UserDetail userDetail, Banned banned, DateTime? beginingBanDate, DateTime? endingBanDate)
    {
        UserDetailId = userDetailId;
        BannedId = bannedId;
        UserDetail = userDetail;
        Banned = banned;
        BeginingBanDate = beginingBanDate;
        EndingBanDate = endingBanDate;
    }
    public BannedAndUserDetail(int id, int userDetailId, int bannedId, UserDetail userDetail, Banned banned, DateTime? beginingBanDate, DateTime? endingBanDate) : base(id)
    {
        Id = id;
        UserDetailId = userDetailId;
        BannedId = bannedId;
        UserDetail = userDetail;
        Banned = banned;
        BeginingBanDate = beginingBanDate;
        EndingBanDate = endingBanDate;
    }
}
