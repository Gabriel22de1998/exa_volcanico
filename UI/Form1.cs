using appExamen1Laboratorio.Gestores;
using appExamen1Laboratorio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Examen1.Laboratorio.Clases;
using UTN.Winform.Examen1.Laboratorio.Factory;
using UTN.Winform.Examen1.Laboratorio.Util;

namespace appExamen1Laboratorio
{
    public partial class Form1 : Form
    {
        private IGestor _Gestor = new Gestor();

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripbtmProcesar_Click(object sender, EventArgs e)
        {
            string xml = _Gestor.getXML();

            File.WriteAllText(@"c:\temp\examenlaboratorio.xml", xml);

            //Copio el XSLT a TEMP
            File.Copy(@"../../xslt/examenlaboratorio.xslt", @"c:\temp\examenlaboratorio.xslt", true);

            webBrowser1.Url = new Uri(@"c:\temp\examenlaboratorio.xml");
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FactoryPaciente _FactoryPaciente = new FactoryPaciente();
            CulturaInfo();
            Text = Application.ProductName;
            this.toolStripStatusFecha.Text = DateTime.Now.ToString();

            String datos = File.ReadAllText("../../JSON/datos.json");
            RootJson oDatosJSON = JSONGenericObject<RootJson>.JSonToObject(datos);

            foreach (var item in oDatosJSON.Lista)
            {
                Paciente oPaciente = null;

                if (item.Sexo.Equals("h", StringComparison.InvariantCultureIgnoreCase))
                {
                    //creo un hombre
                    oPaciente = _FactoryPaciente.CreatePaciente(Sexo.Hombre);
                    oPaciente.Sexo = "Hombre";
                    //precion alta
                    if (item.Sexo.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                    {
                        (oPaciente as IPresionAlta).PrecionAlta = true;
                    }
                    else {
                        (oPaciente as IPresionAlta).PrecionAlta = false;
                    }
                }

                if (item.Sexo.Equals("m", StringComparison.InvariantCultureIgnoreCase))
                {
                    //creo a una mujer
                    oPaciente = _FactoryPaciente.CreatePaciente(Sexo.Mujer);
                    oPaciente.Sexo = "Mujer";
                    //Embarazo
                    if (item.Sexo.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                    {
                        (oPaciente as IEmbarazada).IsEmbrazada = true;
                    }
                    else
                    {
                        (oPaciente as IEmbarazada).IsEmbrazada = false;
                    }
                }
               
                oPaciente.Nombre = item.Nombre;
                oPaciente.Apellidos = item.Apellidos;
                oPaciente.FechaNacimiento = DateTime.Parse(item.FechaNacimiento);

                Muestra muestra = new Muestra();
                muestra.ARN = item.ARN;
                muestra.MatrixProteina = Array.ConvertAll(item.MatrixProteina.Split(','), s => int.Parse(s));
                oPaciente._Muestra = muestra;

                _Gestor.AddPaciente(oPaciente);
            }
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.DataSource = oDatosJSON.Lista;
        }

        private void CulturaInfo()
        {
            // Colocar Cultura Estandar para Costa Rica
            // esto me permite no tener problemas con (.) de los decimales
            CultureInfo Micultura = new CultureInfo("es-CR", false);
            Micultura.NumberFormat.CurrencySymbol = "¢";
            Micultura.NumberFormat.CurrencyDecimalDigits = 2;
            Micultura.NumberFormat.CurrencyDecimalSeparator = ".";
            Micultura.NumberFormat.CurrencyGroupSeparator = ",";
            int[] grupo = new int[] { 3, 3, 3 };
            Micultura.NumberFormat.CurrencyGroupSizes = grupo;
            Micultura.NumberFormat.NumberDecimalDigits = 2;
            Micultura.NumberFormat.NumberGroupSeparator = ",";
            Micultura.NumberFormat.NumberDecimalSeparator = ".";
            Micultura.NumberFormat.NumberGroupSizes = grupo;
            //Micultura.DateTimeFormat.
        }

        private void toolStripbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
