using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ToDoItem : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
    }
}
