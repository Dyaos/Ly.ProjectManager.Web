using Ly.ProjectManager.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Domain._1.Infrastructure
{
    public class IEntity<TEntity>
    {
        /// <summary>
        /// 创建
        /// </summary>
        public void Create()
        {
            var entity = this as ICreationAudited;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.creatorUserId = LoginInfo.UserId;
            }
            entity.creatorDateTime = DateTime.Now;
            //设置主键
            SetPrimaryKeyValue(Common.GuId());
        }
        /// <summary>
        /// 修改
        /// </summary>
        public void Modify(string keyValue)
        {
            var entity = this as IModificationAudited;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.lastModifyUserId = LoginInfo.UserId;
            }
            entity.lastModifyDateTime = DateTime.Now;

            SetPrimaryKeyValue(keyValue);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Remove(string keyValue)
        {
            var entity = this as IDeleteAudited;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.deleteUserId = LoginInfo.UserId;
            }
            entity.deleteDateTime = DateTime.Now;
            entity.isDel = true;
            SetPrimaryKeyValue(keyValue);
        }
        /// <summary>
        /// 设置主键的值
        /// </summary>
        /// <param name="keyValue">Guid 编号的字符串形式的值</param>
        private void SetPrimaryKeyValue(string keyValue)
        {
            //获取属性集合
            var properties = typeof(TEntity).GetProperties();
            //第一个属性是主键
            if (properties[0].CustomAttributes.Where(c => c.AttributeType == typeof(KeyAttribute)).Count() != 0)
            {
                properties[0].SetValue(this, keyValue, null);
            }
            else
            {
                throw new Exception("请为第一个属性设置为主键标识（KeyAttribute）！");
            }
        }
    }
}
