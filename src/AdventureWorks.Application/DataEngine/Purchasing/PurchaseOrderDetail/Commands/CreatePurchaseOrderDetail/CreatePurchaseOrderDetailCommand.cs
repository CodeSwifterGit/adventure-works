using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.CreatePurchaseOrderDetail
{
    public partial class CreatePurchaseOrderDetailCommand : BasePurchaseOrderDetail, IRequest<PurchaseOrderDetailLookupModel>, IHaveCustomMapping
    {

        public CreatePurchaseOrderDetailCommand()
        {

        }

        public CreatePurchaseOrderDetailCommand(BasePurchaseOrderDetail model, IMapper mapper)
        {
            mapper.Map<BasePurchaseOrderDetail, CreatePurchaseOrderDetailCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreatePurchaseOrderDetailCommand, PurchaseOrderDetailLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly PurchaseOrderDetailsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                PurchaseOrderDetailsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<PurchaseOrderDetailLookupModel> Handle(CreatePurchaseOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreatePurchaseOrderDetailCommand, Entities.PurchaseOrderDetail>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.PurchaseOrderDetails.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.PurchaseOrderDetails.FindAsync(new object[] { entity.PurchaseOrderID, entity.PurchaseOrderDetailID }, cancellationToken);

                await _mediator.Publish(new PurchaseOrderDetailCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.PurchaseOrderDetail, PurchaseOrderDetailLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BasePurchaseOrderDetail, CreatePurchaseOrderDetailCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreatePurchaseOrderDetailCommand, Entities.PurchaseOrderDetail>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
