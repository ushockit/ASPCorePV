using Services.Abstractions.Dto.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Dto.ToDoItem
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AccountId { get; set; }
        public AccountDto Account { get; set; }
    }
}
