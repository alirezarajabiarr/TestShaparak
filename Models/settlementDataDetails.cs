using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class settlementDataDetails
    {
        public long iin { get; set; }
        public string acceptorCode { get; set; }
        public string paymentFacilitatorIban { get; set; }
        public long settlementAmount { get; set; }//mablagh tasvih
        public long wageAmount { get; set; }//karmozd
        public string settlementIban { get; set; }
    
    }
}
