﻿using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Commands.Create
{
    public class CreateTagCommandResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public TagPriority TagPriority { get; set; }
    }
}
