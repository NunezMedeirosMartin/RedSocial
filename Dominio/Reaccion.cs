using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Reaccion
    {
        public bool MeGusta { get; set; }
        public Miembro Autor { get; set; }

        public Reaccion(bool meGusta, Miembro autor)
        {
            MeGusta = meGusta;
            Autor = autor;
        }

    }
}
