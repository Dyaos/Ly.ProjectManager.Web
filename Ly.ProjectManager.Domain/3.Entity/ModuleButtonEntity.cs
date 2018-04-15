using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._3.Entity
{
    /// <summary>
    /// 模块按钮
    /// </summary>
    public class ModuleButtonEntity : IEntity<ModuleButtonEntity>, ICreationAudited, IModificationAudited
    {
        //自定义属性
        public string btnGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int btnIdentity { get; set; }
        public string btnName { get; set; }
        public string btnEncode { get; set; }
        public string btnUri { get; set; }
        public string btnEvent { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }

        //外键属性
        public string moduleGuid { get; set; }
        [ForeignKey("moduleGuid")]
        public ModuleEntity moduleEntity { get; set; }
    }
}
