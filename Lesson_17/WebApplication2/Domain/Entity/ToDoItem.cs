using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ToDoItem : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool Completed { get; set; }
    }
}
