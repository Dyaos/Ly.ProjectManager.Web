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
    public class OperationLogEntity : IEntity<OperationLogEntity>, ICreationAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string logGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int logIdentity { get; set; }
        public string logDetails { get; set; }
        /// <summary>
        /// 日志类型 Login 登录 CURD 增删改查 Error
        /// </summary>
        public string logType { get; set; }
        public string operationTable { get; set; }
        public string operationType { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string operationDesc { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public int? sortCode { get; set; }
        public bool? isEnabled { get; set; }
        public string remarks { get; set; }
    }
}
