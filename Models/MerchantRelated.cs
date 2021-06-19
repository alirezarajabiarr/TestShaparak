using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class MerchantRelated
    {
        public string firstNameFa { get; set; }
        public string lastNameFa { get; set; }
        public string fatherNameFa { get; set; }
        public string firstNameEn { get; set; }
        public string lastNameEn { get; set; }
        public string fatherNameEn { get; set; }
        public GenderEnum? gender { get; set; }
        public long? birthDate { get; set; }
        public long? registerDate { get; set; }
        public string nationalCode { get; set; }
        public string registerNumber { get; set; }
        public string comNameFa { get; set; }
        public string comNameEn { get; set; }
        public MerchantTypeEnum merchantType { get; set; }
        public ResidencyTypeEnum residencyType { get; set; }
        public VitalStatusEnum vitalStatus { get; set; }
        public long? birthCrtfctNumber { get; set; }
        public long? birthCrtfctSerial { get; set; }
        public long? birthCrtfctSeriesLetter { get; set; }
        public long? birthCrtfctSeriesNumber { get; set; }
        public string nationalLegalCode { get; set; }
        public string commercialCode { get; set; }
        public string countryCode { get; set; }
        public string foreignPervasiveCode { get; set; }
        public string passportNumber { get; set; }

        public long passportExpireDate { get; set; }
       // public string Description { get; set; }
        public string telephoneNumber { get; set; }
        public string cellPhoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string webSite { get; set; }
        public string fax { get; set; }
        public List<MerchantIban> merchantIbans { get; set; }
        public List<MerchantOfficer> merchantOfficers { get; set; }
        public RelationTypeEnum relationType { get; set; }
        public UpdateActionEnum updateAction { get; set; }



    }
}
