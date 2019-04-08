using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.Models
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel()
        {
            this.User = new User();
        }
    }
}