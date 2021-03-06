using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.User;
using BackendCore.Common.DTO.User.Parameters;
using BackendCore.Service.Services.Base;
using LinqKit;

namespace BackendCore.Service.Services.User
{
    public class UserService : BaseService<Entities.Entities.User, AddUserDto, UserDto, long, long?>, IUserService
    {
        public UserService(IServiceBaseParameter<Entities.Entities.User> parameters) : base(parameters)
        {

        }

        #region Public Methods
        /// <summary>
        /// Get All Paged
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<DataPaging> GetAllPagedAsync(BaseParam<UserFilter> filter)
        {

            int limit = filter.PageSize;
            int offset = ((--filter.PageNumber) * filter.PageSize);
            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: PredicateBuilderFunction(filter.Filter), skip: offset, take: limit, filter.OrderByValue);
            var data = Mapper.Map<IEnumerable<Entities.Entities.User>, IEnumerable<UserDto>>(query.Item2);
            return new DataPaging(++filter.PageNumber, filter.PageSize, query.Item1, ResponseResult.PostResult(data, status: HttpStatusCode.OK, message: HttpStatusCode.OK.ToString()));

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Predicate Builder
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        static Expression<Func<Entities.Entities.User, bool>> PredicateBuilderFunction(UserFilter filter)
        {
            var predicate = PredicateBuilder.New<Entities.Entities.User>(true);

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                predicate = predicate.And(b => b.NameAr.ToLower().Contains(filter.Name.ToLower()) || b.NameEn.ToLower().Contains(filter.Name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(filter.Username))
            {
                predicate = predicate.And(b => b.UserName.ToLower().Contains(filter.Username.ToLower()));
            }
            return predicate;
        }

        #endregion


    }
}
