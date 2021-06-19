using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    [DataContract]
    [Serializable]
    public class ShaparakRequest
    {
        public ShaparakRequest() { }
        public string trackingNumberPsp { get; set; }
        public RequstTypeEnum requestType { get; set; }
        public Merchant merchant { get; set; }

        public List<MerchantRelated> relatedMerchants { get; set; }
        public Contract contract { get; set; }
        public List<ShopAcceptor> pspRequestShopAcceptors { get; set; }
       // public string Description { get; set; }

        
    }
}
