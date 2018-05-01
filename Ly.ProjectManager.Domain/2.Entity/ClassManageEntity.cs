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
    /// 班级管理
    /// </summary>
    [Table("ClassManage")]
    public class ClassManageEntity : IEntity<ClassManageEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
   
        [Key]
        public string classManageGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public string classManageIdentity { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        public string classInfoGuid { get; set; }
        public string teacherInfoGuid { get; set; }
    }
}
