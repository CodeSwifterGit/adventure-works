using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.CreateIllustration
{
    public partial class CreateIllustrationCommand : BaseIllustration, IRequest<IllustrationLookupModel>, IHaveCustomMapping
    {

        public CreateIllustrationCommand()
        {

        }

        public CreateIllustrationCommand(BaseIllustration model, IMapper mapper)
        {
            mapper.Map<BaseIllustration, CreateIllustrationCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateIllustrationCommand, IllustrationLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly IllustrationsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                IllustrationsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<IllustrationLookupModel> Handle(CreateIllustrationCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateIllustrationCommand, Entities.Illustration>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Illustrations.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Illustrations.FindAsync(new object[] { entity.IllustrationID }, cancellationToken);

                await _mediator.Publish(new IllustrationCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Illustration, IllustrationLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseIllustration, CreateIllustrationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateIllustrationCommand, Entities.Illustration>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
