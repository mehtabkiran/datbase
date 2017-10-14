using System;
using System.Collections.Generic;

namespace databasewithviews.Models
{
    public partial class Organizatiion
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgLoc { get; set; }
        public decimal OrgBudget { get; set; }
    }
}
