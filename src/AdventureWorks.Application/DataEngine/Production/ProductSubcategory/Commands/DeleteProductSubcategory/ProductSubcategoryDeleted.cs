using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory
{
    public partial class ProductSubcategoryDeleted : INotification
    {
        public Entities.ProductSubcategory Entity { get; set; }

        public partial class ProductSubcategoryDeletedHandler : INotificationHandler<ProductSubcategoryDeleted>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public ProductSubcategoryDeletedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(ProductSubcategoryDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Production",
                    Table = "ProductSubcategory",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Delete,
                    Entity = notification.Entity
                });
            }
        }
    }
}