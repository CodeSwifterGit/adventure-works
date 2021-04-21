using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class EmployeeDepartmentHistoryUpdated : INotification
    {
        public Entities.EmployeeDepartmentHistory Entity { get; set; }

        public partial class EmployeeDepartmentHistoryUpdatedHandler : INotificationHandler<EmployeeDepartmentHistoryUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public EmployeeDepartmentHistoryUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(EmployeeDepartmentHistoryUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "HumanResources",
                    Table = "EmployeeDepartmentHistory",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}