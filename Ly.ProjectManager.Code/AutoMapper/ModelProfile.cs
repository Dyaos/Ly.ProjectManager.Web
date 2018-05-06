using AutoMapper;
using Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Code.AutoMapper
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            //配置相关映射

            //eg

            //CreateMap<BaseUserEntity, BaseUserModel>()
            //.ForMember(model => model.StaffName, entity => entity.Ignore())
            //.ForMember(model => model.StaffNo, entity => entity.Ignore())
            //.ForMember(model => model.LocationTypeName, entity => entity.Ignore())
            //.ForMember(model => model.IsADLoginName, entity => entity.Ignore())
            //.ForMember(model => model.TypeName, entity => entity.Ignore())
            //.ForMember(model => model.BaseUserRoles, (map) => map.MapFrom(m => m.BaseUserRoles));

            CreateMap<LoginOutputDto, OperatorModel>()
                .ForMember(model => model.LoginIPAddress, entity => entity.Ignore())
                .ForMember(model => model.LoginIPAddressName, entity => entity.Ignore())
                .ForMember(model => model.LoginToken, entity => entity.Ignore())
                .ForMember(model => model.LoginTime, entity => entity.Ignore())
                .ForMember(model => model.UserName, entity => entity.MapFrom(src => src.accountName))
                .ForMember(model => model.UserPwd, entity => entity.MapFrom(src => src.accountPwd))
                .ForMember(model => model.UserId, entity => entity.MapFrom(src => src.accountGuid))
                .ForMember(model => model.RoleName, entity => entity.MapFrom(src => src.roleName))
                 .ForMember(model => model.RoleId, entity => entity.MapFrom(src => src.roleGuid))
                    .ForMember(model => model.RoleLv, entity => entity.MapFrom(src => src.roleLv))
                 .ForMember(model => model.UserCodeNo, entity => entity.MapFrom(src => src.accountNo));
        }
    }
}
