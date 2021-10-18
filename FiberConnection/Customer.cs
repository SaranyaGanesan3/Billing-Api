using System;
using System.Collections.Generic;

#nullable disable

namespace BillingAPI.FiberConnection
{
    public partial class Customer
    {
        public Customer()
        {
            Billings = new HashSet<Billing>();
            Statuses = new HashSet<Status>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAadharNo { get; set; }
        public string CustomerMailId { get; set; }
        public string CustomerPassword { get; set; }

        public virtual ICollection<Billing> Billings { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}
