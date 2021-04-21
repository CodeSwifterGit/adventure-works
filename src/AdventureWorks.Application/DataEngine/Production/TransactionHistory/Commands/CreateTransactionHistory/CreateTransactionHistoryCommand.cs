using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.CreateTransactionHistory
{
    public partial class CreateTransactionHistoryCommand : BaseTransactionHistory, IRequest<TransactionHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateTransactionHistoryCommand()
        {

        }

        public CreateTransactionHistoryCommand(BaseTransactionHistory model, IMapper mapper)
        {
            mapper.Map<BaseTransactionHistory, CreateTransactionHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateTransactionHistoryCommand, TransactionHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly TransactionHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                TransactionHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<TransactionHistoryLookupModel> Handle(CreateTransactionHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateTransactionHistoryCommand, Entities.TransactionHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.TransactionHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.TransactionHistories.FindAsync(new object[] { entity.TransactionID }, cancellationToken);

                await _mediator.Publish(new TransactionHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.TransactionHistory, TransactionHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseTransactionHistory, CreateTransactionHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateTransactionHistoryCommand, Entities.TransactionHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
