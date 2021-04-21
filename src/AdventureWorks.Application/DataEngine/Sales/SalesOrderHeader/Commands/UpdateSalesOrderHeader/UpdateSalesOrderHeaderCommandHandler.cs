using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.UpdateSalesOrderHeader
{
    public partial class UpdateSalesOrderHeaderCommandHandler : IRequestHandler<UpdateSalesOrderHeaderCommand, SalesOrderHeaderLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesOrderHeadersQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesOrderHeaderCommandHandler(IAdventureWorksContext context,
            SalesOrderHeadersQueryManager queryManager,
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

        public async Task<SalesOrderHeaderLookupModel> Handle(UpdateSalesOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderHeaders
                .SingleAsync(c => c.SalesOrderID == request.RequestTarget.SalesOrderID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesOrderHeader, UpdateSalesOrderHeaderCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesOrderHeader), JsonConvert.SerializeObject(new { request.RequestTarget.SalesOrderID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesOrderHeaders.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesOrderHeaders.SingleAsync(c => c.SalesOrderID == request.RequestTarget.SalesOrderID, cancellationToken);

            await _mediator.Publish(new SalesOrderHeaderUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesOrderHeader, SalesOrderHeaderLookupModel>(entity);
        }
    }
}
