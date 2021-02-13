using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class OrderView
    {
        [Key]
        public int OrderNo { get; set; }
        public string OrderName { get; set; }
        public int SalesUserId { get; set; }
        public string SalesUserName { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
