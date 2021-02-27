using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class DepartmentMember
    {
        [Key]
        public int DepartmentNo { get; set; }
        [Key]
        public string UserId { get; set; }

        public virtual Department DepartmentNoNavigation { get; set; }
    }
}
