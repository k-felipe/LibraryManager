using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Models
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public int Id {  get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

    }
}
