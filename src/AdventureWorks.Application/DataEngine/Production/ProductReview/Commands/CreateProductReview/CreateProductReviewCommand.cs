using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.CreateProductReview
{
    public partial class CreateProductReviewCommand : BaseProductReview, IRequest<ProductReviewLookupModel>, IHaveCustomMapping
    {

        public CreateProductReviewCommand()
        {

        }

        public CreateProductReviewCommand(BaseProductReview model, IMapper mapper)
        {
            mapper.Map<BaseProductReview, CreateProductReviewCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductReviewCommand, ProductReviewLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductReviewsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductReviewsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductReviewLookupModel> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductReviewCommand, Entities.ProductReview>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductReviews.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductReviews.FindAsync(new object[] { entity.ProductReviewID }, cancellationToken);

                await _mediator.Publish(new ProductReviewCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductReview, ProductReviewLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductReview, CreateProductReviewCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductReviewCommand, Entities.ProductReview>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
