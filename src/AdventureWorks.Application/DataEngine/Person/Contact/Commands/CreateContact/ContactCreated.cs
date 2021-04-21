using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.CreateContact
{
    public partial class ContactCreated : INotification
    {
        public Entities.Contact Entity { get; set; }

        public partial class ContactCreatedHandler : INotificationHandler<ContactCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ContactCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ContactCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Person",
                    Table = "Contact",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}