using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    class Influenza:Virus
    {
        public override string GetTratamiento() {
            return "baloxavir marboxil, té equinácea, jengibre y sauco";
        }
    }
}
