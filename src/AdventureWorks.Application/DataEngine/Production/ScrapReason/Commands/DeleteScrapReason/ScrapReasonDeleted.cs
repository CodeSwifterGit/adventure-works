using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason
{
    public partial class ScrapReasonDeleted : INotification
    {
        public Entities.ScrapReason Entity { get; set; }

        public partial class ScrapReasonDeletedHandler : INotificationHandler<ScrapReasonDeleted>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ScrapReasonDeletedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ScrapReasonDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "ScrapReason",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Delete,
                    Entity = notification.Entity
                });
            }
        }
    }
}