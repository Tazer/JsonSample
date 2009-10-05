using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Code.Model
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Done { get; set; }

    }
}