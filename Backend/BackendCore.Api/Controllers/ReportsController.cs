using System.Threading.Tasks;
using BackendCore.Api.Controllers.Base;
using BackendCore.Common.Core;
using BackendCore.Service.Services.Report;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Api.Controllers
{
    /// <summary>
    /// Reports Controller
    /// </summary>
    public class ReportsController : BaseController
    {
        private readonly IReportService _reportService;
        /// <summary>
        /// Constructor
        /// </summary>
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        /// <summary>
        /// Get Dashboard Counts  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResult> GetDashboardCountsAsync()
        {
            var result = await _reportService.GetDashboardCountsAsync();
            return result;
        }

        

    }
}
