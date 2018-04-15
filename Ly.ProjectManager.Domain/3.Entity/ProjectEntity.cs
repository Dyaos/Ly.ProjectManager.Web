using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._3.Entity
{
    public class ProjectEntity : IEntity<ProjectEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        //自定义属性
        public string projectGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int projectIdentity { get; set; }
        /// <summary>
        /// 通过状态
        /// </summary>
        public bool projectStatus { get; set; }
        public string projectName { get; set; }
        public string projectDesc { get; set; }
        public string projectTarget { get; set; }
        /// <summary>
        /// 开发背景
        /// </summary>
        public string DevelopmentBackground { get; set; }
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
        public string teamGuid { get; set; }
        [ForeignKey("teamGuid")]
        public ProjectTeam projectTeam { get; set; }
    }
}
