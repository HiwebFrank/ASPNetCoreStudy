using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{
    public class ProjectRelatedParty
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int PartyID { get; set; }
        public PartyRelationType PartyRelationType { get; set; }

        public Project Project { get; set; }
        public Party Party { get; set; }
    }
}
