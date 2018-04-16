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
    /// 项目
    /// </summary>
    [Table("Project")]
    public class ProjectEntity : IEntity<ProjectEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string projectGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int projectIdentity { get; set; }
        /// <summary>
        /// 项目状态 编码完成，
        /// </summary>
        public string projectStatus { get; set; }
        public string projectName { get; set; }
        public string projectDesc { get; set; }
        public string projectTarget { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        /// <summary>
        /// 立项文档URL
        /// </summary>
        public string projectStandingDocUri { get; set; }
        /// <summary>
        /// 项目计划文档
        /// </summary>
        public string projectPlanDocUri { get; set; }
        /// <summary>
        /// 项目详细设计文档
        /// </summary>
        public string projectDetailedDesignDocUri { get; set; }
        /// <summary>
        /// 项目展示地址
        /// </summary>
        public string projectPresentationAddressUri { get; set; }

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
        public string teamInfoGuid { get; set; }
    }
}
