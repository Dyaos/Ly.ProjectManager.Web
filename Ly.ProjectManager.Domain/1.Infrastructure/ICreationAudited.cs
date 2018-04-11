using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._1.Infrastructure
{
    public interface ICreationAudited
    {
        /// <summary>
        /// 创建者用户编号
        /// </summary>
        string creatorUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? creatorDateTime { get; set; }
    }
}
