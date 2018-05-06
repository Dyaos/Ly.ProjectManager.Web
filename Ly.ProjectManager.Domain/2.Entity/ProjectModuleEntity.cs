using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._2.Entity
{
    /// <summary>
    /// 项目模块
    /// </summary>
    [Table("ProjectModule")]
    public class ProjectModuleEntity : IEntity<ProjectModuleEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        public ProjectModuleEntity()
        {
            this.isEnabled = true;
        }
        //自定义属性
        [Key]
        public string projectModuleGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int projectModuleIdentity { get; set; }
        public string projectModuleName { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int priority { get; set; }
        public string projectModuleStatus { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? deadline { get; set; }
        /// <summary>
        /// 预计开始时间
        /// </summary>
        public DateTime? expectedStartTime { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? actualStartTime { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string chargePerson { get; set; }
        public string chargePersonInfoGuid { get; set; }
        /// <summary>
        /// 完成人
        /// </summary>
        public string completePerson { get; set; }
        /// <summary>
        /// 预计工时
        /// </summary>
        public int expectedWorkHours { get; set; }
        /// <summary>
        /// 实际完成工时
        /// </summary>
        public int actualWorkHours { get; set; }
        /// <summary>
        /// 项目模块描述
        /// </summary>
        public string projectModuleDesc { get; set; }
        /// <summary>
        /// 模块类型
        /// </summary>
        public string projectModuleType { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }
        public int? sortCode { get; set; }
        [DefaultValue(true)]
        [Required]
        public bool isEnabled { get; set; }
        public string remarks { get; set; }


        //外键属性
        public string projectInfoGuid { get; set; }
    }
}
