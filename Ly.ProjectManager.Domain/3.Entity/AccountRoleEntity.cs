using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._3.Entity
{
    /// <summary>
    /// 账户角色表
    /// </summary>
    public class AccountRoleEntity : IEntity<AccountRoleEntity>, ICreationAudited, IModificationAudited, ICommonProperty
    {
        // 自定义属性
        [Key]
        public string accountRoleGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int accountRoleIdentity { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }

        //外键属性
        public string accountGuid { get; set; }
        [ForeignKey("accountGuid")]
        public AccountEntity accountEntity { get; set; }
        public string roleGuid { get; set; }
        [ForeignKey("roleGuid")]
        public RoleEntity roleEntity { get; set; }
    }
}
