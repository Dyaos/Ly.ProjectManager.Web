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
    /// 答辩负责人
    /// </summary>
    [Table("DefencePersonCharge")]
    public class DefencePersonChargeEntity : IEntity<DefencePersonChargeEntity>, ICreationAudited, IModificationAudited, IDeleteAudited, ICommonProperty
    {
        //自定义属性
        [Key]
        public string personChargeGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int personChargeIdentity { get; set; }
        /// <summary>
        /// 负责人名字
        /// </summary>
        public string personChargeName { get; set; }
        /// <summary>
        /// 负责人信息编号
        /// </summary>
        public string accountInfoGuid { get; set; }
        /// <summary>
        /// 负责人类型 产品经理 项目经理
        /// </summary>
        public string personChargeType { get; set; }

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
