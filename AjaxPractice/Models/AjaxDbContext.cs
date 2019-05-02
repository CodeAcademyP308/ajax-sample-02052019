using AjaxPractice.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxPractice.Models
{
    public class AjaxDbContext : DbContext
    {
        public AjaxDbContext()
            :base("name=cString")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}