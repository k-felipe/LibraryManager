﻿using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; } 

        public User ToEntity() => new(Name, Email);

    }
}
