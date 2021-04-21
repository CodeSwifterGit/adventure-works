using AdventureWorks.Application.DataEngine.DataEngine;

namespace AdventureWorks.Application.Interfaces
{
    public interface IDataTableInfo<T> where T : class
    {
        DataTableInfo<T> DataTable { get; set; }
    }
}