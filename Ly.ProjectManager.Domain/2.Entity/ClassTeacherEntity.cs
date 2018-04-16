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
    /// 班级教师
    /// </summary>
    [Table("ClassTeacher")]
    public class ClassTeacherEntity : IEntity<ClassTeacherEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        //自定义属性
        [Key]
        public string teacherGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int teacherIdentity { get; set; }
        public string teacherName { get; set; }
        public int teacherType { get; set; }
        public int accountInfoGuid { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }
    }
}
