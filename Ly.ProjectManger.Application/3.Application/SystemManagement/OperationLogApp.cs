using Ly.ProjectManager.Code;
using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.SystemManagement;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.SystemManagement
{
    public class OperationLogApp : IOperationLogApp
    {
        private IOperationLogRepository logRepository;
        public OperationLogApp(IOperationLogRepository logRepository)
        {
            this.logRepository = logRepository;
        }
        public void DeleteForm(string keyValue)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFormAsync(string keyValue)
        {
            throw new NotImplementedException();
        }

        public OperationLogEntity FindEntity(string keyValue)
        {
            return logRepository.FindEntity(keyValue);
        }

        public IList<OperationLogEntity> FindList(Pagination pagination, string queryJson)
        {
            var expre = ExtLinq.True<OperationLogEntity>();
            var param = queryJson.ToJObject();
            if (!param["keyword"].IsEmpty())
            {
                string type = param["keyword"].ToString();
                expre = expre.And(o => o.operationDesc.Contains(type));
            }
            if (!param["timeType"].IsEmpty())
            {
                string timeType = param["timeType"].ToString();
                DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
                DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expre = expre.And(t => t.creatorDateTime >= startTime && t.creatorDateTime <= endTime);
            }
            return logRepository.FindList(expre, pagination);
        }

        public void SubmitForm(OperationLogEntity entity, string keyValue)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SubmitFormAsync(OperationLogEntity entity, string keyValue)
        {
            return await logRepository.InsertAsync(entity);
        }
    }
}
