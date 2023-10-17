using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaxPayer : BaseEntity
    {        
        public string NaceCode { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Contact> Contacts  { get; set; }                
        //emukellefiyet
        public List<Obligation> Obligations { get; set; } 
        public List<BusinessApplication> BusinessApplications { get; set; }

    }
}
