using Ly.ProjectManager.Data.Repository;
using Ly.ProjectManger.Application._2.IApplication;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application
{
    /// <summary>
    /// 执行sql（存储过程）
    /// </summary>
    public class CommonApp : ICommonApp
    {
        private ICommonRepositoryBase common;

        public async Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql) where DtoEntity : class
        {
            return await common.FindListAsync<DtoEntity>(strSql);
        }

        public async Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class
        {
            return await common.FindListAsync<DtoEntity>(strSql, dbParameter);
        }

        public IList<DtoEntity> FindList<DtoEntity>(string strSql) where DtoEntity : class
        {
            return common.FindList<DtoEntity>(strSql);
        }
        public IList<DtoEntity> FindList<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class
        {
            return common.FindList<DtoEntity>(strSql, dbParameter);
        }
    }
}
