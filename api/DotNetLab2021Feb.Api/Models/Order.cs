using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetLab2021Feb.Api.Models
{
    public partial class Order
    {
        public int OrderNo { get; set; }
        public string OrderName { get; set; }
        public int SalesUserId { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
