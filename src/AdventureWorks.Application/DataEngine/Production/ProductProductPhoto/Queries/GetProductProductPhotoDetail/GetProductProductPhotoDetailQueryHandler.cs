using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotoDetail
{
    public partial class GetProductProductPhotoDetailQueryHandler : IRequestHandler<GetProductProductPhotoDetailQuery, ProductProductPhotoLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductProductPhotoDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductProductPhotoLookupModel> Handle(GetProductProductPhotoDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductProductPhotos
                .FindAsync(new object[] { request.ProductID, request.ProductPhotoID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductProductPhoto, ProductProductPhotoLookupModel>(entity);
        }
    }
}
