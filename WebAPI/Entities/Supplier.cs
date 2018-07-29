using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
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
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Boolean Deleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
