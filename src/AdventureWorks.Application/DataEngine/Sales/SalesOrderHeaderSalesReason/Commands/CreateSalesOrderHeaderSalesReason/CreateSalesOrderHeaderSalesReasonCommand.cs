using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.CreateSalesOrderHeaderSalesReason
{
    public partial class CreateSalesOrderHeaderSalesReasonCommand : BaseSalesOrderHeaderSalesReason, IRequest<SalesOrderHeaderSalesReasonLookupModel>, IHaveCustomMapping
    {

        public CreateSalesOrderHeaderSalesReasonCommand()
        {

        }

        public CreateSalesOrderHeaderSalesReasonCommand(BaseSalesOrderHeaderSalesReason model, IMapper mapper)
        {
            mapper.Map<BaseSalesOrderHeaderSalesReason, CreateSalesOrderHeaderSalesReasonCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderHeaderSalesReasonCommand, SalesOrderHeaderSalesReasonLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesOrderHeaderSalesReasonsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesOrderHeaderSalesReasonsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesOrderHeaderSalesReasonLookupModel> Handle(CreateSalesOrderHeaderSalesReasonCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesOrderHeaderSalesReasonCommand, Entities.SalesOrderHeaderSalesReason>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesOrderHeaderSalesReasons.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesOrderHeaderSalesReasons.FindAsync(new object[] { entity.SalesOrderID, entity.SalesReasonID }, cancellationToken);

                await _mediator.Publish(new SalesOrderHeaderSalesReasonCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderHeaderSalesReason, CreateSalesOrderHeaderSalesReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesOrderHeaderSalesReasonCommand, Entities.SalesOrderHeaderSalesReason>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
