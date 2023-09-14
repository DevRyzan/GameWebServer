using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetActiveListByCreatedDate;

public class GetActiveListByCreatedDateQueryResponse
{
    public int Id { get; set; }
    public string RequestName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public string SupportRequestCategoryName { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
