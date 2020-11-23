using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly WebApplication1DbContext _context;

        public CustomersController(WebApplication1DbContext context)
        {
            _context = context;
        }

        //CRUD
        //Create
        [HttpPost]
        public async Task<Customer> InsertAsync(Customer obj)
        {
            await _context.Users.AddAsync(obj);
            await _context.SaveChangesAsync();

            //return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

            return await _context.Customers.FindAsync(obj.Id);
        }

        [HttpPut]
        [Route("{id}")]
        //public async Task updateAsync(int id, JsonObject json)
        public async Task updateAsync(int id, Car myCar)
        {
            Car car = await _context.Cars.FindAsync(myCar.Id);

            Customer c = await _context.Customers.FindAsync(id);
            c.AddCar(car);

            _context.Customers.Update(c);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Customer> FindByIdAsync(int id)
        {
            return await _context.Customers.Include(obj => obj.Cars).FirstOrDefaultAsync(obj => obj.Id == id);
        }
    }
}
