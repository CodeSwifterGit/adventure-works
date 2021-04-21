using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.CreateDocument
{
    public partial class DocumentCreated : INotification
    {
        public Entities.Document Entity { get; set; }

        public partial class DocumentCreatedHandler : INotificationHandler<DocumentCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public DocumentCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(DocumentCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "Document",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}