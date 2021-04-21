using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.CreateSalesOrderHeaderSalesReason
{
    public partial class SalesOrderHeaderSalesReasonCreated : INotification
    {
        public Entities.SalesOrderHeaderSalesReason Entity { get; set; }

        public partial class SalesOrderHeaderSalesReasonCreatedHandler : INotificationHandler<SalesOrderHeaderSalesReasonCreated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public SalesOrderHeaderSalesReasonCreatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(SalesOrderHeaderSalesReasonCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Sales",
                    Table = "SalesOrderHeaderSalesReason",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Create,
                    Entity = notification.Entity
                });
            }
        }
    }
}