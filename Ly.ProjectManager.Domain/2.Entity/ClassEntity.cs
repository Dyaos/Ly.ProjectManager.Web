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
    /// 班级
    /// </summary>
    [Table("ClassInfo")]
    public class ClassEntity : IEntity<ClassEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        public ClassEntity()
        {
            this.isEnabled = true;
        }
        [Key]
        public string classGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int classIdentity { get; set; }
        public string className { get; set; }
        /// <summary>
        /// 专业名称
        /// </summary>
        public string specialtiesName { get; set; }
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
        public string gradeInfoGuid { get; set; }
    }
}
