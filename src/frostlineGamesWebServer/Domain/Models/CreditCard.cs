using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class CreditCard
{
    public int Id { get; set; }

    public string NameOnCard { get; set; } = null!;

    public int CardNumber { get; set; }

    public int CardValidMonthDate { get; set; }

    public int CardValidYearDate { get; set; }

    public int Cvv { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
