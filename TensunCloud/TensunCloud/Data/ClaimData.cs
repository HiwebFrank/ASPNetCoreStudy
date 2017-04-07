using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TensunCloud.Data
{
    public static class ClaimData
    {
        public static List<string> TSClaims { get; set; } = new List<string> { "SysAdmin", "ProductAdmin", "ProjectAdmin" ,"CustomerAdmin","Readers"};
    }
}
