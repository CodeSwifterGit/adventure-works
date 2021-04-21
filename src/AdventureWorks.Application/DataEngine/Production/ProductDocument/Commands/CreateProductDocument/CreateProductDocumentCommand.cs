using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.CreateProductDocument
{
    public partial class CreateProductDocumentCommand : BaseProductDocument, IRequest<ProductDocumentLookupModel>, IHaveCustomMapping
    {

        public CreateProductDocumentCommand()
        {

        }

        public CreateProductDocumentCommand(BaseProductDocument model, IMapper mapper)
        {
            mapper.Map<BaseProductDocument, CreateProductDocumentCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductDocumentCommand, ProductDocumentLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductDocumentsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductDocumentsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductDocumentLookupModel> Handle(CreateProductDocumentCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductDocumentCommand, Entities.ProductDocument>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductDocuments.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductDocuments.FindAsync(new object[] { entity.ProductID, entity.DocumentID }, cancellationToken);

                await _mediator.Publish(new ProductDocumentCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductDocument, ProductDocumentLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductDocument, CreateProductDocumentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductDocumentCommand, Entities.ProductDocument>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
