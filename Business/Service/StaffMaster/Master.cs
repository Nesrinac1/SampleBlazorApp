using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Service.Interface;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using SM = Models.Viewmodels;

namespace Business.Service.StaffMaster
{
    public class Master : IMasters
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;

        public Master(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public async Task<List<SM.StaffMaster>> GetAll()
        {
            var SList = new List<SM.StaffMaster>();
            SList = await _dbContext.StaffMasters
                .Select(j => new SM.StaffMaster
                {
                    Sid=j.Sid,
                    Fname=j.Fname,
                    Address=j.Address,
                    Mobile=j.Mobile,
                    Age=j.Age,
                    Dob=j.Dob,
                    Salary=j.Salary,
                }).ToListAsync();
            return SList;
        }

        public async Task<SM.StaffMaster> Add(SM.StaffMaster master)
        {
            var staffmasters = new SM.StaffMaster();
            try
            {
                var dbMaster = _mapper.Map<SM.StaffMaster, DataAccess.DataModels.StaffMaster>(master);

                if (dbMaster != null)
                {
                    await _dbContext.StaffMasters.AddAsync(dbMaster);
                    await _dbContext.SaveChangesAsync();
                    staffmasters = _mapper.Map<DataAccess.DataModels.StaffMaster, SM.StaffMaster>(dbMaster);
                }
                else
                {
                    // Handle the case where mapping returns null, for example, log the error or throw an exception
                    Console.WriteLine("Mapping operation returned null.");

                    // Optionally, throw an exception
                    throw new Exception("Mapping operation returned null.");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, for example, log it
                Console.WriteLine($"Error occurred during Add operation: {ex.Message}");
                // Optionally, rethrow the exception
                throw;
            }
            return staffmasters;
        }

    }
}
