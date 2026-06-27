using PP11.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PP11.Models
{
    internal class User
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Login { get; set; }

        
        public string Password { get; set; }

        public string Role { get; set; }

        public string Filial { get; set; }

        public string Email { get; set; }

        public DateTime? LastEnter { get; set; } 

        public bool? Activity {  get; set; }


        public User( string fIO, string login, string password, string role, string filial, string email, DateTime? lastEnter, bool? activity)
        {

            FIO = fIO;
            Login = login;
            Password = password;
            Role = role;
            Filial = filial;
            Email = email;
            LastEnter = lastEnter;
            Activity = activity;
        }
        public User() { }
    }
}
