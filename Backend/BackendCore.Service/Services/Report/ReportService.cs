using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Report
{
    public class ReportService :BaseService<Entities.Entities.Gateway, AddGatewayDto, GatewayDto, long, long?>, IReportService
    {
        public ReportService(IServiceBaseParameter<Entities.Entities.Gateway> parameters) : base(parameters)
        {

        }

        #region Public Methods

        public async Task<IResult> GetDashboardCountsAsync()
        {
            var gateways = await UnitOfWork.Repository.Count(x => x.IsDeleted == false);
            var devices = await UnitOfWork.GetRepository<Entities.Entities.Device>().Count(x => x.IsDeleted == false && x.Gateway.IsDeleted == false);
            var users = await UnitOfWork.GetRepository<Entities.Entities.User>().Count(x => x.IsDeleted == false);

            return ResponseResult.PostResult(new
            {
                users,
                gateways,
                devices
            }, HttpStatusCode.OK);
        }

        #endregion
    }
}
