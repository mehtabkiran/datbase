using System;
using System.Collections.Generic;

namespace databasewithviews.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProjname { get; set; }
        public string CustomerCity { get; set; }
    }
}
