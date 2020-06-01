using SimpleApp.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardInfo();
    }
}
