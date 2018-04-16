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
    /// 用户
    /// </summary>
    [Table("Account")]
    public class AccountEntity : IEntity<AccountEntity>, ICreationAudited, IDeleteAudited, IModificationAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string accountGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int accountIdentity { get; set; }
        /// <summary>
        /// 工号，学号，账号
        /// </summary>
        public string accountNo { get; set; }
        public string accountPwd { get; set; }
        public string accountName { get; set; }
        /// <summary>
        /// 用户类型 1-管理员 2-教师 3-学生
        /// </summary>
        public int accountType { get; set; }
        public Nullable<bool> gender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string nation { get; set; }
        public string birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountCard { get; set; }
        /// <summary>
        /// 祖籍
        /// </summary>
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
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }
        
    }
}
