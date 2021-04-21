using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.UpdateSalesTaxRate
{
    public partial class UpdateSalesTaxRateCommandHandler : IRequestHandler<UpdateSalesTaxRateCommand, SalesTaxRateLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesTaxRatesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesTaxRateCommandHandler(IAdventureWorksContext context,
            SalesTaxRatesQueryManager queryManager,
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

        public async Task<SalesTaxRateLookupModel> Handle(UpdateSalesTaxRateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTaxRates
                .SingleAsync(c => c.SalesTaxRateID == request.RequestTarget.SalesTaxRateID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesTaxRate, UpdateSalesTaxRateCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesTaxRate), JsonConvert.SerializeObject(new { request.RequestTarget.SalesTaxRateID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesTaxRates.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesTaxRates.SingleAsync(c => c.SalesTaxRateID == request.RequestTarget.SalesTaxRateID, cancellationToken);

            await _mediator.Publish(new SalesTaxRateUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesTaxRate, SalesTaxRateLookupModel>(entity);
        }
    }
}
