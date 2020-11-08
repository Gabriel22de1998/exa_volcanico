using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    class H1N1:Virus
    {
        public override string GetTratamiento() {
            return "Oseltamivir, Zanamivir , Peramivir y Baloxavir";
        }
    }
}
