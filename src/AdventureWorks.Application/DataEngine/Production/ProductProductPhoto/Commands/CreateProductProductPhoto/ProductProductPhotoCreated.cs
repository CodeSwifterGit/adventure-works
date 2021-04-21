using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.CreateProductProductPhoto
{
    public partial class ProductProductPhotoCreated : INotification
    {
        public Entities.ProductProductPhoto Entity { get; set; }

        public partial class ProductProductPhotoCreatedHandler : INotificationHandler<ProductProductPhotoCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ProductProductPhotoCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ProductProductPhotoCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "ProductProductPhoto",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}