﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_asp.net_mvc.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int salary {  get; set; }
        public string city {  get; set; }
    }
}