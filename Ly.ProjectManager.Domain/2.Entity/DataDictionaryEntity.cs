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
    /// 数据字典实体
    /// </summary>
    [Table("DataDictionary")]
    public class DataDictionaryEntity : IEntity<DataDictionaryEntity>, ICreationAudited, IModificationAudited, ICommonProperty
    {
        public DataDictionaryEntity()
        {
            this.isEnabled = true;
        }
        //自定义属性
        [Key]
        public string dataGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int dataIdentity { get; set; }
        public string parentGuid { get; set; }
        public string dataName { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public int? sortCode { get; set; }
        [DefaultValue(true)]
        [Required]
        public bool isEnabled { get; set; }
        public string remarks { get; set; }
      
       
    }
}
