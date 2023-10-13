using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaxPayer
    {
        public Guid Id { get; set; }
        public string Identity{ get; set; }
        public string Address{ get; set; }
        public string NaceCode{ get; set; }
        //emukellefiyet
        public string Obligation{ get; set; } 
        public string Application { get; set; }
            

    }
}
