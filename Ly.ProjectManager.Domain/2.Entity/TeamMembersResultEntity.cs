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
    /// 团队成员答辩
    /// </summary>
    [Table("TeamMembersResult")]
    public class TeamMembersResultEntity : IEntity<TeamMembersResultEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        [Key]
        public string memberResultGuid { get; set; }
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int memberResultIdentity { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        public string memberResultEvaluate { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public string memberResultScore { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public string lastModifyUserId { get; set; }
        public DateTime? lastModifyDateTime { get; set; }
        public bool isDel { get; set; }
        public string deleteUserId { get; set; }
        public DateTime? deleteDateTime { get; set; }

        //外键属性
        public string teamMembersInfoGuid { get; set; }
    }
}
