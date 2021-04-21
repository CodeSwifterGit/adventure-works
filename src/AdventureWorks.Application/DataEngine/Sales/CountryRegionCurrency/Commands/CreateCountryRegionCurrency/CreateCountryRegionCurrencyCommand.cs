using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.CreateCountryRegionCurrency
{
    public partial class CreateCountryRegionCurrencyCommand : BaseCountryRegionCurrency, IRequest<CountryRegionCurrencyLookupModel>, IHaveCustomMapping
    {

        public CreateCountryRegionCurrencyCommand()
        {

        }

        public CreateCountryRegionCurrencyCommand(BaseCountryRegionCurrency model, IMapper mapper)
        {
            mapper.Map<BaseCountryRegionCurrency, CreateCountryRegionCurrencyCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCountryRegionCurrencyCommand, CountryRegionCurrencyLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CountryRegionCurrenciesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CountryRegionCurrenciesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CountryRegionCurrencyLookupModel> Handle(CreateCountryRegionCurrencyCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCountryRegionCurrencyCommand, Entities.CountryRegionCurrency>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.CountryRegionCurrencies.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.CountryRegionCurrencies.FindAsync(new object[] { entity.CountryRegionCode, entity.CurrencyCode }, cancellationToken);

                await _mediator.Publish(new CountryRegionCurrencyCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.CountryRegionCurrency, CountryRegionCurrencyLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCountryRegionCurrency, CreateCountryRegionCurrencyCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCountryRegionCurrencyCommand, Entities.CountryRegionCurrency>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
