using System.Threading.Tasks;
using BackendCore.Api.Controllers.Base;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Common.DTO.Gateway.Parameters;
using BackendCore.Service.Services.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Api.Controllers
{
    /// <summary>
    /// Gateways Controller
    /// </summary>
    public class GatewaysController : BaseController
    {
        private readonly IGatewayService _gatewayService;
        /// <summary>
        /// Constructor
        /// </summary>
        public GatewaysController(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }
        /// <summary>
        /// Get By Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IResult> GetAsync(long id)
        {
            var result = await _gatewayService.GetByIdAsync(id);
            return result;
        }

        /// <summary>
        /// Get By Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IResult> GetByIdForEditAsync(long id)
        {
            var result = await _gatewayService.GetByIdForEditAsync(id);
            return result;
        }

        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResult> GetAllAsync()
        {
            var result = await _gatewayService.GetAllAsync();
            return result;
        }

        /// <summary>
        /// GetAll Data paged
        /// </summary>
        /// <param name="filter">Filter responsible for search and sort</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<DataPaging> GetPagedAsync([FromBody] BaseParam<GatewayFilter> filter)
        {
            return await _gatewayService.GetAllPagedAsync(filter);
        }

        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResult> AddAsync([FromBody] AddGatewayDto dto)
        {
            var result = await _gatewayService.AddAsync(dto);
            return result;
        }


        /// <summary>
        /// Update  
        /// </summary>
        /// <param name="model">Object content</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResult> UpdateAsync(AddGatewayDto model)
        {

            return await _gatewayService.UpdateAsync(model);
        }
        /// <summary>
        /// Remove  by id
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResult> DeleteAsync(long id)
        {
            return await _gatewayService.DeleteAsync(id);
        }

        /// <summary>
        /// Soft Remove  by id
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSoftAsync(long id)
        {
            return await _gatewayService.DeleteSoftAsync(id);
        }


    }
}
