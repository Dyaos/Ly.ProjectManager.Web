using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._1.Infrastructure
{
    public interface ICommonProperty
    {
        /// <summary>
        /// 排序码
        /// </summary>
        Nullable<int> sortCode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        Nullable<bool> isEnabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        string remarks { get; set; }
    }
}
