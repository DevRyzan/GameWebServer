namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;

public class SupportRequestAndTagDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int TagId { get; set; }

    public SupportRequestAndTagDto()
    {

    }

    public SupportRequestAndTagDto(int id, int requestId, int tagId)
    {
        Id = id;
        RequestId = requestId;
        TagId = tagId;
    }
}
