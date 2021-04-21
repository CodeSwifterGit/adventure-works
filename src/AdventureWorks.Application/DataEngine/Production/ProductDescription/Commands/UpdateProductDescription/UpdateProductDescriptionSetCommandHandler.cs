using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription
{
    public partial class
        UpdateProductDescriptionSetCommandHandler : IRequestHandler<UpdateProductDescriptionSetCommand, List<ProductDescriptionLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateProductDescriptionSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<ProductDescriptionLookupModel>> Handle(UpdateProductDescriptionSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<ProductDescriptionLookupModel>();
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