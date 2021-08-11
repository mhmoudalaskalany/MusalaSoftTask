using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Device;
using BackendCore.Common.DTO.Device.Parameters;
using BackendCore.Service.Services.Base;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Service.Services.Device
{
    public class DeviceService : BaseService<Entities.Entities.Device, AddDeviceDto, DeviceDto, long, long?>, IDeviceService
    {
        public DeviceService(IServiceBaseParameter<Entities.Entities.Device> parameters) : base(parameters)
        {

        }

        #region Public Methods
        /// <summary>
        /// Get All Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<DataPaging> GetAllPagedAsync(BaseParam<DeviceFilter> filter)
        {

            int limit = filter.PageSize;
            int offset = ((--filter.PageNumber) * filter.PageSize);
            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: PredicateBuilderFunction(filter.Filter), skip: offset, take: limit, filter.OrderByValue , include:src => src.Include(g => g.Gateway));
            var data = Mapper.Map<IEnumerable<Entities.Entities.Device>, IEnumerable<DeviceDto>>(query.Item2);
            return new DataPaging(++filter.PageNumber, filter.PageSize, query.Item1, ResponseResult.PostResult(data, status: HttpStatusCode.OK, message: HttpStatusCode.OK.ToString()));

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Predicate Builder
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        static Expression<Func<Entities.Entities.Device, bool>> PredicateBuilderFunction(DeviceFilter filter)
        {
            var predicate = PredicateBuilder.New<Entities.Entities.Device>(true);

            if (!string.IsNullOrWhiteSpace(filter?.GatewayName))
            {
                predicate = predicate.And(b => b.Gateway.Name.ToLower().Contains(filter.GatewayName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(filter?.Vendor))
            {
                predicate = predicate.And(b => b.Vendor.ToLower().Contains(filter.Vendor.ToLower()));
            }
            return predicate;
        }

        #endregion


    }
}
