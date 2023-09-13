namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;

public class UpdatedSupportRequestAndTagDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int TagId { get; set; }

    public UpdatedSupportRequestAndTagDto()
    {

    }

    public UpdatedSupportRequestAndTagDto(int id, int requestId, int tagId)
    {
        Id = id;
        RequestId = requestId;
        TagId = tagId;
    }
}
