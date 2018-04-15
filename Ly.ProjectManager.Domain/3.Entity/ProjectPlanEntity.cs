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
    /// 项目计划
    /// </summary>
    public class ProjectPlanEntity : IEntity<ProjectPlanEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        [Key]
        public string planGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int planIdentity { get; set; }
        public string planName { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        /// <summary>
        /// 项目完结状态
        /// </summary>
        public bool? planStatus { get; set; }
        /// <summary>
        /// 目标专业
        /// </summary>
        public string targetSpecialty { get; set; }
        /// <summary>
        /// 项目技术点
        /// </summary>
        public string projectTechnicalPoint { get; set; }
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
        [ForeignKey("gradeGuid")]
        public GradeEntity gradeEntity { get; set; }
        public string gradeGuid { get; set; }
    }
}
