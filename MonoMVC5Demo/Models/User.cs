﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoMVC5Demo.Models
{
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }

        public string email { get; set; }
    }
}