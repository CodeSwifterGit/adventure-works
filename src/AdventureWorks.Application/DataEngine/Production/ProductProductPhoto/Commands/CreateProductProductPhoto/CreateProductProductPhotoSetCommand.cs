using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.CreateProductProductPhoto
{
    public partial class CreateProductProductPhotoSetCommand : IRequest<List<ProductProductPhotoLookupModel>>
    {
        public List<BaseProductProductPhoto> ProductProductPhotos { get; set; }

        public CreateProductProductPhotoSetCommand()
        {
        }

        public CreateProductProductPhotoSetCommand(List<BaseProductProductPhoto> model)
        {
            ProductProductPhotos = model;
        }

        public partial class Handler : IRequestHandler<CreateProductProductPhotoSetCommand, List<ProductProductPhotoLookupModel>>
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

            public async Task<List<ProductProductPhotoLookupModel>> Handle(CreateProductProductPhotoSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductProductPhotoLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductProductPhotos)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductProductPhotoCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}