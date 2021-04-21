using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.CreateTransactionHistoryArchive
{
    public partial class CreateTransactionHistoryArchiveCommand : BaseTransactionHistoryArchive, IRequest<TransactionHistoryArchiveLookupModel>, IHaveCustomMapping
    {

        public CreateTransactionHistoryArchiveCommand()
        {

        }

        public CreateTransactionHistoryArchiveCommand(BaseTransactionHistoryArchive model, IMapper mapper)
        {
            mapper.Map<BaseTransactionHistoryArchive, CreateTransactionHistoryArchiveCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateTransactionHistoryArchiveCommand, TransactionHistoryArchiveLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly TransactionHistoryArchivesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                TransactionHistoryArchivesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<TransactionHistoryArchiveLookupModel> Handle(CreateTransactionHistoryArchiveCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateTransactionHistoryArchiveCommand, Entities.TransactionHistoryArchive>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.TransactionHistoryArchives.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.TransactionHistoryArchives.FindAsync(new object[] { entity.TransactionID }, cancellationToken);

                await _mediator.Publish(new TransactionHistoryArchiveCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.TransactionHistoryArchive, TransactionHistoryArchiveLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseTransactionHistoryArchive, CreateTransactionHistoryArchiveCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateTransactionHistoryArchiveCommand, Entities.TransactionHistoryArchive>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
