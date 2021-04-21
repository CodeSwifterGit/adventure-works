using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason
{
    public partial class UpdateSalesReasonCommandHandler : IRequestHandler<UpdateSalesReasonCommand, SalesReasonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesReasonsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesReasonCommandHandler(IAdventureWorksContext context,
            SalesReasonsQueryManager queryManager,
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

        public async Task<SalesReasonLookupModel> Handle(UpdateSalesReasonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesReasons
                .SingleAsync(c => c.SalesReasonID == request.RequestTarget.SalesReasonID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesReason, UpdateSalesReasonCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesReason), JsonConvert.SerializeObject(new { request.RequestTarget.SalesReasonID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesReasons.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesReasons.SingleAsync(c => c.SalesReasonID == request.RequestTarget.SalesReasonID, cancellationToken);

            await _mediator.Publish(new SalesReasonUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesReason, SalesReasonLookupModel>(entity);
        }
    }
}
