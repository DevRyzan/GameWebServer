using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Update;

public class UpdatedPossibleRequestCommandResponse : IDto
{
    public int Id { get; set; }
    public string RequestName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public bool Status { get; set; }
    public DateTime? UpdatedDate { get; set; }

}
