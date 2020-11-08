using appExamen1Laboratorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;

namespace UTN.Winform.Examen1.Laboratorio.Clases
{
    class Laboratorio : ILaboratorio
    {
        public List<ExamenMedico> _ListaExamenMedicos = new List<ExamenMedico>();
        public List<Paciente> _ListaPaciente = new List<Paciente>();


        public void AddPaciente(Paciente oPaciente)
        {
            _ListaPaciente.Add(oPaciente);
        }
        
        private void DetectVirus() {

            foreach (var item in _ListaPaciente)
            {
                string aux = "";

                //para covid
                string muestra = item._Muestra.ARN;
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    //byte a hash byte[]
                    byte[] hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(muestra));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        builder.Append(hashValue[i].ToString("x2"));
                    }
                    aux = builder.ToString();
                }

                if ((aux).Equals("e16c10d6569ac7c8bbf8133d961f0e5a43e89eee5c530621dc68fed99753148a"))
                {
                    ExamenMedico exa = new ExamenMedico()
                    {
                        _Paciente = item,
                        _Virus = new Covid19()
                    };
                    _ListaExamenMedicos.Add(exa);
                }

                //para H1N1
                int suma1 = item._Muestra.MatrixProteina.Sum();
                if (suma1 == 300)
                {
                    ExamenMedico exa = new ExamenMedico()
                    {
                        _Paciente = item,
                        _Virus = new H1N1()
                    };
                    _ListaExamenMedicos.Add(exa);
                }

                //para Influenza
                int suma2 = item._Muestra.MatrixProteina.Max();
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    //convertir todo a string
                    aux = Convert.ToString(suma2);
                    //byte a hash byte[]
                    byte[] hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(aux));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        builder.Append(hashValue[i].ToString("x2"));
                    }
                    aux = builder.ToString();
                }

                if ( aux == item._Muestra.ARN )
                {
                    ExamenMedico exa = new ExamenMedico()
                    {
                        _Paciente = item,
                        _Virus = new Influenza()
                    };
                    _ListaExamenMedicos.Add(exa);
                }

            }
        }

        public string getXML()
        {
            DetectVirus();
            XmlDocument documento = new XmlDocument();
            XmlDeclaration declara = documento.CreateXmlDeclaration("1.0",null,null);
            documento.AppendChild(declara);

            XmlProcessingInstruction xslt = documento.CreateProcessingInstruction
                ("xml-stylesheet", "type=\"text/\" href=\"examenlaboratorio.xslt\"");
            documento.AppendChild(xslt);

            XmlElement raiz = documento.CreateElement("raiz");

            foreach (var item in _ListaExamenMedicos)
            {
                XmlElement examen = documento.CreateElement("examen");
                XmlElement examenes = documento.CreateElement("examenes");
                XmlElement virus = documento.CreateElement("virus");
                virus.InnerText = item._Virus.GetType().Name;
                XmlElement paciente = documento.CreateElement("paciente");
                paciente.InnerText = item._Paciente.ToString();
                paciente.SetAttribute("edad", (DateTime.Now.Subtract(item._Paciente.FechaNacimiento).TotalDays / 365.5).ToString());
                XmlElement tratamiento = documento.CreateElement("tratamiento");
                tratamiento.InnerText = item._Virus.GetTratamiento();
                XmlElement condicion = documento.CreateElement("condicion");

                if (item._Paciente is IEmbarazada)
                {
                    if ((item._Paciente as IEmbarazada).IsEmbrazada == true)
                    {
                        condicion.InnerText = "Embarazada";
                    }
                    else
                    {
                        condicion.InnerText = "";
                    }
                }else  if (item._Paciente is IPresionAlta)
                {
                    if ((item._Paciente as IPresionAlta).PrecionAlta == true)
                    
                        condicion.InnerText = "Presion Alta";
                    
                    else
                    {
                        condicion.InnerText = "";
                    }
                }

                examen.AppendChild(virus);
                examen.AppendChild(paciente);
                examen.AppendChild(tratamiento);
                examen.AppendChild(condicion);

                examenes.AppendChild(examen);
                raiz.AppendChild(examenes);
            }
            documento.AppendChild(raiz);

            return documento.InnerXml;
        }
    }
}
