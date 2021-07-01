using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_03.Controllers
{
    public class PeopleController : Controller
    {
        static List<Person> people = new List<Person>
        {
            new Person { Id = 1, FirstName = "First name 1", LastName = "Last name 1", Birth = new DateTime(1990, 10, 15) },
            new Person { Id = 2, FirstName = "First name 2", LastName = "Last name 2", Birth = new DateTime(1978, 01, 1) },
            new Person { Id = 3, FirstName = "First name 3", LastName = "Last name 3", Birth = new DateTime(1995, 11, 11) },
            new Person { Id = 4, FirstName = "First name 4", LastName = "Last name 4", Birth = new DateTime(1976, 08, 19) },
            new Person { Id = 5, FirstName = "First name 5", LastName = "Last name 5", Birth = new DateTime(1992, 12, 05) },
            new Person { Id = 6, FirstName = "First name 6", LastName = "Last name 6", Birth = new DateTime(1995, 01, 27)}
        };
        public IActionResult Index()
        {
            // передача данных в представление
            ViewBag.PeopleList = people;
            return View();
        }

        // [HttpGet]
        public IActionResult Info(int? id)
        {
            if (id is null)
            {
                return BadRequest("Missing id param");
            }
            var person = people.FirstOrDefault(person => person.Id == id);
            if (person is null)
            {
                return BadRequest("Person wasn`t found!");
            }
            ViewData["viewPerson"] = person;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            person.Id = people.Count > 0 ? people.Last().Id + 1 : 1;
            people.Add(person);
            return RedirectToAction("index");
        }
    }
}
