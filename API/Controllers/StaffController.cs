﻿using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IMasters _staffService;
        private readonly EmployeeDbContext _dbContext;
        private readonly ILogger<StaffController> _logger;
        private readonly IMapper _mapper;
        public StaffController(IMasters staffService, ILogger<StaffController> logger,EmployeeDbContext dbContext,IMapper mapper)
        {
            _staffService = staffService;
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: Staff

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var data = await _staffService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: "Failed to get staff details");
                throw;
            }
        }

        //POST: Add new staff
         
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
        
        //POST: Add new staff

        [HttpPost]
        public async Task<Models.Viewmodels.StaffMaster> Add(Models.Viewmodels.StaffMaster staffmaster)
        {
            try
            {
                var dbStaff = _mapper.Map<Models.Viewmodels.StaffMaster, DataAccess.DataModels.StaffMaster>(staffmaster);
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

        //Patch :update staff


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStaff(Models.Viewmodels.StaffMaster staffmaster, int id)
        {
            try
            {
                var dbStaff = await _dbContext.StaffMasters.FindAsync(id);

                _mapper.Map(staffmaster, dbStaff);

                await _dbContext.SaveChangesAsync();

                return Ok(staffmaster); // Return updated staffmaster

            }
            catch
            {
                throw; // Rethrow exception to be handled by global exception handler
            }

        }

        //get by id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            try
            {
                var staff = await _dbContext.StaffMasters.FindAsync(id);



                var staffViewModel = _mapper.Map<Models.Viewmodels.StaffMaster>(staff);

                return Ok(staffViewModel); // Return staff member
            }
            catch
            {
                throw; // Rethrow exception to be handled by global exception handler
            }
        }

        
    }
}
