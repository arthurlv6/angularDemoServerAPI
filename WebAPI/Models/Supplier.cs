using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SupplierModel
    {
        public SupplierModel()
        {
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
        public string GSTNumber { get; set; }
        public string Note { get; set; }
        public string TaxRate { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string PaymentTerm { get; set; }
        public string PhysicalName { get; set; }
        public string PhysicalStreetAddress { get; set; }
        public string PhysicalSuburb { get; set; }
        public string PhysicalCity { get; set; }
        public string PhysicalState { get; set; }
        public string PhysicalCountry { get; set; }
        public string PhysicalPostalCode { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOfficePhone { get; set; }
        public string ContactWebsite { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactMobileNumber { get; set; }
        public string ContactDDINumber { get; set; }
        public string ContactTollFreeNumber { get; set; }
        public string Profile { get; set; }
    }
}
