using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegacyApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
