﻿using Core.Application.Dtos;

namespace Application.Features.TeamFeatures.Employees.Queries.GetByUserId
{
    public class GetByUserIdEmployeeQueryResponse : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserImagePath { get; set; }
        public string? Code { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
