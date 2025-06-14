﻿using Core.Application.Dtos;

namespace Application.Feature.UserFeatures.Users.Command.Update;

public class UpdatedUserCommandResponse : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public bool Status { get; set; }
}
