using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.People
{
    public class CreateNewPersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Avatar { get; set; }
        public DateTime Birth { get; set; }
    }
}
