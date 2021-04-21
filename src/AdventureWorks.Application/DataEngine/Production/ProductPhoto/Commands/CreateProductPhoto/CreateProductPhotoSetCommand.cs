using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.CreateProductPhoto
{
    public partial class CreateProductPhotoSetCommand : IRequest<List<ProductPhotoLookupModel>>
    {
        public List<BaseProductPhoto> ProductPhotos { get; set; }

        public CreateProductPhotoSetCommand()
        {
        }

        public CreateProductPhotoSetCommand(List<BaseProductPhoto> model)
        {
            ProductPhotos = model;
        }

        public partial class Handler : IRequestHandler<CreateProductPhotoSetCommand, List<ProductPhotoLookupModel>>
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

            public async Task<List<ProductPhotoLookupModel>> Handle(CreateProductPhotoSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductPhotoLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductPhotos)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductPhotoCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}