﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Administrador: Usuario
    {
        public Administrador(string mail, string contrasena) :base(mail, contrasena)
        { 
        }
    }
}
