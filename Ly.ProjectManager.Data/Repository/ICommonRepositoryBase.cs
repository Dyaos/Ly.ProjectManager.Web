using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.Repository
{
    public interface ICommonRepositoryBase:IDisposable
    {
        IList<DtoEntity> FindList<DtoEntity>(string strSql) where DtoEntity : class;
        Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql) where DtoEntity : class;
        IList<DtoEntity> FindList<DtoEntity>(string strSql, IList<DbParameter> dbParameter) where DtoEntity : class;
        Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql, IList<DbParameter> dbParameter) where DtoEntity : class;
    }
}
