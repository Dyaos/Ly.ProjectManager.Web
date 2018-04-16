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
    /// 模块
    /// </summary>
    [Table("SysModule")]
    public class ModuleEntity : IEntity<ModuleEntity>, ICreationAudited, IModificationAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string moduleGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int moduleIdentity { get; set; }
        public string parentGuid { get; set; }
        public string moduleIcon { get; set; }
        public string moduleUri { get; set; }
        public string moduleTarget { get; set; }
        public string moduleLv { get; set; }
        public string moduleName { get; set; }
        public bool isMenu { get; set; }


        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }
      
    }
}
