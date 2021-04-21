using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.CreateProductListPriceHistory
{
    public partial class CreateProductListPriceHistoryCommand : BaseProductListPriceHistory, IRequest<ProductListPriceHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateProductListPriceHistoryCommand()
        {

        }

        public CreateProductListPriceHistoryCommand(BaseProductListPriceHistory model, IMapper mapper)
        {
            mapper.Map<BaseProductListPriceHistory, CreateProductListPriceHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductListPriceHistoryCommand, ProductListPriceHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductListPriceHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductListPriceHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductListPriceHistoryLookupModel> Handle(CreateProductListPriceHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductListPriceHistoryCommand, Entities.ProductListPriceHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductListPriceHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductListPriceHistories.FindAsync(new object[] { entity.ProductID, entity.StartDate }, cancellationToken);

                await _mediator.Publish(new ProductListPriceHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductListPriceHistory, ProductListPriceHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductListPriceHistory, CreateProductListPriceHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductListPriceHistoryCommand, Entities.ProductListPriceHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
