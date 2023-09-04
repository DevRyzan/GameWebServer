using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class File
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string Storage { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual AbilityImageFile? AbilityImageFile { get; set; }

    public virtual BardImageFİle? BardImageFİle { get; set; }

    public virtual ProductImageFile? ProductImageFile { get; set; }

    public virtual UserDetailImageFile? UserDetailImageFile { get; set; }
}
