using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.CreateTransactionHistoryArchive
{
    public partial class CreateTransactionHistoryArchiveSetCommand : IRequest<List<TransactionHistoryArchiveLookupModel>>
    {
        public List<BaseTransactionHistoryArchive> TransactionHistoryArchives { get; set; }

        public CreateTransactionHistoryArchiveSetCommand()
        {
        }

        public CreateTransactionHistoryArchiveSetCommand(List<BaseTransactionHistoryArchive> model)
        {
            TransactionHistoryArchives = model;
        }

        public partial class Handler : IRequestHandler<CreateTransactionHistoryArchiveSetCommand, List<TransactionHistoryArchiveLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<TransactionHistoryArchiveLookupModel>> Handle(CreateTransactionHistoryArchiveSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<TransactionHistoryArchiveLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.TransactionHistoryArchives)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateTransactionHistoryArchiveCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}