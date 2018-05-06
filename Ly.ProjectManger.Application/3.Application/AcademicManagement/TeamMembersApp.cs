using Ly.ProjectManager.Data.Application;
using Ly.ProjectManager.Domain._2.Entity;
using Ly.ProjectManager.Repository._1.IRepository.AcademicManagement;
using Ly.ProjectManger.Application._2.IApplication.AcademicManagement;
using Ly.ProjectManger.Application._2.IApplication.SystemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManger.Application._3.Application.AcademicManagement
{
    public class TeamMembersApp : ITeamMembersApp
    {
        private ITeamMembersRepository teamMembersRepository;
        private IAccountRoleApp accountRoleApp;
        private IRoleApp roleApp;
        public TeamMembersApp(ITeamMembersRepository teamMembersRepository, IAccountRoleApp accountRoleApp, IRoleApp roleApp)
        {
            this.teamMembersRepository = teamMembersRepository;
            this.accountRoleApp = accountRoleApp;
            this.roleApp = roleApp;
        }
        public void DeleteForm(string keyValue)
        {
            teamMembersRepository.Delete(c => c.membersGuid == keyValue);
        }

        public IList<TeamMembersEntity> FindList(Expression<Func<TeamMembersEntity, bool>> predicate)
        {
            return teamMembersRepository.IQueryable(predicate).ToList();
        }

        public void SubmitForm(TeamMembersEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(entity.membersGuid))
            {
                var count = FindList(c => c.isEnabled && c.teamInfoGuid == keyValue).Count();
                if (count >= 5)
                {
                    throw new Exception("每个团队中团队成员不能超过4个！！！");
                }
                var account = entity.membersName.Split('&');
                entity.Create();
                entity.accountInfoGuid = account[0];
                entity.membersName = account[1];
                entity.teamInfoGuid = keyValue;
                entity.membersFunction = "组员";
                teamMembersRepository.Insert(entity);
            }
            else
            {
                var lenderEntity = FindList(c => c.isEnabled && c.membersFunction == "组长" && c.teamInfoGuid == keyValue).FirstOrDefault();
                var roleEntity = roleApp.FindEntity(c => c.isEnabled && c.roleName.Contains("组长"));
                entity.membersFunction = "组长";

                //该团队对没有组长
                if (lenderEntity == null)
                {
                    var menbersGuid = entity.membersGuid;
                    entity.Modify(menbersGuid);
                    entity.teamInfoGuid = keyValue;

                    var accountRoleEntity = new AccountRoleEntity()
                    {
                        accountInfoGuid = entity.accountInfoGuid,
                        roleInfoGuid = roleEntity.roleGuid
                    };

                    accountRoleEntity.Create();
                    accountRoleApp.SubmitForm(accountRoleEntity, "");
                    teamMembersRepository.Update(entity);

                }

                //该团队对有组长
                if (lenderEntity != null && !lenderEntity.membersGuid.Equals(entity.membersGuid))
                {
                    var accountRoleEntityList = accountRoleApp.FindList(lenderEntity.accountInfoGuid);
                    var accountRoleEntity = accountRoleEntityList.Where(c => c.roleInfoGuid == roleEntity.roleGuid).FirstOrDefault();
                    accountRoleEntity.accountInfoGuid = entity.accountInfoGuid;
                    accountRoleApp.SubmitForm(accountRoleEntity, accountRoleEntity.accountRoleGuid);

                    lenderEntity.membersFunction = "组员";
                    lenderEntity.Modify(lenderEntity.membersGuid);
                    entity.Modify(entity.membersGuid);

                    using (var db = teamMembersRepository.BeginTrans())
                    {
                        db.Update(lenderEntity);
                        db.Update(entity);
                        db.Commit();
                    }
                }
            }
        }
    }
}
