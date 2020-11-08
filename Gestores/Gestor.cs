using appExamen1Laboratorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Examen1.Laboratorio.Clases;

namespace appExamen1Laboratorio.Gestores
{
    class Gestor : IGestor
    {
        private Laboratorio _laboratorio=new Laboratorio();

        public string getXML()
        {
            return _laboratorio.getXML();
        }

        void IGestor.AddPaciente(Paciente oPaciente)
        {
            _laboratorio.AddPaciente(oPaciente);
        }
    }
}
