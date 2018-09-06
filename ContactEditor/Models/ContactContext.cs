using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactEditor.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}