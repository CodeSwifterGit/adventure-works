using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual
{
    public partial class IndividualUpdated : INotification
    {
        public Entities.Individual Entity { get; set; }

        public partial class IndividualUpdatedHandler : INotificationHandler<IndividualUpdated>
        {
            private readonly ICrudWarningService _notification;
            private readonly IAuthenticatedUserService _authenticatedUserService;

            public IndividualUpdatedHandler(ICrudWarningService notification, IAuthenticatedUserService authenticatedUserService)
            {
                _notification = notification;
                _authenticatedUserService = authenticatedUserService;
            }

            public async Task Handle(IndividualUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new CrudWarningMessage()
                {
                    Schema = "Sales",
                    Table = "Individual",
                    User = _authenticatedUserService,
                    CrudAction = CrudActionEnum.Update,
                    Entity = notification.Entity
                });
            }
        }
    }
}