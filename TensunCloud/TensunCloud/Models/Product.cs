using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;

namespace TensunCloud.Models
{

    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public ProductCatalog ProductCatalog { get; set; }
        public string ProductModel { get; set; }
        public string ProductParameter { get; set; }
        public string ProductDesc { get; set; }

        public ICollection<ProjectProduct> ProjectProducts { get; set; }

    }
}
