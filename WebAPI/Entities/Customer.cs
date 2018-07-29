using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Customer
    {
        public Customer()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string OtherName { get; set; }
        public string ResidentalDetail { get; set; }
        public string HouseNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string LivePeriod { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string NumOfDependant { get; set; }
        public string SalesReferenceNo { get; set; }
        public string CompanyReferenceNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Remark { get; set; }
        public string CustomerReference { get; set; }
        public decimal? TrustBalanceCl { get; set; }
        public decimal? Credit { get; set; }
        public int? BlacklistId { get; set; }
        public bool? IsInBlacklist { get; set; }
        public int? UserId { get; set; }
        public decimal? TrustBalanceCp { get; set; }
        public string Comment { get; set; }
        public int? SettingId { get; set; }
        public bool? Deleted { get; set; }
    }
}
