using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.CreateErrorLog
{
    public partial class CreateErrorLogSetCommand : IRequest<List<ErrorLogLookupModel>>
    {
        public List<BaseErrorLog> ErrorLogs { get; set; }

        public CreateErrorLogSetCommand()
        {
        }

        public CreateErrorLogSetCommand(List<BaseErrorLog> model)
        {
            ErrorLogs = model;
        }

        public partial class Handler : IRequestHandler<CreateErrorLogSetCommand, List<ErrorLogLookupModel>>
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

            public async Task<List<ErrorLogLookupModel>> Handle(CreateErrorLogSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ErrorLogLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ErrorLogs)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateErrorLogCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}