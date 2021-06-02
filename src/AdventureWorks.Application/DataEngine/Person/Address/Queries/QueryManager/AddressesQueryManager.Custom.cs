using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager
{
    public partial class AddressesQueryManager
    {
        public override IQueryable<Domain.Entities.Person.Address> GetQueryWithIncludes(IQueryable<Domain.Entities.Person.Address> queryable)
        {
            return queryable.Include(a => a.CustomerAddresses);
        }
    }
}
