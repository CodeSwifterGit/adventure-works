using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument
{
    public partial class ProductDocumentUpdated : INotification
    {
        public Entities.ProductDocument Entity { get; set; }

        public partial class ProductDocumentUpdatedHandler : INotificationHandler<ProductDocumentUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ProductDocumentUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ProductDocumentUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "ProductDocument",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}