using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Dto.ToDoItem
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
