namespace Application.Feature.UserFeatures.UserOperationClaims.Dtos
{
    public class UserOperationClaimListDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
