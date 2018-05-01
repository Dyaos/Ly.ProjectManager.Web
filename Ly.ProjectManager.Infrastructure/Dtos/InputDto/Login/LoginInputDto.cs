using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Infrastructure.Dtos.InputDto.Login
{
    public class LoginInputDto
    {
        public int accountType { get; set; }
        public string cardPwd { get; set; }
        public string cardNo { get; set; }
        public string validCode { get; set; }
    }
}
