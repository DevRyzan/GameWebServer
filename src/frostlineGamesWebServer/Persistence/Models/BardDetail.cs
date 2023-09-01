using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class BardDetail
{
    public int Id { get; set; }

    public int BardId { get; set; }

    public string BackgroundUrl { get; set; } = null!;

    public int Level { get; set; }

    public int LevelScore { get; set; }

    public int Xp { get; set; }

    public int ContribitionPoint { get; set; }

    public int Credit { get; set; }

    public int GamCredit { get; set; }

    public int GameMatchQuantity { get; set; }

    public double GamePlayHour { get; set; }

    public int EloRank { get; set; }

    public int WonQuantity { get; set; }

    public int LostQuantity { get; set; }

    public bool IsOnline { get; set; }

    public bool IsInGame { get; set; }

    public DateTime? LoggedDate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Bard Bard { get; set; } = null!;
}
