using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Admin : User
    {
        public string Role { get; set; }

        public Admin()
            : base()
        {
        }

        public Admin(int id, string name, string role)
            : base(id, name)
        {
            Role = role;
        }
    }
}
