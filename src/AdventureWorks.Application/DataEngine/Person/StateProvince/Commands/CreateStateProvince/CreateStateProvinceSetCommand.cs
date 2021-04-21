using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.CreateStateProvince
{
    public partial class CreateStateProvinceSetCommand : IRequest<List<StateProvinceLookupModel>>
    {
        public List<BaseStateProvince> StateProvinces { get; set; }

        public CreateStateProvinceSetCommand()
        {
        }

        public CreateStateProvinceSetCommand(List<BaseStateProvince> model)
        {
            StateProvinces = model;
        }

        public partial class Handler : IRequestHandler<CreateStateProvinceSetCommand, List<StateProvinceLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<StateProvinceLookupModel>> Handle(CreateStateProvinceSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<StateProvinceLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.StateProvinces)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateStateProvinceCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}