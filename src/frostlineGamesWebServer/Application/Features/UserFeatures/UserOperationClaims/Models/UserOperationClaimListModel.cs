using Application.Feature.UserFeatures.UserOperationClaims.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.UserFeatures.UserOperationClaims.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
