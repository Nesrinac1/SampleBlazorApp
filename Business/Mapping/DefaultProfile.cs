using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;


namespace Business.Mapping
{
    public class DefaultProfile:Profile
    {
        public DefaultProfile() 
        {

            CreateMap<DataAccess.DataModels.StaffMaster, Models.Viewmodels.StaffMaster>().ReverseMap();
        }
        
    }
}
