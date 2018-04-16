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
    /// 项目答辩结果
    /// </summary>
    [Table("ProjectDefenceResult")]
    public class ProjectDefenceResultEntity : IEntity<ProjectDefenceResultEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        //自定义属性
        [Key]
        public string resultGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int resultIdentity { get; set; }
        /// <summary>
        /// 项目评价
        /// </summary>
        public string resultEvaluate { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public decimal? resultScore { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        public string projectInfoGuid { get; set; }
    }
}
