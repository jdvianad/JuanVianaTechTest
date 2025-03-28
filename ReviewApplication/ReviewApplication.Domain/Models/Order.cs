using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string State { get; set; }
        public Customer customer  { get; set; }

        public double Amount { get; set; }


    }
}
