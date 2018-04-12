using Ly.ProjectManager.Domain._1.Infrastructure;
using Ly.ProjectManager.Domain._4.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._3.Entity
{
    public class RoleEntity : IEntity<RoleEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        //自定义属性
        [Key]
        public string roleGuid { get; set; }
        public int roleIdentity { get; set; }
        public string roleName { get; set; }
        public Nullable<int> roleLv { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        public string teacherGuid { get; set; }
        public ICollection<TeatherEntity> teatherEntitys { get; set; }
    }
}
