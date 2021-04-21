using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.CreateCountryRegion
{
    public partial class CreateCountryRegionSetCommand : IRequest<List<CountryRegionLookupModel>>
    {
        public List<BaseCountryRegion> CountryRegions { get; set; }

        public CreateCountryRegionSetCommand()
        {
        }

        public CreateCountryRegionSetCommand(List<BaseCountryRegion> model)
        {
            CountryRegions = model;
        }

        public partial class Handler : IRequestHandler<CreateCountryRegionSetCommand, List<CountryRegionLookupModel>>
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

            public async Task<List<CountryRegionLookupModel>> Handle(CreateCountryRegionSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CountryRegionLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.CountryRegions)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCountryRegionCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}