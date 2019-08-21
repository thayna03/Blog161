﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User: IdentityUser    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Mensagem> Mensagems { get; set; }
    }
}
