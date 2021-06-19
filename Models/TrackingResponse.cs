using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
   
  
    public class RequestRejectionReason
    {
        public long? codeExceptionValue { get; set; }
        public string fieldName { get; set; }
    }

    public class TrackingResponses
    {
        public string trackingNumber { get; set; }
        public string trackingNumberPsp { get; set; }
        public long requestDate { get; set; }
        public string description { get; set; }
        public RequstTypeEnum requestType { get; set; }
        public Merchant merchant { get; set; }
        public MerchantRelated relatedMerchants { get; set; }
        public List<RequestRejectionReason> requestRejectionReasons { get; set; }
        //public object requestDetails { get; set; }
        public int status { get; set; }
    }

    public class TrackingResponse
    {
        public List<TrackingResponses> tracks { get; set; }
    }
}
