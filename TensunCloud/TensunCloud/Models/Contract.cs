using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TensunCloud.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [StringLength(200)]
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="签订日期")]
        public DateTime SignDate { get; set; }
        [Display(Name = "合同金额")]
        [DataType(DataType.Currency)]
        public float Amount { get; set; }

        public ICollection<ProjectContract> ProjectContracts { get; set; }
        public ICollection<ContractRelatedParty> ContractRelatedParties { get; set; }
    }
}

