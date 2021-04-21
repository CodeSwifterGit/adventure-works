using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterialsDetail
{
    public partial class GetBillOfMaterialsDetailQueryHandler : IRequestHandler<GetBillOfMaterialsDetailQuery, BillOfMaterialsLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetBillOfMaterialsDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BillOfMaterialsLookupModel> Handle(GetBillOfMaterialsDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.BillOfMaterials
                .FindAsync(new object[] { request.BillOfMaterialsID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.BillOfMaterials, BillOfMaterialsLookupModel>(entity);
        }
    }
}
