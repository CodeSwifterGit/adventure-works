using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.UpdateSalesOrderDetail
{
    public partial class UpdateSalesOrderDetailCommandHandler : IRequestHandler<UpdateSalesOrderDetailCommand, SalesOrderDetailLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesOrderDetailsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesOrderDetailCommandHandler(IAdventureWorksContext context,
            SalesOrderDetailsQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<SalesOrderDetailLookupModel> Handle(UpdateSalesOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderDetails
                .SingleAsync(c => c.SalesOrderID == request.RequestTarget.SalesOrderID && c.SalesOrderDetailID == request.RequestTarget.SalesOrderDetailID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesOrderDetail, UpdateSalesOrderDetailCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesOrderDetail), JsonConvert.SerializeObject(new { request.RequestTarget.SalesOrderID, request.RequestTarget.SalesOrderDetailID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesOrderDetails.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesOrderDetails.SingleAsync(c => c.SalesOrderID == request.RequestTarget.SalesOrderID && c.SalesOrderDetailID == request.RequestTarget.SalesOrderDetailID, cancellationToken);

            await _mediator.Publish(new SalesOrderDetailUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesOrderDetail, SalesOrderDetailLookupModel>(entity);
        }
    }
}
