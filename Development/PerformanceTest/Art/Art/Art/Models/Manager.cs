using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Models
{
    public class Manager
    {
        private artEntities _db;
        public Manager() 
        {
            _db = new artEntities();
        }

    }
}