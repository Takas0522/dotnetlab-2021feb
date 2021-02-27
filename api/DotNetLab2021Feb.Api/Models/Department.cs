using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentMembers = new HashSet<DepartmentMember>();
        }

        [Key]
        public int DepartmentNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DepartmentMember> DepartmentMembers { get; set; }
    }
}
