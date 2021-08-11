using System.Linq;
using BackendCore.Common.DTO.Gateway;
using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// ReSharper disable once CheckNamespace
namespace BackendCore.Service.Mapping
{
    public partial class MappingService
    {
        public void MapGateway()
        {
            CreateMap<Gateway, GatewayDto>()
                .ReverseMap();

            CreateMap<Gateway, AddGatewayDto>();

            CreateMap<AddGatewayDto, Gateway>();


        }
    }
}