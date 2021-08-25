using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Dto.ToDoItem
{
    public class CreateToDoItemDto
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool Completed { get; set; }
    }
}
