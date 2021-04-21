using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.UpdateCountryRegionCurrency
{
    public partial class UpdateCountryRegionCurrencyCommandHandler : IRequestHandler<UpdateCountryRegionCurrencyCommand, CountryRegionCurrencyLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly CountryRegionCurrenciesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateCountryRegionCurrencyCommandHandler(IAdventureWorksContext context,
            CountryRegionCurrenciesQueryManager queryManager,
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

        public async Task<CountryRegionCurrencyLookupModel> Handle(UpdateCountryRegionCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CountryRegionCurrencies
                .SingleAsync(c => c.CountryRegionCode == request.RequestTarget.CountryRegionCode && c.CurrencyCode == request.RequestTarget.CurrencyCode, cancellationToken);
            var oldEntity = _mapper.Map<Entities.CountryRegionCurrency, UpdateCountryRegionCurrencyCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CountryRegionCurrency), JsonConvert.SerializeObject(new { request.RequestTarget.CountryRegionCode, request.RequestTarget.CurrencyCode }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.CountryRegionCurrencies.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.CountryRegionCurrencies.SingleAsync(c => c.CountryRegionCode == request.RequestTarget.CountryRegionCode && c.CurrencyCode == request.RequestTarget.CurrencyCode, cancellationToken);

            await _mediator.Publish(new CountryRegionCurrencyUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.CountryRegionCurrency, CountryRegionCurrencyLookupModel>(entity);
        }
    }
}
