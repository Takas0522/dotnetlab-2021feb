using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class Sample
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
