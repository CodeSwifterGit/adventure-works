using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.CreateCurrencyRate
{
    public partial class CreateCurrencyRateCommand : BaseCurrencyRate, IRequest<CurrencyRateLookupModel>, IHaveCustomMapping
    {

        public CreateCurrencyRateCommand()
        {

        }

        public CreateCurrencyRateCommand(BaseCurrencyRate model, IMapper mapper)
        {
            mapper.Map<BaseCurrencyRate, CreateCurrencyRateCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCurrencyRateCommand, CurrencyRateLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CurrencyRatesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CurrencyRatesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CurrencyRateLookupModel> Handle(CreateCurrencyRateCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCurrencyRateCommand, Entities.CurrencyRate>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.CurrencyRates.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.CurrencyRates.FindAsync(new object[] { entity.CurrencyRateID }, cancellationToken);

                await _mediator.Publish(new CurrencyRateCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.CurrencyRate, CurrencyRateLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCurrencyRate, CreateCurrencyRateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCurrencyRateCommand, Entities.CurrencyRate>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
