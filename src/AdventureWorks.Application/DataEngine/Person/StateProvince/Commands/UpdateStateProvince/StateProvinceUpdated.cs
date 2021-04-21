using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class StateProvinceUpdated : INotification
    {
        public Entities.StateProvince Entity { get; set; }

        public partial class StateProvinceUpdatedHandler : INotificationHandler<StateProvinceUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public StateProvinceUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(StateProvinceUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Person",
                    Table = "StateProvince",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}