using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoutik.Areas.Boutik.Models
{
    public class logger
    {
        private string _name;
        private string _firstName;
        private string _email;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public logger(string name, string firstName, string email)
        {
            this.Name = name;
            this.FirstName = firstName;
            this.Email = email;
        }
    }
}