using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument
{
    public partial class DocumentUpdated : INotification
    {
        public Entities.Document Entity { get; set; }

        public partial class DocumentUpdatedHandler : INotificationHandler<DocumentUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public DocumentUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(DocumentUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "Document",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}