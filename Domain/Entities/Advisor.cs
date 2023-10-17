using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Advisor : BaseEntity
    {
        public Address Addresses { get; set; }
        public Contact Contact { get; set; }
        public List<TaxPayer> TaxPayers  { get; set; }
    }
}
