using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._2.IApplication
{
    /// <summary>
    /// 执行sql（存储过程）
    /// </summary>
    public interface ICommonApp
    {
        IList<DtoEntity> FindList<DtoEntity>(string strSql) where DtoEntity : class;
        Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql) where DtoEntity : class;
        IList<DtoEntity> FindList<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class;
        Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class;
    }
}
