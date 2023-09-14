using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;
using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Rules;
using Application.Services.SupportRequestServices.PossibleRequestAndTagService;
using AutoMapper;
using Core.Application.Caching;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using Domain.Entities.SupportRequests;
using MediatR;
using static Domain.Constants.OperationClaims;
using static Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Constants.OperationClaim;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.Delete;

public class DeletePossibleRequestAndTagCommand : IRequest<DeletedPossibleRequestAndTagDto>, ISecuredRequest, ITransactionalRequest, ICacheRemoverRequest
{
    public int Id { get; set; }


    public string[] Roles => new[] { Admin, PossibleRequestAndTagDelete };


    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetPossibleRequestAndTags";
    public class DeletePossibleRequestAndTagCommandHandler : IRequestHandler<DeletePossibleRequestAndTagCommand, DeletedPossibleRequestAndTagDto>
    {

        private readonly IPossibleRequestAndTagService _possibleRequestAndTagService;
        private readonly IMapper _mapper;
        private readonly PossibleRequestAndTagBusinessRules _possibleRequestAndTagBusinessRules;

        public DeletePossibleRequestAndTagCommandHandler(IPossibleRequestAndTagService possibleRequestAndTagService, IMapper mapper, PossibleRequestAndTagBusinessRules possibleRequestAndTagBusinessRules)
        {
            _possibleRequestAndTagService = possibleRequestAndTagService;
            _mapper = mapper;
            _possibleRequestAndTagBusinessRules = possibleRequestAndTagBusinessRules;
        }

        public async Task<DeletedPossibleRequestAndTagDto> Handle(DeletePossibleRequestAndTagCommand request, CancellationToken cancellationToken)
        {

            await _possibleRequestAndTagBusinessRules.PossibleRequestAndTagIdShouldBeExist(request.Id);
            PossibleRequestAndTag possibleRequestAndTag = await _possibleRequestAndTagService.GetById(request.Id);

            possibleRequestAndTag.Status = false;
            possibleRequestAndTag.DeletedDate = DateTime.UtcNow;

            PossibleRequestAndTag deletedPossibleRequestAndTag = await _possibleRequestAndTagService.Delete(possibleRequestAndTag);


            DeletedPossibleRequestAndTagDto deletedPossibleRequestAndTagDto = _mapper.Map<DeletedPossibleRequestAndTagDto>(deletedPossibleRequestAndTag);
            deletedPossibleRequestAndTagDto.PossibleRequestId = deletedPossibleRequestAndTag.PossibleRequestId;
            deletedPossibleRequestAndTagDto.TagId = deletedPossibleRequestAndTag.TagId;
            deletedPossibleRequestAndTagDto.Status = deletedPossibleRequestAndTag.Status;


            return deletedPossibleRequestAndTagDto;


        }
    }
}