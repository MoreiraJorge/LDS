using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected User()
            : base()
        {
        }

        [JsonConstructor]
        protected User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


}
