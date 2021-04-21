using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotoDetail
{
    public partial class GetProductPhotoDetailQueryHandler : IRequestHandler<GetProductPhotoDetailQuery, ProductPhotoLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductPhotoDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductPhotoLookupModel> Handle(GetProductPhotoDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductPhotos
                .FindAsync(new object[] { request.ProductPhotoID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductPhoto, ProductPhotoLookupModel>(entity);
        }
    }
}
