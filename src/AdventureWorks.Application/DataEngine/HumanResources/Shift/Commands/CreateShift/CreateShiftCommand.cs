using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.CreateShift
{
    public partial class CreateShiftCommand : BaseShift, IRequest<ShiftLookupModel>, IHaveCustomMapping
    {

        public CreateShiftCommand()
        {

        }

        public CreateShiftCommand(BaseShift model, IMapper mapper)
        {
            mapper.Map<BaseShift, CreateShiftCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateShiftCommand, ShiftLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ShiftsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ShiftsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ShiftLookupModel> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateShiftCommand, Entities.Shift>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Shifts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Shifts.FindAsync(new object[] { entity.ShiftID }, cancellationToken);

                await _mediator.Publish(new ShiftCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Shift, ShiftLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShift, CreateShiftCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateShiftCommand, Entities.Shift>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
