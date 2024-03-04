using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM=Models.Viewmodels;

namespace Business.Service.Interface
{
    public interface IMasters
    {

        Task<List<SM.StaffMaster>> GetAll();
        Task<SM.StaffMaster> Add(SM.StaffMaster master);
       
    }
}
