using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._1.Infrastructure
{
    /// <summary>
    /// 修改公共属性
    /// </summary>
    public interface IModificationAudited
    {
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        string lastModifyUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? lastModifyDateTime { get; set; }
    }
}
