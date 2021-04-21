using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.CreateSalesOrderHeader
{
    public partial class CreateSalesOrderHeaderCommand : BaseSalesOrderHeader, IRequest<SalesOrderHeaderLookupModel>, IHaveCustomMapping
    {

        public CreateSalesOrderHeaderCommand()
        {

        }

        public CreateSalesOrderHeaderCommand(BaseSalesOrderHeader model, IMapper mapper)
        {
            mapper.Map<BaseSalesOrderHeader, CreateSalesOrderHeaderCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateSalesOrderHeaderCommand, SalesOrderHeaderLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly SalesOrderHeadersQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                SalesOrderHeadersQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<SalesOrderHeaderLookupModel> Handle(CreateSalesOrderHeaderCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateSalesOrderHeaderCommand, Entities.SalesOrderHeader>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.SalesOrderHeaders.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.SalesOrderHeaders.FindAsync(new object[] { entity.SalesOrderID }, cancellationToken);

                await _mediator.Publish(new SalesOrderHeaderCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.SalesOrderHeader, SalesOrderHeaderLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesOrderHeader, CreateSalesOrderHeaderCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateSalesOrderHeaderCommand, Entities.SalesOrderHeader>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
