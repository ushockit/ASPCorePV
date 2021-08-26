﻿using Services.Abstractions.Dto.ToDoItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions.Dto.Account
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Confirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ToDoItemDto> Todos { get; set; }
    }
}
