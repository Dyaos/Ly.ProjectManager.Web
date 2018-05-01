using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._1.Infrastructure
{
    /// <summary>
    /// 公用删除属性
    /// </summary>
    public interface IDeleteAudited
    {
        /// <summary>
        /// 软删除标志
        /// </summary>
        [DefaultValue(false)]
        bool isDel { get; set; }
        /// <summary>
        /// 删除人编号
        /// </summary>
        string deleteUserId { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? deleteDateTime { get; set; }
    }
}
