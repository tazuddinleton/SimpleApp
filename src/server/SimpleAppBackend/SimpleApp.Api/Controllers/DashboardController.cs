using Microsoft.AspNetCore.Mvc;
using SimpleApp.Domain.DTOs;
using SimpleApp.Persistence.Repositories;
using SimpleApp.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Api.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> Get()
        {
            return Ok( await _dashboardService.GetDashboardInfo());
        }
    }
}
