using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Login
{
    public class LoginOutputDto
    {
        public string accountGuid { get; set; }
        public string accountPwd { get; set; }
        public string accountNo { get; set; }
        public string accountName { get; set; }

        public bool isEnabled { get; set; }
        public bool IsSystem { get; set; }

        public string roleGuid { get; set; }
        public string roleName { get; set; }
    }
}
