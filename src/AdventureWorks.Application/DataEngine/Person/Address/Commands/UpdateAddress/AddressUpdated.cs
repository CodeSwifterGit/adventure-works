using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.UpdateAddress
{
    public partial class AddressUpdated : INotification
    {
        public Entities.Address Entity { get; set; }

        public partial class AddressUpdatedHandler : INotificationHandler<AddressUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public AddressUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(AddressUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Person",
                    Table = "Address",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}