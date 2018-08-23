using System;

namespace WebAPI.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TradingName { get; set; }
        public String Industry { get; set; }
        public String OrganisationType { get; set; }
        public string GST { get; set; }
        public string Website { get; set; }
        public String Timezone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime? ValidDate { get; set; }
        public bool Initialized { get; set; }
    }
}
