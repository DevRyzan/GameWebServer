using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.UserFeatures.UserOperationClaims.Dtos
{
    public class UserOperationClaimDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
