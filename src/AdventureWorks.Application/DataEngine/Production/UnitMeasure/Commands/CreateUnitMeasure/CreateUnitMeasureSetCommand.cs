using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.CreateUnitMeasure
{
    public partial class CreateUnitMeasureSetCommand : IRequest<List<UnitMeasureLookupModel>>
    {
        public List<BaseUnitMeasure> UnitMeasures { get; set; }

        public CreateUnitMeasureSetCommand()
        {
        }

        public CreateUnitMeasureSetCommand(List<BaseUnitMeasure> model)
        {
            UnitMeasures = model;
        }

        public partial class Handler : IRequestHandler<CreateUnitMeasureSetCommand, List<UnitMeasureLookupModel>>
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

            public async Task<List<UnitMeasureLookupModel>> Handle(CreateUnitMeasureSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<UnitMeasureLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.UnitMeasures)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateUnitMeasureCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}