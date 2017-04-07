using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{
    public class ProjectTeamMember
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public TeamMemberType TeamMemberType { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }


    }
}
