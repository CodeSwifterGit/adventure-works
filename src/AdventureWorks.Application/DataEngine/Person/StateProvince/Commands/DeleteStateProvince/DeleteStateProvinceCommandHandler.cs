using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.DeleteStateProvince
{
    public partial class DeleteStateProvinceCommandHandler : IRequestHandler<DeleteStateProvinceCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private StateProvincesQueryManager _queryManager;

        public DeleteStateProvinceCommandHandler(IAdventureWorksContext context, IMediator mediator, StateProvincesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteStateProvinceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.StateProvinces
                .FirstOrDefaultAsync(c => c.StateProvinceID == request.StateProvinceID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.StateProvince), JsonConvert.SerializeObject(new { request.StateProvinceID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new StateProvinceDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
