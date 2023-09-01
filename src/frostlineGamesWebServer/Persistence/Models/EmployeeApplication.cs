using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class EmployeeApplication
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? CvUrl { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
