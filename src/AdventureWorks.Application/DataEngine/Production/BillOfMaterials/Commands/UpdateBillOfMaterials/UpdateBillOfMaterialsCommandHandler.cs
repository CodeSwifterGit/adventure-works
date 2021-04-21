using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.UpdateBillOfMaterials
{
    public partial class UpdateBillOfMaterialsCommandHandler : IRequestHandler<UpdateBillOfMaterialsCommand, BillOfMaterialsLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly BillOfMaterialsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateBillOfMaterialsCommandHandler(IAdventureWorksContext context,
            BillOfMaterialsQueryManager queryManager,
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

        public async Task<BillOfMaterialsLookupModel> Handle(UpdateBillOfMaterialsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.BillOfMaterials
                .SingleAsync(c => c.BillOfMaterialsID == request.RequestTarget.BillOfMaterialsID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.BillOfMaterials, UpdateBillOfMaterialsCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BillOfMaterials), JsonConvert.SerializeObject(new { request.RequestTarget.BillOfMaterialsID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.BillOfMaterials.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.BillOfMaterials.SingleAsync(c => c.BillOfMaterialsID == request.RequestTarget.BillOfMaterialsID, cancellationToken);

            await _mediator.Publish(new BillOfMaterialsUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.BillOfMaterials, BillOfMaterialsLookupModel>(entity);
        }
    }
}
