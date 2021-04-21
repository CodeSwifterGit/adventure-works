using AdventureWorks.Application.Enums;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Interfaces;

namespace AdventureWorks.Application.Models
{
    public class CrudWarningMessage
    {
        public CrudActionEnum CrudAction { get; set; }
        public string Schema { get; set; }
        public string Table { get; set; }
        public IAuthenticatedUserService User { get; set; }
        public IBaseEntity Entity { get; set; }
    }
}