using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Storage.Models;

namespace WebApplication1.Storage
{
    public class UsersStorage
    {
        public List<Person> People { get; } = new List<Person>();

        public UsersStorage()
        {
            for (int i = 0; i < 15; i++)
            {
                People.Add(new Person
                {
                    Id = i + 1,
                    FirstName = $"First name {i + 1}",
                    LastName = $"Last name {i + 1}",
                    Birth = DateTime.Now,
                    Disabled = false
                });
            }

            People[0].Disabled = true;
            People[7].Disabled = true;
            People[3].Disabled = true;
        }

        public void DisablePerson(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);
            if (person is not null)
            {
                person.Disabled = true;
            }
        }
    }
}
