using System;
using System.Globalization;
using System.Windows.Forms;
using Negocio.EntitiesDTO;
using Negocio.Enums;
using Negocio.Managament;

namespace Scheduler
{
    public partial class Form1 : Form
    {
        Programador programador = new Programador();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxFechaActual.Text = DateTime.Now.ToString(("dd/MM/yyyy"));
            comboBoxTipo.Items.Add("Una vez");
            comboBoxTipo.Items.Add("Recurrente");
            comboBoxTipo.SelectedIndex = 0;
            comboBoxOcurrencia.Items.Add("Diaria");
            comboBoxOcurrencia.Items.Add("Semanal");
            comboBoxOcurrencia.Items.Add("Quincenal");
            comboBoxOcurrencia.Items.Add("Mensual");
            comboBoxOcurrencia.SelectedIndex = 0;
            comboBoxFrecDiariaTipoFrecuencia.SelectedIndex = 0;
            comboBoxIdioma.Items.Add("Español ES");
            comboBoxIdioma.Items.Add("English UK");
            comboBoxIdioma.Items.Add("English US");
            comboBoxIdioma.SelectedIndex = 0;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            EntradaDTO datosEntrada = new EntradaDTO();

            datosEntrada.FechaActual = DateTime.Now;
            datosEntrada.Idioma = (Idiomas)comboBoxIdioma.SelectedIndex;
            datosEntrada.TipoCalculo = (TiposCalculos)comboBoxTipo.SelectedIndex;
            if (datosEntrada.TipoCalculo == TiposCalculos.Una_vez)
            {
                datosEntrada.FechaRepeticion = DateTime.Parse(textBoxFechaOcurrencia.Text);
            }

            else if (datosEntrada.TipoCalculo == TiposCalculos.Recurrente)
            {
                datosEntrada.Ocurrencia = (OcurrenciaCalculos)comboBoxOcurrencia.SelectedIndex;
                if (datosEntrada.Ocurrencia == OcurrenciaCalculos.Diaria)
                {
                    datosEntrada.FechaRepeticion = datosEntrada.FechaActual.AddDays((double)numericDias.Value);
                }

            }

            SalidaDTO datosSalida = programador.Calcular(datosEntrada);

            labelProximaEjecucion.Text = ObtenerFechaSegunIdioma(datosEntrada, datosSalida);
            labelDescripcion.Text = datosSalida.Descripcion.ToString();
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedIndex == 0)
            {
                comboBoxOcurrencia.Enabled = false;
                numericDias.Enabled = false;
                textBoxFechaOcurrencia.Enabled = true;
                textBoxFechaOcurrencia.Text = "";
            }
            else if (comboBoxTipo.SelectedIndex == 1)
            {
                comboBoxOcurrencia.Enabled = true;
                numericDias.Enabled = true;
                textBoxFechaOcurrencia.Text = "";
                textBoxFechaOcurrencia.Enabled = false;
            }
        }

        private string ObtenerFechaSegunIdioma(EntradaDTO entrada, SalidaDTO salida)
        {
            if(entrada.Idioma == Idiomas.UK)
            {
                return salida.FechaEjecucion.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }
            else if(entrada.Idioma == Idiomas.US)
            {
                return salida.FechaEjecucion.ToString("MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }

            return salida.FechaEjecucion.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }
}