namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.Delete;
public class DeleteSupportRequestAndTagCommandResponse
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int TagId { get; set; }
        public bool Status { get; set; }
    }

