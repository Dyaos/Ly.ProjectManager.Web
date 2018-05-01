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
    /// 操作日志
    /// </summary>
    [Table("OperationLog")]
    public class OperationLogEntity : IEntity<OperationLogEntity>, ICreationAudited
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
        /// <summary>
        /// 日志等级
        /// </summary>
        public string logLevel { get; set; }
        /// <summary>
        /// 线程
        /// </summary>
        public string logThread { get; set; }
        /// <summary>
        /// 日志名称
        /// </summary>
        public string logName { get; set; }
        /// <summary>
        /// 操作人Ip
        /// </summary>
        public string operationIP { get; set; }
        //被操作的表格
        public string operationTable { get; set; }
        /// <summary>
        /// 被操作的模块编号
        /// </summary>
        public string operationModuleGuid { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string operationType { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string operationDesc { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }

    }
}
