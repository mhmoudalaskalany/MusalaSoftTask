using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Common.DTO.Gateway.Parameters;
using BackendCore.Service.Services.Base;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Service.Services.Gateway
{
    public class GatewayService : BaseService<Entities.Entities.Gateway, AddGatewayDto, GatewayDto, long, long?>, IGatewayService
    {
        public GatewayService(IServiceBaseParameter<Entities.Entities.Gateway> parameters) : base(parameters)
        {

        }

        #region Public Methods
        /// <summary>
        /// Get By Id For View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<IResult> GetByIdAsync(long id)
        {
            var entity =
                await UnitOfWork.Repository.FirstOrDefaultAsync(x => x.Id == id,
                    include: src => src.Include(d => d.Devices));
            var data = Mapper.Map<GatewayDto>(entity);
            return ResponseResult.PostResult(data, HttpStatusCode.OK);
        }

        /// <summary>
        /// Get For Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResult> GetByIdForEditAsync(long id)
        {
            var entity =
                await UnitOfWork.Repository.FirstOrDefaultAsync(x => x.Id == id,
                    include: src => src.Include(d => d.Devices));
            var data = Mapper.Map<GatewayDto>(entity);
            return ResponseResult.PostResult(data, HttpStatusCode.OK);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override async Task<IResult> AddAsync(AddGatewayDto model)
        {
            var isValid = await ValidateGateway(model);
            if (!isValid.Item1)
            {
                return ResponseResult.PostResult(false, HttpStatusCode.BadRequest, null, isValid.Item2);
            }
            var entity = Mapper.Map<AddGatewayDto, Entities.Entities.Gateway>(model);
            SetEntityCreatedBaseProperties(entity);
            UnitOfWork.Repository.Add(entity);
            var affectedRows = await UnitOfWork.SaveChanges();
            if (affectedRows > 0)
            {
                Result = new ResponseResult(result: null, status: HttpStatusCode.Created,
                    message: "Data Inserted Successfully");
            }

            Result.Data = model;
            return Result;
        }
        /// <summary>
        /// Update gateway
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override async Task<IResult> UpdateAsync(AddGatewayDto model)
        {
            var entityToUpdate = await UnitOfWork.Repository.FirstOrDefaultAsync(x => x.Id == model.Id, disableTracking: false, include: src => src.Include(d => d.Devices));

            var newEntity = Mapper.Map(model, entityToUpdate);

            UnitOfWork.Repository.Update(entityToUpdate, newEntity);

            await UnitOfWork.SaveChanges();
            Result = ResponseResult.PostResult(result: true, status: HttpStatusCode.Accepted,
                message: "Data Updated Successfully");

            return Result;
        }

        /// <summary>
        /// Get All Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<DataPaging> GetAllPagedAsync(BaseParam<GatewayFilter> filter)
        {

            var limit = filter.PageSize;
            var offset = ((--filter.PageNumber) * filter.PageSize);
            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: PredicateBuilderFunction(filter.Filter), skip: offset, take: limit, filter.OrderByValue, include: src => src.Include(d => d.Devices));
            var data = Mapper.Map<IEnumerable<Entities.Entities.Gateway>, IEnumerable<GatewayDto>>(query.Item2);
            return new DataPaging(++filter.PageNumber, filter.PageSize, query.Item1, ResponseResult.PostResult(data, status: HttpStatusCode.OK, message: HttpStatusCode.OK.ToString()));

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Predicate Builder
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        static Expression<Func<Entities.Entities.Gateway, bool>> PredicateBuilderFunction(GatewayFilter filter)
        {
            var predicate = PredicateBuilder.New<Entities.Entities.Gateway>(x => x.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(filter?.Name))
            {
                predicate = predicate.And(b => b.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(filter?.SerialNumber))
            {
                predicate = predicate.And(b => b.SerialNumber.ToLower().Contains(filter.SerialNumber.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(filter?.Ip))
            {
                predicate = predicate.And(b => b.Ip.ToLower().Contains(filter.Ip.ToLower()));
            }
            return predicate;
        }


        /// <summary>
        /// Validate Gateway Before Add
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private async Task<(bool, string)> ValidateGateway(AddGatewayDto dto)
        {
            var isSerialExist = await UnitOfWork.Repository.Any(x => x.SerialNumber == dto.SerialNumber);
            if (isSerialExist)
            {
                return (false, "Serial Number Already Exist");
            }
            return (true, "");
        }

        #endregion


    }
}
