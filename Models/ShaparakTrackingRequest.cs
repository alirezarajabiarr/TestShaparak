using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class ShaparakTrackingRequest
    {
        public List<string> trackingNumberPsps { get; set; }
        public List<string> trackingNumbers { get; set; }
        public List<long> statuses { get; set; }
        public List<RequstTypeEnum> requestTypes { get; set; }

        public List<long> requestDate { get; set; }

    }
}
