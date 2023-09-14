namespace Application.Features.SupportRequestFeatures.Tags.Dtos
{
    public class UpdatedTagDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public UpdatedTagDto()
        {

        }

        public UpdatedTagDto(string? name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
