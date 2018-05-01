using Ly.ProjectManager.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Data.Repository
{
    public class CommonRepositoryBase : ICommonRepositoryBase
    {
        private ProjectManagerDbContext dbcontext = new ProjectManagerDbContext();

        public void Dispose()
        {
            dbcontext.Dispose();
        }
        public async Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql) where DtoEntity : class
        {
            return await FindListAsync<DtoEntity>(strSql, null);
        }

        public async Task<IList<DtoEntity>> FindListAsync<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class
        {

            return await Task.Run(() => dbcontext.Database.SqlQuery<DtoEntity>(strSql, dbParameter.ToArray()).AsQueryable().ToList());
        }

        public IList<DtoEntity> FindList<DtoEntity>(string strSql) where DtoEntity : class
        {
            return FindList<DtoEntity>(strSql, null);
        }
        public IList<DtoEntity> FindList<DtoEntity>(string strSql, IList<SqlParameter> dbParameter) where DtoEntity : class
        {
            return dbcontext.Database.SqlQuery<DtoEntity>(strSql, dbParameter.ToArray()).ToList<DtoEntity>();
        }
    }
}
