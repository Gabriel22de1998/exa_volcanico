﻿using appExamen1Laboratorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    class Hombre:Paciente,IPresionAlta
    {
        public bool PrecionAlta { get; set; }
    }
}
