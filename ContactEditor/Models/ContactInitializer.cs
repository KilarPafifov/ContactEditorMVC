using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ContactEditor.Models
{
    public class ContactInitializer : DropCreateDatabaseAlways<ContactContext>
    {
        protected override void Seed(ContactContext contactContext)
        {
            contactContext.Contacts.Add(new Contact
            {
                ContactId = 1,
                Person = "ivan",
                Phone = "555555",
                PathToImage = "/Content/Images/jp.jpg"
            }
            );

            contactContext.Contacts.Add(new Contact
            {
                ContactId = 2,
                Person = "petr",
                Phone = "888888",
                PathToImage = "/Content/Images/goroda-pejzazh-46355.jpg"
            }
            );
        }
    }
}