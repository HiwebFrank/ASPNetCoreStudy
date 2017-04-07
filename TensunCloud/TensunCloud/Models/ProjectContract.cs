using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TensunCloud.Models
{
    public class ProjectContract
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int ContractID { get; set; }

        public Project Project { get; set; }
        public Contract Contract { get; set; }
    }
}
