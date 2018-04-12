using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._3.Entity
{
    public class StudentEntity:IEntity<StudentEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        //自定义属性
        [Key]
        public string stuGuid { get; set; }
        public string stuNo { get; set; }
        public string stuPwd { get; set; }
        public string stuName { get; set; }
        public Nullable<bool> gender { get; set; }
        public string nation { get; set; }
        public string birthday { get; set; }
        public string stuCard { get; set; }
        public string place { get; set; }
        public string qq { get; set; }
        public string wechat { get; set; }
        public string phone { get; set; }

        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        public string roleGuid { get; set; }

    }
}
