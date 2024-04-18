using System;
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

        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            EntradaDTO datosEntrada = new EntradaDTO();

            datosEntrada.FechaActual = DateTime.Now;
            datosEntrada.TipoCalculo = (TiposCalculos)comboBoxTipo.SelectedIndex;
            datosEntrada.FechaRepeticion = DateTime.Parse(textBoxFechaOcurrencia.Text);

            SalidaDTO datosSalida= programador.Calcular(datosEntrada);

            labelProximaEjecucion.Text = datosSalida.FechaEjecucion.ToString("dd/MM/yyyy HH:mm");
            labelDescripcion.Text = datosSalida.Descripcion.ToString();

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedIndex == 0)
            {
                comboBoxOcurrencia.Enabled = false;
                numericUpDownDias.Enabled = false;
                textBoxFechaOcurrencia.Enabled = true;
                textBoxFechaOcurrencia.Text = "";
            }
            else if (comboBoxTipo.SelectedIndex == 1)
            {
                comboBoxOcurrencia.Enabled = true;
                numericUpDownDias.Enabled = true;
                textBoxFechaOcurrencia.Text = "";
                textBoxFechaOcurrencia.Enabled = false;
            }
        }
    }
}
