using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.CreateDepartment
{
    public partial class DepartmentCreated : INotification
    {
        public Entities.Department Entity { get; set; }

        public partial class DepartmentCreatedHandler : INotificationHandler<DepartmentCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public DepartmentCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(DepartmentCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "HumanResources",
                    Table = "Department",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}