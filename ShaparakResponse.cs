using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak
{
   
    public class RequestRejectionReason
    {
        public long? codeExceptionValue { get; set; }
        public string fieldName { get; set; }
    }

    public class ShaparakResponse
    {
        public long? trackingNumber { get; set; }
        public string trackingNumberPsp { get; set; }
        public List<RequestRejectionReason> requestRejectionReasons { get; set; }
        public bool? success { get; set; }
    }

    
}
