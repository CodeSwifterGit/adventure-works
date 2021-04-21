using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.CreateDocument
{
    public partial class CreateDocumentCommand : BaseDocument, IRequest<DocumentLookupModel>, IHaveCustomMapping
    {

        public CreateDocumentCommand()
        {

        }

        public CreateDocumentCommand(BaseDocument model, IMapper mapper)
        {
            mapper.Map<BaseDocument, CreateDocumentCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateDocumentCommand, DocumentLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly DocumentsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                DocumentsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<DocumentLookupModel> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateDocumentCommand, Entities.Document>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Documents.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Documents.FindAsync(new object[] { entity.DocumentID }, cancellationToken);

                await _mediator.Publish(new DocumentCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Document, DocumentLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDocument, CreateDocumentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateDocumentCommand, Entities.Document>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
