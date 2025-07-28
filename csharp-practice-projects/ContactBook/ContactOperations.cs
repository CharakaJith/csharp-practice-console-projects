using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public enum ContactOperations
    {
        ViewAll,
        AddNew,
        Update,
        Delete,
        SearchByName,
        SortByName,
        ExportToCSV,
        Exit,
    }
}
