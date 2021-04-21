using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.DeleteProductModelIllustration
{
    public partial class ProductModelIllustrationDeleted : INotification
    {
        public Entities.ProductModelIllustration Entity { get; set; }

        public partial class ProductModelIllustrationDeletedHandler : INotificationHandler<ProductModelIllustrationDeleted>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ProductModelIllustrationDeletedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ProductModelIllustrationDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "ProductModelIllustration",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Delete,
                    Entity = notification.Entity
                });
            }
        }
    }
}