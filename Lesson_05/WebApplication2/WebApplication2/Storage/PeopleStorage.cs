using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Storage.Models;

namespace WebApplication2.Storage
{
    public class PeopleStorage
    {
        public List<Person> People { get; } = new List<Person>();

        public PeopleStorage()
        {
            for (int i = 0; i < 15; i++)
            {
                People.Add(new Person
                {
                    Id = i + 1,
                    FirstName = $"First name {i + 1}",
                    LastName = $"Last name {i + 1}",
                    Avatar = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/PNG_transparency_demonstration_1.png/274px-PNG_transparency_demonstration_1.png",
                    Birth = DateTime.Now
                });
            }
        }
    }
}
