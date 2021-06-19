using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class Acceptor
    {
        public string iin { get; set; }
        public string acceptorCode{ get; set; }
        public AcceptorTypeEnum acceptorType { get; set; }
        public string facilitatorAcceptorCode { get; set; }
        public bool cancelable { get; set; }
        public bool refundable { get; set; }
        public bool blockable { get; set; }
        public bool chargeBackable { get; set; }
        public bool settledSeparately { get; set; }
        public  AllowScatteredSettlementEnum  allowScatteredSettlement  { get; set; }
        public bool acceptCreditCardTransaction { get; set; }
        public bool allowIranianProductsTrx { get; set; }
        public bool allowKaraCardTrx { get; set; }
        public bool allowGoodsBasketTrx { get; set; }
        public bool allowFoodSecurityTrx { get; set; }
        public bool allowJcbCardTrx { get; set; }
        public bool allowUpiCardTrx { get; set; }
        public bool allowVisaCardTrx { get; set; }
        public bool allowMasterCardTrx { get; set; }
        public bool allowAmericanExpressTrx { get; set; }
        public bool allowOtherInternationaCardsTrx { get; set; }
        public  List<Terminal> terminals  { get; set; }
        public List<string> shaparakSettlementIbans { get; set; }
       // public string Description { get; set; }

        public UpdateActionEnum updateAction { get; set; }



























    }
}
