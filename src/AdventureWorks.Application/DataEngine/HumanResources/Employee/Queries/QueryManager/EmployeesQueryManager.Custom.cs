using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.UpdateEmployee;
using AdventureWorks.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager
{
    public partial class EmployeesQueryManager
    {
        public override IQueryable<Domain.Entities.HumanResources.Employee> GetQueryWithIncludes(IQueryable<Domain.Entities.HumanResources.Employee> queryable)
        {
            queryable = queryable
                .Include(e => e.Contact)
                .ThenInclude(c => c.ContactCreditCards)
                .Include(c => c.EmployeeAddresses)
                .OrderBy(c => c.ModifiedDate);
            
            return queryable;
        }

        internal override async Task PostUpdateActionAsync(UpdateEmployeeCommand oldEntity, Domain.Entities.HumanResources.Employee entity, CancellationToken cancellationToken)
        {
            if (oldEntity.SalariedFlag != entity.SalariedFlag)
            {
                await _notificationService.SendAsync("Salaries Audit Warning",
                    $"User {_authenticatedUserService.Name} has updated SalariedFlag.", cancellationToken);
            }

            // We can also update entity object here and save data
            // entity.someField = "someData";
            // await _context.SaveChangesAsync(cancellationToken);
        }

        internal override async Task PostCreateActionAsync(Domain.Entities.HumanResources.Employee entity, CancellationToken cancellationToken)
        {
            await _notificationService.SendAsync("New Employee",
                $"User {_authenticatedUserService.Name} has added a new employee ({entity.Contact.FirstName} {entity.Contact.MiddleName} {entity.Contact.LastName}).",
                cancellationToken);

            // We can also update entity object here and save data
            // entity.someField = "someData";
            // await _context.SaveChangesAsync(cancellationToken);
        }

        internal override async Task PreDeleteActionAsync(Domain.Entities.HumanResources.Employee entity, CancellationToken cancellationToken)
        {
            await _notificationService.SendAsync("Employee Removed",
                $"User {_authenticatedUserService.Name} has removed employee record for ({entity.Contact.FirstName} {entity.Contact.MiddleName} {entity.Contact.LastName}).",
                cancellationToken);
        }

        internal override async Task ReloadEntityDataAsync(Domain.Entities.HumanResources.Employee entity, CancellationToken cancellationToken)
        {
            await _context.Entry(entity).Reference(p => p.Contact).LoadAsync(cancellationToken);
        }

        public override async Task<bool> RemoveDependentRows(Domain.Entities.HumanResources.Employee parent, CancellationToken cancellationToken)
        {
            parent.EmployeeAddresses.Clear();
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public override async Task<UpdatedEntityAfterDependentRowsUpdate> UpdateEntityAndDependentRows(Domain.Entities.HumanResources.Employee entity, UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.ContactID != entity.ContactID)
            {
                await _notificationService.SendAsync("Suspicious Employee Update",
                    $"User {_authenticatedUserService.Name} has updated contact on employee with ContactId={request.ContactID}.",
                    cancellationToken);
            }

            return new UpdatedEntityAfterDependentRowsUpdate(entity, false);
        }
    }
}
