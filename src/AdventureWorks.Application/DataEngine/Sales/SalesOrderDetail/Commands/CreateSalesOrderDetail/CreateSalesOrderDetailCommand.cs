using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.CreateSalesOrderDetail
{
    public partial class CreateSalesOrderDetailCommand : BaseSalesOrderDetail, IRequest<SalesOrderDetailLookupModel>, IHaveCustomMapping
    {

        public CreateSalesOrderDetailCommand()
        {

        }

        public CreateSalesOrderDetailCommand(BaseSalesOrderDetail model, IMapper mapper)
        {
            mapper.Map<BaseSalesOrderDetail, CreateSalesOrderDetailCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderDetailCommand, SalesOrderDetailLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesOrderDetailsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesOrderDetailsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesOrderDetailLookupModel> Handle(CreateSalesOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesOrderDetailCommand, Entities.SalesOrderDetail>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesOrderDetails.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesOrderDetails.FindAsync(new object[] { entity.SalesOrderID, entity.SalesOrderDetailID }, cancellationToken);

                await _mediator.Publish(new SalesOrderDetailCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesOrderDetail, SalesOrderDetailLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderDetail, CreateSalesOrderDetailCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesOrderDetailCommand, Entities.SalesOrderDetail>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
