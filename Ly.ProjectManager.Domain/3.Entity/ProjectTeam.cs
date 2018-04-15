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
    public class ProjectTeam : IEntity<ProjectTeam>, ICreationAudited, IModificationAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string teamGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public string teamIdentity { get; set; }
        public string teamName { get; set; }
        /// <summary>
        /// 允许创建项目类别
        /// </summary>
        public string allowCreateProjectCategory { get; set; }
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
        public string planGuid { get; set; }
        [ForeignKey("planGuid")]
        public ProjectPlanEntity projectPlanEntity { get; set; }
        public string classGuid { get; set; }
        [ForeignKey("classGuid")]
        public ClassEntity classEntity { get; set; }
        [ForeignKey("membersGuid")]
        public ICollection<TeamMembersEntity> teamMembersEntities { get; set; }
    }
}
