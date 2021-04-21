using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.CreateSalesTaxRate
{
    public partial class CreateSalesTaxRateCommand : BaseSalesTaxRate, IRequest<SalesTaxRateLookupModel>, IHaveCustomMapping
    {

        public CreateSalesTaxRateCommand()
        {

        }

        public CreateSalesTaxRateCommand(BaseSalesTaxRate model, IMapper mapper)
        {
            mapper.Map<BaseSalesTaxRate, CreateSalesTaxRateCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesTaxRateCommand, SalesTaxRateLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesTaxRatesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesTaxRatesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesTaxRateLookupModel> Handle(CreateSalesTaxRateCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesTaxRateCommand, Entities.SalesTaxRate>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesTaxRates.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesTaxRates.FindAsync(new object[] { entity.SalesTaxRateID }, cancellationToken);

                await _mediator.Publish(new SalesTaxRateCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesTaxRate, SalesTaxRateLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesTaxRate, CreateSalesTaxRateCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesTaxRateCommand, Entities.SalesTaxRate>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
