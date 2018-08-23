using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Role> Roles { get; set; }
    }
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
