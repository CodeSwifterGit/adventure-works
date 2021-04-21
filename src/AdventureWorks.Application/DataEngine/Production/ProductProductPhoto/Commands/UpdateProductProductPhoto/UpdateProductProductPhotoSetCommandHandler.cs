using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto
{
    public partial class
        UpdateProductProductPhotoSetCommandHandler : IRequestHandler<UpdateProductProductPhotoSetCommand, List<ProductProductPhotoLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateProductProductPhotoSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<ProductProductPhotoLookupModel>> Handle(UpdateProductProductPhotoSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<ProductProductPhotoLookupModel>();
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