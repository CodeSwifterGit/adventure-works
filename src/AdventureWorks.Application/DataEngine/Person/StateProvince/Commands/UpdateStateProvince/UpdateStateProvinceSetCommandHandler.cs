using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class
        UpdateStateProvinceSetCommandHandler : IRequestHandler<UpdateStateProvinceSetCommand, List<StateProvinceLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateStateProvinceSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<StateProvinceLookupModel>> Handle(UpdateStateProvinceSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<StateProvinceLookupModel>();
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var singleRequest in request.Commands)
                {
                    var singleUpdateResult = await _mediator.Send(singleRequest, cancellationToken);
                    result.Add(singleUpdateResult);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            return result;
        }
    }
}