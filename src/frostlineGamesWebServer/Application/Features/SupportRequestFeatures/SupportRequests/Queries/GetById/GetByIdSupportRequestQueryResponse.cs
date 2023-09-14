using Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetById;

public class GetByIdSupportRequestQueryResponse : IDto
{
    public int Id { get; set; }
    public string? SupportRequestTitle { get; set; }
    public string? SupportRequestCoomment { get; set; }
    public Guid UserId { get; set; }
    public string? UserEmail { get; set; }
    public string? UserNickName { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }
    public bool? Status { get; set; }
    public int? SupportRequestCategoryId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
