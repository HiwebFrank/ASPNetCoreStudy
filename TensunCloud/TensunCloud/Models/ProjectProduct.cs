using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TensunCloud.Models
{
    public class ProjectProduct
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int ProductID {get;set;}
        public int Qty { get; set; }

        public Project Project { get; set; }
        public Product Product { get; set; }


    }
}
