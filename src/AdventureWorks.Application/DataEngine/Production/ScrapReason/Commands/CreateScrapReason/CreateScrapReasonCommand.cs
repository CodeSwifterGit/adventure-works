using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.CreateScrapReason
{
    public partial class CreateScrapReasonCommand : BaseScrapReason, IRequest<ScrapReasonLookupModel>, IHaveCustomMapping
    {

        public CreateScrapReasonCommand()
        {

        }

        public CreateScrapReasonCommand(BaseScrapReason model, IMapper mapper)
        {
            mapper.Map<BaseScrapReason, CreateScrapReasonCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateScrapReasonCommand, ScrapReasonLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ScrapReasonsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ScrapReasonsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ScrapReasonLookupModel> Handle(CreateScrapReasonCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateScrapReasonCommand, Entities.ScrapReason>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ScrapReasons.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ScrapReasons.FindAsync(new object[] { entity.ScrapReasonID }, cancellationToken);

                await _mediator.Publish(new ScrapReasonCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ScrapReason, ScrapReasonLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseScrapReason, CreateScrapReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateScrapReasonCommand, Entities.ScrapReason>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
