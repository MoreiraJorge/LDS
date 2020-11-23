using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer : User
    {
        public string Email { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();

        public Customer()
            : base()
        {
        }

        [JsonConstructor]
        public Customer(int id, string name, string email)
            : base(id, name)
        {
            Email = email;
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
    }
}
