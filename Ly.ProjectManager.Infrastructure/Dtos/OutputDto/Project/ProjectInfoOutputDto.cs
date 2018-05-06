using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.ProjectManager.Infrastructure.Dtos.OutputDto.Project
{
    public class ProjectInfoOutputDto
    {
        public string projectGuid { get; set; }
        public string projectStatus { get; set; }
        public string projectName { get; set; }
        public string projectDesc { get; set; }
        public string projectTarget { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public string DevelopmentBackground { get; set; }
        //公共属性
        public string creatorUserId { get; set; }
        public DateTime? creatorDateTime { get; set; }
        public DateTime? lastModifyDateTime { get; set; }

        public int moduleTotal { get; set; }
        public int completeTotal { get; set; }
        public string teamName { get; set; }
        public string teamInfoGuid { get; set; }
    }
}
