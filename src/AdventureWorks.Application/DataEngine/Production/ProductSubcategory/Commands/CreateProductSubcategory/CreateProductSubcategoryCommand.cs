using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.CreateProductSubcategory
{
    public partial class CreateProductSubcategoryCommand : BaseProductSubcategory, IRequest<ProductSubcategoryLookupModel>, IHaveCustomMapping
    {

        public CreateProductSubcategoryCommand()
        {

        }

        public CreateProductSubcategoryCommand(BaseProductSubcategory model, IMapper mapper)
        {
            mapper.Map<BaseProductSubcategory, CreateProductSubcategoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductSubcategoryCommand, ProductSubcategoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductSubcategoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductSubcategoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductSubcategoryLookupModel> Handle(CreateProductSubcategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductSubcategoryCommand, Entities.ProductSubcategory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductSubcategories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductSubcategories.FindAsync(new object[] { entity.ProductSubcategoryID }, cancellationToken);

                await _mediator.Publish(new ProductSubcategoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductSubcategory, ProductSubcategoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductSubcategory, CreateProductSubcategoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductSubcategoryCommand, Entities.ProductSubcategory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
