using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.CreateCurrency
{
    public partial class CreateCurrencyCommand : BaseCurrency, IRequest<CurrencyLookupModel>, IHaveCustomMapping
    {

        public CreateCurrencyCommand()
        {

        }

        public CreateCurrencyCommand(BaseCurrency model, IMapper mapper)
        {
            mapper.Map<BaseCurrency, CreateCurrencyCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCurrencyCommand, CurrencyLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CurrenciesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CurrenciesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CurrencyLookupModel> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCurrencyCommand, Entities.Currency>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Currencies.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Currencies.FindAsync(new object[] { entity.CurrencyCode }, cancellationToken);

                await _mediator.Publish(new CurrencyCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Currency, CurrencyLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCurrency, CreateCurrencyCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCurrencyCommand, Entities.Currency>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
