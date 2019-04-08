using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.Contexts
{
    public class TelephoneDirectoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}