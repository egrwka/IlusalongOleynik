using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OleynikProject.Models
{
    public class Context : DbContext
    {
        public Context() : base("Db") { }
        public DbSet<Service> Service { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}