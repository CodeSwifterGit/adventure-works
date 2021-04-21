using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.DeleteContactCreditCard
{
    public partial class ContactCreditCardDeleted : INotification
    {
        public Entities.ContactCreditCard Entity { get; set; }

        public partial class ContactCreditCardDeletedHandler : INotificationHandler<ContactCreditCardDeleted>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ContactCreditCardDeletedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ContactCreditCardDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Sales",
                    Table = "ContactCreditCard",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Delete,
                    Entity = notification.Entity
                });
            }
        }
    }
}