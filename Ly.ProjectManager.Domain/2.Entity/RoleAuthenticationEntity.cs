using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._2.Entity
{
    /// <summary>
    /// 角色权限认证
    /// </summary>
    [Table("RoleAuthentication")]
    public class RoleAuthenticationEntity : IEntity<RoleAuthenticationEntity>, ICreationAudited
    {
        //自定义属性
        [Key]
        public string authGuid { get; set; }
        /// <summary>
        /// 认证模块类型  1-模块 2-按钮
        /// </summary>
        public int authModuleType { get; set; }
        public string authModuleGuid { get; set; }
        public string authRoleGuid { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
      
    }
}
