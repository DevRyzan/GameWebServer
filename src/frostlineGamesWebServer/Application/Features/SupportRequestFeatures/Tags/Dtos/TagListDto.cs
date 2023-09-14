using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Dtos
{
    public class TagListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TagPriority TagPriority { get; set; }

        public TagListDto()
        {

        }

        public TagListDto(int ıd, string? name, string? description, TagPriority tagPriority)
        {
            Id = ıd;
            Name = name;
            Description = description;
            TagPriority = tagPriority;
        }
    }
}
