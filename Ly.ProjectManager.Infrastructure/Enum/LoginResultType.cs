using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Infrastructure.Enum
{
    public enum LoginResultType
    {
        loginFail = -201,//登录错误
        loginSuccess = 200,//登录成功
        loginPwdError = -202,//密码错误
        loginNotExist = -404,//不存在该用户
        loginOverTime = -203,//登录超时
        loginLogout = -204,//退出登录
        loginLocking = -205//被锁住
    }
}
