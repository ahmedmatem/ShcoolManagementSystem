using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMA.SchoolManagementSystem.Data.Model.Contracts
{
    public interface IAuditable
    {
        DateTime? CreatedOn { set; get; }

        DateTime? ModifiedOn { set; get; }
    }
}
