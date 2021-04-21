using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration
{
    public partial class IllustrationDeleted : INotification
    {
        public Entities.Illustration Entity { get; set; }

        public partial class IllustrationDeletedHandler : INotificationHandler<IllustrationDeleted>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public IllustrationDeletedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(IllustrationDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "Illustration",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Delete,
                    Entity = notification.Entity
                });
            }
        }
    }
}