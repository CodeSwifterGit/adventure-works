using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.CreateProductCategory
{
    public partial class CreateProductCategoryCommand : BaseProductCategory, IRequest<ProductCategoryLookupModel>, IHaveCustomMapping
    {

        public CreateProductCategoryCommand()
        {

        }

        public CreateProductCategoryCommand(BaseProductCategory model, IMapper mapper)
        {
            mapper.Map<BaseProductCategory, CreateProductCategoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductCategoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductCategoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductCategoryLookupModel> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductCategoryCommand, Entities.ProductCategory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductCategories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductCategories.FindAsync(new object[] { entity.ProductCategoryID }, cancellationToken);

                await _mediator.Publish(new ProductCategoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductCategory, ProductCategoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductCategory, CreateProductCategoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductCategoryCommand, Entities.ProductCategory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
