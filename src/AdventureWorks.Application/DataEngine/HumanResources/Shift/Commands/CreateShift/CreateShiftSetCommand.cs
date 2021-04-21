using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.CreateShift
{
    public partial class CreateShiftSetCommand : IRequest<List<ShiftLookupModel>>
    {
        public List<BaseShift> Shifts { get; set; }

        public CreateShiftSetCommand()
        {
        }

        public CreateShiftSetCommand(List<BaseShift> model)
        {
            Shifts = model;
        }

        public partial class Handler : IRequestHandler<CreateShiftSetCommand, List<ShiftLookupModel>>
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

            public async Task<List<ShiftLookupModel>> Handle(CreateShiftSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ShiftLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Shifts)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateShiftCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}