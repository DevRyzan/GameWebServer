using Core.Persistence.Repositories; 

namespace Domain.Entities.Users;

public class Banned : Entity<int>
{
    public string? BanName { get; set; }
    public string? Description { get; set; }
    public int? BanHours { get; set; }
    public bool? IsBanned { get; set; }
    public bool? IsChatBan { get; set; } = false;
    public bool? IsVoiceBan { get; set; } = false;
    public bool? IsGameBan { get; set; } = false;
    //public DateTime? UpdatedDate { get; set; } 
    public Guid? UserId { get; set; }

    public Banned()
    {
    }

    //public Banned()
    //{
    //    BanName = string.Empty;
    //    Description = string.Empty;
    //    BanHours = Convert.ToInt32(string.Empty);
    //    IsBanned = false;
    //    IsChatBan = false;
    //    IsVoiceBan = false;
    //    IsGameBan = false;
    //}
    public Banned(string? banName, string? description, int? banHours, bool? isBanned, bool? isChatBan, bool? isVoiceBan, bool? isGameBan, Guid? userId)
    {
        BanName = banName;
        Description = description;
        BanHours = banHours;
        IsBanned = isBanned;
        IsChatBan = isChatBan;
        IsVoiceBan = isVoiceBan;
        IsGameBan = isGameBan;
        UserId = userId;
    }
    public Banned(int id, string? banName, string? description, int? banHours, bool? ısBanned, bool? ısChatBan, bool? ısVoiceBan, bool? ısGameBan, Guid? userId) : this
        ()

    {
        Id = id;
        BanName = banName;
        Description = description;
        BanHours = banHours;
        IsBanned = ısBanned;
        IsChatBan = ısChatBan;
        IsVoiceBan = ısVoiceBan;
        IsGameBan = ısGameBan;
        UserId = userId;
    }
}
