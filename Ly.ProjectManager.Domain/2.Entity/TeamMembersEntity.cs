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
    /// 团队成员
    /// </summary>
    [Table("TeamMembers")]
    public class TeamMembersEntity : IEntity<TeamMembersEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string membersGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int membersIdentity { get; set; }
        public string membersName { get; set; }
        public string accountInfoGuid { get; set; }
        /// <summary>
        /// 成员职责 （开发 UI设计师）
        /// </summary>
        public string membersDuties { get; set; }
        /// <summary>
        /// 成员职能 （小组长，组员）
        /// </summary>
        public string membersFunction { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }


        //外键属性
        public string teamInfoGuid { get; set; }
        public string roleInfoGuid { get; set; }
    }
}
