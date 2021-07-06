using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.People;
using WebApplication2.Services;
using WebApplication2.Storage;

namespace WebApplication2.Controllers
{
    public class PeopleController : Controller
    {
        PeopleStorage _peopleStorage;
        IFileUpload _fileUpload;

        public PeopleController(IFileUpload fileUpload, PeopleStorage peopleStorage)
        {
            _peopleStorage = peopleStorage;
            _fileUpload = fileUpload;
        }

        public IActionResult Index()
        {
            return View(new PeopleIndexViewModel { People = _peopleStorage.People });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewPersonViewModel person)
        {
            // TODO: Server validation
            string avatar = await _fileUpload.Upload(person.Avatar);
            _peopleStorage.People.Add(new Storage.Models.Person
            {
                Id = new Random().Next(100, 50_000),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Avatar = avatar,
                Birth = person.Birth
            });
            return RedirectToAction("Index");
        }
    }
}
