using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.CreateLocation
{
    public partial class CreateLocationSetCommand : IRequest<List<LocationLookupModel>>
    {
        public List<BaseLocation> Locations { get; set; }

        public CreateLocationSetCommand()
        {
        }

        public CreateLocationSetCommand(List<BaseLocation> model)
        {
            Locations = model;
        }

        public partial class Handler : IRequestHandler<CreateLocationSetCommand, List<LocationLookupModel>>
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

            public async Task<List<LocationLookupModel>> Handle(CreateLocationSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<LocationLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Locations)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateLocationCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}