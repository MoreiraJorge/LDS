using DAOproject.Data_Access;
using DAOproject.Interfces;
using DAOproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IConnection _connection;

        public PeopleController()
        {
           _connection = new Connection();
           _connection.Fetch();
        }

        //CRUD
        //Create
        [HttpPost]
        public IActionResult Create(Person person)
        {
            PersonDAO personDAO = new PersonDAO(_connection);
            personDAO.Create(person);

            return CreatedAtRoute("Get Person", new { id = person }, person);
        }

        //READ
        [HttpGet("{id}", Name = "Get Person")]
        public ActionResult<Person> GetById(long id)
        {
            PersonDAO personDAO = new PersonDAO(_connection);
            var person = personDAO.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            PersonDAO personDAO = new PersonDAO(_connection);
            return personDAO.GetAll().ToList();
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, Person person)
        {
            PersonDAO personDAO = new PersonDAO(_connection);
            var pOld = personDAO.FindByID(id);

            if (pOld == null)
            {
                return NotFound();
            }

            pOld.FirstName = person.FirstName;
            pOld.LastName = person.LastName;
            pOld.Email = person.Email;

            personDAO.Update(pOld);

            return NoContent();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonDAO personDAO = new PersonDAO(_connection);
            var toDel = personDAO.FindByID(id);

            if (toDel == null)
            {
                NotFound();
            }

            personDAO.Delete(toDel);
            return NoContent();
        }

    }
}