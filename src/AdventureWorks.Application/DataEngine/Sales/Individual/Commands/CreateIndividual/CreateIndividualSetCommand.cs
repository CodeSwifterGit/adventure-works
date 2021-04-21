using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.CreateIndividual
{
    public partial class CreateIndividualSetCommand : IRequest<List<IndividualLookupModel>>
    {
        public List<BaseIndividual> Individuals { get; set; }

        public CreateIndividualSetCommand()
        {
        }

        public CreateIndividualSetCommand(List<BaseIndividual> model)
        {
            Individuals = model;
        }

        public partial class Handler : IRequestHandler<CreateIndividualSetCommand, List<IndividualLookupModel>>
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

            public async Task<List<IndividualLookupModel>> Handle(CreateIndividualSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<IndividualLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Individuals)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateIndividualCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}