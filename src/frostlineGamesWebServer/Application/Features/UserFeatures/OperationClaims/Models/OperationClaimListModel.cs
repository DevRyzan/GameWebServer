using Application.Feature.UserFeatures.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.UserFeatures.OperationClaims.Models
{
    public class OperationClaimListModel
    {
        public IList<OperationClaimListDto> Items { get; set; }

    }
}
