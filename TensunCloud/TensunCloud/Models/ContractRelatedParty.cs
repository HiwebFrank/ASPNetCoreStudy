using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{
    public class ContractRelatedParty
    {
        public int ID { get; set; }
        public int PartyID { get; set; }
        public int ContractID { get; set; }
        public PartyRelationType PartyRelationType { get; set; }

        public Party Party { get; set; }
        public Contract Contract { get; set; }
    }
}
