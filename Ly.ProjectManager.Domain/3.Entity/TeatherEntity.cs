using Ly.ProjectManager.Domain._1.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._4.Entity
{
    public class TeatherEntity : IEntity<TeatherEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        public string teacherGuid { get; set; }
    
        public int teacherIdentity { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string teacherNo { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string teacherPwd { get; set; }
        /// <summary>
        /// 老师类型 1-辅导员 2-讲师 
        /// </summary>
        public Nullable<int> teacherType { get; set; }
        /// <summary>
        /// 老师姓名
        /// </summary>
        public string teacherName { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string nation { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string place { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Nullable<bool> gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string birthday { get; set; }
        /// <summary>
        /// qq
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string wechat { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }

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
