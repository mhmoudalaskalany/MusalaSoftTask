using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Common.DTO.Gateway.Parameters;
using BackendCore.Service.Services.Base;

namespace BackendCore.Service.Services.Gateway
{
    public interface IGatewayService : IBaseService<Entities.Entities.Gateway, AddGatewayDto, GatewayDto , long, long?>
    {
        /// <summary>
        /// Get By Id For Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResult> GetByIdForEditAsync(long id);
        /// <summary>
        /// Get All Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<DataPaging> GetAllPagedAsync(BaseParam<GatewayFilter> filter);
    }
}