using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.CreateAWBuildVersion
{
    public partial class CreateAWBuildVersionSetCommand : IRequest<List<AWBuildVersionLookupModel>>
    {
        public List<BaseAWBuildVersion> AWBuildVersions { get; set; }

        public CreateAWBuildVersionSetCommand()
        {
        }

        public CreateAWBuildVersionSetCommand(List<BaseAWBuildVersion> model)
        {
            AWBuildVersions = model;
        }

        public partial class Handler : IRequestHandler<CreateAWBuildVersionSetCommand, List<AWBuildVersionLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<AWBuildVersionLookupModel>> Handle(CreateAWBuildVersionSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<AWBuildVersionLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.AWBuildVersions)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateAWBuildVersionCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}