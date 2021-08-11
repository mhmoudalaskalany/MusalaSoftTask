using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Report
{
    public interface IReportService : IBaseService<Entities.Entities.Gateway, AddGatewayDto, GatewayDto, long, long?>
    {
        Task<IResult> GetDashboardCountsAsync();
    }
}
