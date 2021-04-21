using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.CreateProductModelProductDescriptionCulture
{
    public partial class CreateProductModelProductDescriptionCultureCommand : BaseProductModelProductDescriptionCulture, IRequest<ProductModelProductDescriptionCultureLookupModel>, IHaveCustomMapping
    {

        public CreateProductModelProductDescriptionCultureCommand()
        {

        }

        public CreateProductModelProductDescriptionCultureCommand(BaseProductModelProductDescriptionCulture model, IMapper mapper)
        {
            mapper.Map<BaseProductModelProductDescriptionCulture, CreateProductModelProductDescriptionCultureCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductModelProductDescriptionCultureCommand, ProductModelProductDescriptionCultureLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductModelProductDescriptionCulturesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductModelProductDescriptionCulturesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductModelProductDescriptionCultureLookupModel> Handle(CreateProductModelProductDescriptionCultureCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductModelProductDescriptionCultureCommand, Entities.ProductModelProductDescriptionCulture>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductModelProductDescriptionCultures.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductModelProductDescriptionCultures.FindAsync(new object[] { entity.ProductModelID, entity.ProductDescriptionID, entity.CultureID }, cancellationToken);

                await _mediator.Publish(new ProductModelProductDescriptionCultureCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModelProductDescriptionCulture, CreateProductModelProductDescriptionCultureCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductModelProductDescriptionCultureCommand, Entities.ProductModelProductDescriptionCulture>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
