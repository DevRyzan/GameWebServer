namespace Core.Security.Dtos;

public class IsRemovedDto
{
    public int Id { get; set; }

    public bool IsRemoved { get; set; }

    public IsRemovedDto()
    {
    }

    public IsRemovedDto(bool isRemoved, int id)
    {
        IsRemoved = isRemoved;
        Id = id;
    }

}
