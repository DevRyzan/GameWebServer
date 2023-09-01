using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ContactU
{
    public int Id { get; set; }

    public string Header { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string AdressName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContactMail { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
