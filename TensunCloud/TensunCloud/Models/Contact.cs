using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TensunCloud.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public int PartyID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "姓名")]
        public string ContactName { get; set; }
        [StringLength(50)]
        [Display(Name = "职务")]
        public string Title { get; set; }
        
        [StringLength(50)]
        [Display(Name = "电话")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        [StringLength(50)]
        [Display(Name = "邮件地址")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "客户")]
        public Party Party { get; set; }
    }
}
