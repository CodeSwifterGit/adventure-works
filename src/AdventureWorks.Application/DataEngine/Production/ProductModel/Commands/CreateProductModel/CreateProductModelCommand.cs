using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.CreateProductModel
{
    public partial class CreateProductModelCommand : BaseProductModel, IRequest<ProductModelLookupModel>, IHaveCustomMapping
    {

        public CreateProductModelCommand()
        {

        }

        public CreateProductModelCommand(BaseProductModel model, IMapper mapper)
        {
            mapper.Map<BaseProductModel, CreateProductModelCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductModelCommand, ProductModelLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductModelsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductModelsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductModelLookupModel> Handle(CreateProductModelCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductModelCommand, Entities.ProductModel>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductModels.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductModels.FindAsync(new object[] { entity.ProductModelID }, cancellationToken);

                await _mediator.Publish(new ProductModelCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductModel, ProductModelLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModel, CreateProductModelCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductModelCommand, Entities.ProductModel>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
