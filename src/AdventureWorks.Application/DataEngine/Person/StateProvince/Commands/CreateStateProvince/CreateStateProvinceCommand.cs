using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.CreateStateProvince
{
    public partial class CreateStateProvinceCommand : BaseStateProvince, IRequest<StateProvinceLookupModel>, IHaveCustomMapping
    {

        public CreateStateProvinceCommand()
        {

        }

        public CreateStateProvinceCommand(BaseStateProvince model, IMapper mapper)
        {
            mapper.Map<BaseStateProvince, CreateStateProvinceCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateStateProvinceCommand, StateProvinceLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly StateProvincesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                StateProvincesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<StateProvinceLookupModel> Handle(CreateStateProvinceCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateStateProvinceCommand, Entities.StateProvince>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.StateProvinces.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.StateProvinces.FindAsync(new object[] { entity.StateProvinceID }, cancellationToken);

                await _mediator.Publish(new StateProvinceCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.StateProvince, StateProvinceLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStateProvince, CreateStateProvinceCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateStateProvinceCommand, Entities.StateProvince>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
