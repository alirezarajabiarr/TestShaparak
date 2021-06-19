using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class ShaparakTrackingResponse
    {
        public string trackingNumberPsp { get; set; }
        public string trackingNumbers { get; set; }
        public long Status { get; set; }
        public long? requestDate { get; set; }

        //public string description { get; set; }
        public long requestType { get; set; }
        public string merchant { get; set; }
        public List<MerchantRelated> relatedMerchants { get; set; }
        public List<long> requestRejectionReasons { get; set; }

        //requestDetails









    }
}
