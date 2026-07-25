using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Entities
{
    public class User
    {
        public enum UserRole { Client, Admin }
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
