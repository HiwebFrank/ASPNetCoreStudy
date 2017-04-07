using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{
    public class Party
    {
        public int ID { get; set; }
        public string PartyName { get; set; }
        // Manager ref to a ContactID
        public PartyType PartyType { get; set; }

        public ICollection<ProjectRelatedParty> ProjectRelatedParties { get; set; }
        public ICollection<ContractRelatedParty> ContractRelatedParties { get; set; }
        public ICollection<Contact> Contacts { get; set; }

    }
}
