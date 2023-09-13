using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using Application.Services.SupportRequestServices.PossibleRequestService;
using Application.Services.SupportRequestServices.TagService;
using AutoMapper;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants.OperationClaim;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Update;

public class UpdatePossibleRequestAndTagCommand : IRequest<UpdatedPossibleRequestAndTagDto>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }

    public string[] Roles => new[] { Admin, PossibleRequestAndTagUpdate };


    public TimeSpan? SlidingExpiration { get; }
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequestAndTags";
    public class UpdatePossibleRequestAndTagCommandHandler : IRequestHandler<UpdatePossibleRequestAndTagCommand, UpdatedPossibleRequestAndTagDto>
    {
        private readonly IPossibleRequestService _possibleRequestService;
        private readonly ITagService _tagService;
        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

        public UpdatePossibleRequestAndTagCommandHandler(IPossibleRequestService possibleRequestService, ITagService tagService, IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
        {
            _possibleRequestService = possibleRequestService;
            _tagService = tagService;
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
        }

        public async Task<UpdatedPossibleRequestAndTagDto> Handle(UpdatePossibleRequestAndTagCommand request, CancellationToken cancellationToken)
        {

            await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagIdShouldBeExist(request.Id);

            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestService.GetById(request.Id);
            possibleRequestAndTag.Status = request.Status;
            possibleRequestAndTag.PossibleRequestId = request.PossibleRequestId;
            possibleRequestAndTag.TagId = request.TagId;

            PossibleRequestAndTag updatedPossibleRequestAndTag = await _possibleRequestAndTagService.Update(possibleRequestAndTag);

            UpdatedPossibleRequestAndTagDto updatedPossibleRequestAndTagDto = _mapper.Map<UpdatedPossibleRequestAndTagDto>(updatedPossibleRequestAndTag);
            updatedPossibleRequestAndTagDto.UpdatedDate = DateTime.UtcNow;

            return updatedPossibleRequestAndTagDto;

        }
    }
}
