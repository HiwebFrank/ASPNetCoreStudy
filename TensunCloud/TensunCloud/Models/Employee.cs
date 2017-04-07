using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{
    
    public class Employee
    {
        public int ID { get; set; }
        public string AspNetUsersID { get; set; }
        public string EmpName { get; set; }
        public TSDept? Dept { get; set; }
        public TSTitle? Title { get; set; }
        public ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }



    }
}
