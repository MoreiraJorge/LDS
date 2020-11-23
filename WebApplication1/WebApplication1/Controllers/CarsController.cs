using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CarsController : ControllerBase
    {
        private readonly WebApplication1DbContext _context;

        public CarsController(WebApplication1DbContext context)
        {
            _context = context;
        }

        //CRUD
        //Create
        [HttpPost]
        public async Task<Car> InsertAsync(Car obj)
        {
            await _context.Cars.AddAsync(obj);
            await _context.SaveChangesAsync();

            return await _context.Cars.FirstOrDefaultAsync(car => car.Id == obj.Id);
        }
        /*
        [HttpPost]
        public IActionResult Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();

            return CreatedAtRoute("Get Car", new { id = car.Id }, car);
        }

       
        //Get
        [HttpGet("{id}", Name = "Get Car")]
        public ActionResult<Car> GetById(long id)
        {
            var car = _context.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return car;
        }
        */
    }
}
