using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.CreateAddressType
{
    public partial class AddressTypeCreated : INotification
    {
        public Entities.AddressType Entity { get; set; }

        public partial class AddressTypeCreatedHandler : INotificationHandler<AddressTypeCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public AddressTypeCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(AddressTypeCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Person",
                    Table = "AddressType",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}