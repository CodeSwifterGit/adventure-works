using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.CreateProductModelIllustration
{
    public partial class CreateProductModelIllustrationCommand : BaseProductModelIllustration, IRequest<ProductModelIllustrationLookupModel>, IHaveCustomMapping
    {

        public CreateProductModelIllustrationCommand()
        {

        }

        public CreateProductModelIllustrationCommand(BaseProductModelIllustration model, IMapper mapper)
        {
            mapper.Map<BaseProductModelIllustration, CreateProductModelIllustrationCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductModelIllustrationCommand, ProductModelIllustrationLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductModelIllustrationsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductModelIllustrationsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductModelIllustrationLookupModel> Handle(CreateProductModelIllustrationCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductModelIllustrationCommand, Entities.ProductModelIllustration>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductModelIllustrations.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductModelIllustrations.FindAsync(new object[] { entity.ProductModelID, entity.IllustrationID }, cancellationToken);

                await _mediator.Publish(new ProductModelIllustrationCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductModelIllustration, ProductModelIllustrationLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModelIllustration, CreateProductModelIllustrationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductModelIllustrationCommand, Entities.ProductModelIllustration>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
