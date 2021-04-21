using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.UpdateTransactionHistoryArchive
{
    public partial class
        UpdateTransactionHistoryArchiveSetCommandHandler : IRequestHandler<UpdateTransactionHistoryArchiveSetCommand, List<TransactionHistoryArchiveLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateTransactionHistoryArchiveSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<TransactionHistoryArchiveLookupModel>> Handle(UpdateTransactionHistoryArchiveSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<TransactionHistoryArchiveLookupModel>();
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var singleRequest in request.Commands)
                {
                    var singleUpdateResult = await _mediator.Send(singleRequest, cancellationToken);
                    result.Add(singleUpdateResult);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            return result;
        }
    }
}