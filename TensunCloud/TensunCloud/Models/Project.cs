using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TensunCloud.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TensunCloud.Models
{

    public class Project
    {
        public int ID { get; set; }
        [Display(Name = "项目名称")]
        public string ProjectName { get; set; }
        [Display(Name = "项目类型")]
        public ProjectType ProjectType { get; set; }
        [EnumDataType(typeof(Province))]
        [Display(Name = "项目省份")]
        public Province Province { get; set; }
        [Display(Name = "项目区域")]
        public TSRegion Region { get; set; }
        [Display(Name = "启动日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "交付日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "项目状态")]
        public ProjectStatus Status { get; set; }

        public ICollection<ProjectProduct> ProjectProducts { get; set; }
        public ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; }
        public ICollection<ProjectRelatedParty> ProjectRelatedParties { get; set; }
        public ICollection<ProjectContract> ProjectContracts { get; set; }
    }
}
