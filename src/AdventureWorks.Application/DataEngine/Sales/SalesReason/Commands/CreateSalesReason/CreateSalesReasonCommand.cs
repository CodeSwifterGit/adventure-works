using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.CreateSalesReason
{
    public partial class CreateSalesReasonCommand : BaseSalesReason, IRequest<SalesReasonLookupModel>, IHaveCustomMapping
    {

        public CreateSalesReasonCommand()
        {

        }

        public CreateSalesReasonCommand(BaseSalesReason model, IMapper mapper)
        {
            mapper.Map<BaseSalesReason, CreateSalesReasonCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesReasonCommand, SalesReasonLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesReasonsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesReasonsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesReasonLookupModel> Handle(CreateSalesReasonCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesReasonCommand, Entities.SalesReason>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesReasons.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesReasons.FindAsync(new object[] { entity.SalesReasonID }, cancellationToken);

                await _mediator.Publish(new SalesReasonCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesReason, SalesReasonLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesReason, CreateSalesReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesReasonCommand, Entities.SalesReason>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
