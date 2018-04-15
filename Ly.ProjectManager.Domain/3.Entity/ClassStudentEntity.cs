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
    /// 班级学员管理
    /// </summary>
    public class ClassStudentEntity : IEntity<ClassStudentEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        //自定义属性
        [Key]
        public string stuGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? stuIdentity { get; set; }
        public string stuName { get; set; }
        public string accountInfoGuid { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        [ForeignKey("classGuid")]
        public ClassEntity classEntity { get; set; }
        public string className { get; set; }
        public string classGuid { get; set; }
    }
}
