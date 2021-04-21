using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.CreateDepartment
{
    public partial class CreateDepartmentSetCommand : IRequest<List<DepartmentLookupModel>>
    {
        public List<BaseDepartment> Departments { get; set; }

        public CreateDepartmentSetCommand()
        {
        }

        public CreateDepartmentSetCommand(List<BaseDepartment> model)
        {
            Departments = model;
        }

        public partial class Handler : IRequestHandler<CreateDepartmentSetCommand, List<DepartmentLookupModel>>
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

            public async Task<List<DepartmentLookupModel>> Handle(CreateDepartmentSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<DepartmentLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Departments)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateDepartmentCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}