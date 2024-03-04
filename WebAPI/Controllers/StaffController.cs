using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Business.Service.Interface;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IMasters _staffService;
        private readonly EmployeeDbContext _dbContext;
        private readonly ILogger<StaffController> _logger;
        private readonly IMapper _mapper;
        public StaffController(IMasters CriteriaService, ILogger<StaffController> logger,EmployeeDbContext dbContext,IMapper mapper)
        {
            _staffService = CriteriaService;
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: Staff
        //public async Task<IActionResult> GetStaffList()
        //{
        //    try
        //    {

        //        var data = await _criteriaService.GetCriterias();
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(exception: ex, message: "Failed to get Criterias");
        //        return BadRequest(new ErrorResponse { Error = ex.Message });
        //    }
        //    return View();
        //}
         
       

      
        [HttpPost]
        public async Task<Models.Viewmodels.StaffMaster> Add(Models.Viewmodels.StaffMaster staffmaster)
        {
            try
            {
               var dbStaff= _mapper.Map<Models.Viewmodels.StaffMaster, DataAccess.DataModels.StaffMaster>(staffmaster);
                await _dbContext.StaffMasters.AddAsync(dbStaff);
                _dbContext.SaveChanges();
                var newStaff = _mapper.Map<DataAccess.DataModels.StaffMaster, Models.Viewmodels.StaffMaster>(dbStaff);
                return newStaff;
            } 
            catch
            {
                throw;
            }
        }

        
    }
}
