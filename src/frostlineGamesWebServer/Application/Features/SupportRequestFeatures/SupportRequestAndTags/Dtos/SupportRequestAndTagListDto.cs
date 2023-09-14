namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;

public class SupportRequestAndTagListDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int TagId { get; set; }

    public SupportRequestAndTagListDto()
    {

    }

    public SupportRequestAndTagListDto(int id, int requestId, int tagId)
    {
        Id = id;
        RequestId = requestId;
        TagId = tagId;
    }
}
