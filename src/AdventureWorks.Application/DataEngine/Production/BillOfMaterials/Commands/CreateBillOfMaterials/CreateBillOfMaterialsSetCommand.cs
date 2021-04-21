using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.CreateBillOfMaterials
{
    public partial class CreateBillOfMaterialsSetCommand : IRequest<List<BillOfMaterialsLookupModel>>
    {
        public List<BaseBillOfMaterials> BillOfMaterials { get; set; }

        public CreateBillOfMaterialsSetCommand()
        {
        }

        public CreateBillOfMaterialsSetCommand(List<BaseBillOfMaterials> model)
        {
            BillOfMaterials = model;
        }

        public partial class Handler : IRequestHandler<CreateBillOfMaterialsSetCommand, List<BillOfMaterialsLookupModel>>
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

            public async Task<List<BillOfMaterialsLookupModel>> Handle(CreateBillOfMaterialsSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<BillOfMaterialsLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.BillOfMaterials)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateBillOfMaterialsCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}