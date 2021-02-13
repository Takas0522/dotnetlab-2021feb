using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class DepartmentMember
    {
        public int DepartmentNo { get; set; }
        public string UserId { get; set; }

        public virtual Department DepartmentNoNavigation { get; set; }
    }
}
