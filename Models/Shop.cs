using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShaparak.Models
{
    public class Shop
    {
        public string farsiName { get; set; }
        public string englishName { get; set; }
        public string telephoneNumber { get; set; }
        public string postalCode { get; set; }
        public string businessCertificateNumber { get; set; }
        public long? certificateIssueDate { get; set; }
        public long? certificateExpiryDate { get; set; }
        //public string Description { get; set; }
        public string businessCategoryCode { get; set; }
        public string businessSubCategoryCode { get; set; }
        public OwnershipTypeEnum ownershipType { get; set; }
        public string rentalContractNumber { get; set; }
        public long? rentalExpiryDate { get; set; }
        public string address { get; set; }
        public string countryCode { get; set; }
        public string provinceCode { get; set; }
        public string cityCode { get; set; }
        public BusinessTypeEnum businessType { get; set; }
        public EtrustCertificateTypeEnum etrustCertificateType { get; set; }
        public long? etrustCertificateIssueDate { get; set; }
        public long? etrustCertificateExpiryDate { get; set; }
        public string emailAddress { get; set; }
        public string websiteAddress { get; set; }
        public string taxPayerCode { get; set; }

        
        public UpdateActionEnum updateAction { get; set; }


    }
}
