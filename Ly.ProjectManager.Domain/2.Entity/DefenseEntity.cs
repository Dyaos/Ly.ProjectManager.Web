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
    /// 答辩基本信息
    /// </summary>
    [Table("Defense")]
    public class DefenseEntity : IEntity<DefenseEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        public DefenseEntity()
        {
            this.isEnabled = true;
        }
        //自定义属性
        [Key]
        public string defenseGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public string defenseIdentity { get; set; }
        /// <summary>
        /// 答辩教室
        /// </summary>
        public string defenseClassroom { get; set; }
        public DateTime? defenseStartTime { get; set; }
        public DateTime? defenseEndTime { get; set; }
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
      
        
       
    }
}
