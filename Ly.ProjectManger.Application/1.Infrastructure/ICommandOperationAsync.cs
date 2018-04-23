using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.Application
{
    public interface ICommandOperationAsync<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 增加或更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keyValue"></param>
        void SubmitFormAsync(TEntity entity, string keyValue);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        void DeleteFormAsync(string keyValue);
    }
}
