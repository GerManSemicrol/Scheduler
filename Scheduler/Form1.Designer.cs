namespace Scheduler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalcular = new System.Windows.Forms.Button();
            this.textBoxFechaActual = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelProximaEjecucion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFechaOcurrencia = new System.Windows.Forms.TextBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxOcurrencia = new System.Windows.Forms.ComboBox();
            this.numericDias = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.numericSemanas = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxLunes = new System.Windows.Forms.CheckBox();
            this.checkBoxMartes = new System.Windows.Forms.CheckBox();
            this.checkBoxMiércoles = new System.Windows.Forms.CheckBox();
            this.checkBoxJueves = new System.Windows.Forms.CheckBox();
            this.checkBoxViernes = new System.Windows.Forms.CheckBox();
            this.checkBoxSabado = new System.Windows.Forms.CheckBox();
            this.checkBoxDomingo = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxFreDiariaUnaVez = new System.Windows.Forms.CheckBox();
            this.checkBoxFreDiariaVariasVeces = new System.Windows.Forms.CheckBox();
            this.dateTimePickerUnaVez = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePickerHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownFrecDiariaTiempoRepeticion = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFrecDiariaTipoFrecuencia = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDias)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemanas)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrecDiariaTiempoRepeticion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCalcular);
            this.panel1.Controls.Add(this.textBoxFechaActual);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 73);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha actual";
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.Location = new System.Drawing.Point(310, 37);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Size = new System.Drawing.Size(178, 23);
            this.buttonCalcular.TabIndex = 1;
            this.buttonCalcular.Text = "Calcular siguiente fecha";
            this.buttonCalcular.UseVisualStyleBackColor = true;
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // textBoxFechaActual
            // 
            this.textBoxFechaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFechaActual.Location = new System.Drawing.Point(101, 37);
            this.textBoxFechaActual.Name = "textBoxFechaActual";
            this.textBoxFechaActual.Size = new System.Drawing.Size(160, 20);
            this.textBoxFechaActual.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.labelDescripcion);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.labelProximaEjecucion);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 440);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(566, 163);
            this.panel3.TabIndex = 2;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelDescripcion.Location = new System.Drawing.Point(37, 96);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(484, 62);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Descripción";
            // 
            // labelProximaEjecucion
            // 
            this.labelProximaEjecucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelProximaEjecucion.Location = new System.Drawing.Point(152, 35);
            this.labelProximaEjecucion.Name = "labelProximaEjecucion";
            this.labelProximaEjecucion.Size = new System.Drawing.Size(369, 23);
            this.labelProximaEjecucion.TabIndex = 1;
            this.labelProximaEjecucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Próxima ejecución";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.checkBoxDomingo);
            this.panel4.Controls.Add(this.checkBoxSabado);
            this.panel4.Controls.Add(this.checkBoxViernes);
            this.panel4.Controls.Add(this.checkBoxJueves);
            this.panel4.Controls.Add(this.checkBoxMiércoles);
            this.panel4.Controls.Add(this.checkBoxMartes);
            this.panel4.Controls.Add(this.checkBoxLunes);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.numericSemanas);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(12, 222);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(566, 92);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha/hora";
            // 
            // textBoxFechaOcurrencia
            // 
            this.textBoxFechaOcurrencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFechaOcurrencia.Location = new System.Drawing.Point(100, 62);
            this.textBoxFechaOcurrencia.Name = "textBoxFechaOcurrencia";
            this.textBoxFechaOcurrencia.Size = new System.Drawing.Size(252, 20);
            this.textBoxFechaOcurrencia.TabIndex = 3;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(100, 35);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 4;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tipo";
            // 
            // comboBoxOcurrencia
            // 
            this.comboBoxOcurrencia.FormattingEnabled = true;
            this.comboBoxOcurrencia.Location = new System.Drawing.Point(100, 88);
            this.comboBoxOcurrencia.Name = "comboBoxOcurrencia";
            this.comboBoxOcurrencia.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOcurrencia.TabIndex = 6;
            // 
            // numericDias
            // 
            this.numericDias.Location = new System.Drawing.Point(418, 88);
            this.numericDias.Name = "numericDias";
            this.numericDias.Size = new System.Drawing.Size(52, 20);
            this.numericDias.TabIndex = 7;
            this.numericDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Día(s)";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.numericDias);
            this.panel2.Controls.Add(this.comboBoxOcurrencia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBoxTipo);
            this.panel2.Controls.Add(this.textBoxFechaOcurrencia);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 125);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cada";
            // 
            // numericSemanas
            // 
            this.numericSemanas.Location = new System.Drawing.Point(105, 37);
            this.numericSemanas.Name = "numericSemanas";
            this.numericSemanas.Size = new System.Drawing.Size(121, 20);
            this.numericSemanas.TabIndex = 8;
            this.numericSemanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "semana(s)";
            // 
            // checkBoxLunes
            // 
            this.checkBoxLunes.AutoSize = true;
            this.checkBoxLunes.Location = new System.Drawing.Point(38, 65);
            this.checkBoxLunes.Name = "checkBoxLunes";
            this.checkBoxLunes.Size = new System.Drawing.Size(55, 17);
            this.checkBoxLunes.TabIndex = 10;
            this.checkBoxLunes.Text = "Lunes";
            this.checkBoxLunes.UseVisualStyleBackColor = true;
            // 
            // checkBoxMartes
            // 
            this.checkBoxMartes.AutoSize = true;
            this.checkBoxMartes.Location = new System.Drawing.Point(105, 65);
            this.checkBoxMartes.Name = "checkBoxMartes";
            this.checkBoxMartes.Size = new System.Drawing.Size(58, 17);
            this.checkBoxMartes.TabIndex = 11;
            this.checkBoxMartes.Text = "Martes";
            this.checkBoxMartes.UseVisualStyleBackColor = true;
            // 
            // checkBoxMiércoles
            // 
            this.checkBoxMiércoles.AutoSize = true;
            this.checkBoxMiércoles.Location = new System.Drawing.Point(169, 65);
            this.checkBoxMiércoles.Name = "checkBoxMiércoles";
            this.checkBoxMiércoles.Size = new System.Drawing.Size(71, 17);
            this.checkBoxMiércoles.TabIndex = 12;
            this.checkBoxMiércoles.Text = "Miércoles";
            this.checkBoxMiércoles.UseVisualStyleBackColor = true;
            // 
            // checkBoxJueves
            // 
            this.checkBoxJueves.AutoSize = true;
            this.checkBoxJueves.Location = new System.Drawing.Point(251, 65);
            this.checkBoxJueves.Name = "checkBoxJueves";
            this.checkBoxJueves.Size = new System.Drawing.Size(60, 17);
            this.checkBoxJueves.TabIndex = 13;
            this.checkBoxJueves.Text = "Jueves";
            this.checkBoxJueves.UseVisualStyleBackColor = true;
            // 
            // checkBoxViernes
            // 
            this.checkBoxViernes.AutoSize = true;
            this.checkBoxViernes.Location = new System.Drawing.Point(317, 65);
            this.checkBoxViernes.Name = "checkBoxViernes";
            this.checkBoxViernes.Size = new System.Drawing.Size(61, 17);
            this.checkBoxViernes.TabIndex = 14;
            this.checkBoxViernes.Text = "Viernes";
            this.checkBoxViernes.UseVisualStyleBackColor = true;
            // 
            // checkBoxSabado
            // 
            this.checkBoxSabado.AutoSize = true;
            this.checkBoxSabado.Location = new System.Drawing.Point(384, 65);
            this.checkBoxSabado.Name = "checkBoxSabado";
            this.checkBoxSabado.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSabado.TabIndex = 15;
            this.checkBoxSabado.Text = "Sábado";
            this.checkBoxSabado.UseVisualStyleBackColor = true;
            // 
            // checkBoxDomingo
            // 
            this.checkBoxDomingo.AutoSize = true;
            this.checkBoxDomingo.Location = new System.Drawing.Point(453, 65);
            this.checkBoxDomingo.Name = "checkBoxDomingo";
            this.checkBoxDomingo.Size = new System.Drawing.Size(68, 17);
            this.checkBoxDomingo.TabIndex = 16;
            this.checkBoxDomingo.Text = "Domingo";
            this.checkBoxDomingo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.comboBoxFrecDiariaTipoFrecuencia);
            this.panel5.Controls.Add(this.numericUpDownFrecDiariaTiempoRepeticion);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.dateTimePickerHoraFinal);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.dateTimePickerHoraInicio);
            this.panel5.Controls.Add(this.dateTimePickerUnaVez);
            this.panel5.Controls.Add(this.checkBoxFreDiariaVariasVeces);
            this.panel5.Controls.Add(this.checkBoxFreDiariaUnaVez);
            this.panel5.Location = new System.Drawing.Point(12, 320);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(566, 114);
            this.panel5.TabIndex = 3;
            // 
            // checkBoxFreDiariaUnaVez
            // 
            this.checkBoxFreDiariaUnaVez.AutoSize = true;
            this.checkBoxFreDiariaUnaVez.Location = new System.Drawing.Point(44, 33);
            this.checkBoxFreDiariaUnaVez.Name = "checkBoxFreDiariaUnaVez";
            this.checkBoxFreDiariaUnaVez.Size = new System.Drawing.Size(124, 17);
            this.checkBoxFreDiariaUnaVez.TabIndex = 0;
            this.checkBoxFreDiariaUnaVez.Text = "Ocurre una vez a las";
            this.checkBoxFreDiariaUnaVez.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreDiariaVariasVeces
            // 
            this.checkBoxFreDiariaVariasVeces.AutoSize = true;
            this.checkBoxFreDiariaVariasVeces.Location = new System.Drawing.Point(44, 56);
            this.checkBoxFreDiariaVariasVeces.Name = "checkBoxFreDiariaVariasVeces";
            this.checkBoxFreDiariaVariasVeces.Size = new System.Drawing.Size(85, 17);
            this.checkBoxFreDiariaVariasVeces.TabIndex = 1;
            this.checkBoxFreDiariaVariasVeces.Text = "Ocurre cada";
            this.checkBoxFreDiariaVariasVeces.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerUnaVez
            // 
            this.dateTimePickerUnaVez.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerUnaVez.Location = new System.Drawing.Point(244, 30);
            this.dateTimePickerUnaVez.Name = "dateTimePickerUnaVez";
            this.dateTimePickerUnaVez.ShowUpDown = true;
            this.dateTimePickerUnaVez.Size = new System.Drawing.Size(166, 20);
            this.dateTimePickerUnaVez.TabIndex = 2;
            this.dateTimePickerUnaVez.Value = new System.DateTime(2024, 4, 18, 0, 0, 0, 0);
            // 
            // dateTimePickerHoraInicio
            // 
            this.dateTimePickerHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraInicio.Location = new System.Drawing.Point(121, 79);
            this.dateTimePickerHoraInicio.Name = "dateTimePickerHoraInicio";
            this.dateTimePickerHoraInicio.ShowUpDown = true;
            this.dateTimePickerHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerHoraInicio.TabIndex = 3;
            this.dateTimePickerHoraInicio.Value = new System.DateTime(2024, 4, 18, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Empieza a las";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Acaba a las";
            // 
            // dateTimePickerHoraFinal
            // 
            this.dateTimePickerHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraFinal.Location = new System.Drawing.Point(310, 79);
            this.dateTimePickerHoraFinal.Name = "dateTimePickerHoraFinal";
            this.dateTimePickerHoraFinal.ShowUpDown = true;
            this.dateTimePickerHoraFinal.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerHoraFinal.TabIndex = 5;
            this.dateTimePickerHoraFinal.Value = new System.DateTime(2024, 4, 18, 0, 0, 0, 0);
            // 
            // numericUpDownFrecDiariaTiempoRepeticion
            // 
            this.numericUpDownFrecDiariaTiempoRepeticion.Location = new System.Drawing.Point(244, 55);
            this.numericUpDownFrecDiariaTiempoRepeticion.Name = "numericUpDownFrecDiariaTiempoRepeticion";
            this.numericUpDownFrecDiariaTiempoRepeticion.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownFrecDiariaTiempoRepeticion.TabIndex = 8;
            this.numericUpDownFrecDiariaTiempoRepeticion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxFrecDiariaTipoFrecuencia
            // 
            this.comboBoxFrecDiariaTipoFrecuencia.FormattingEnabled = true;
            this.comboBoxFrecDiariaTipoFrecuencia.Items.AddRange(new object[] {
            "Horas",
            "Minutos",
            "Segundos"});
            this.comboBoxFrecDiariaTipoFrecuencia.Location = new System.Drawing.Point(310, 55);
            this.comboBoxFrecDiariaTipoFrecuencia.Name = "comboBoxFrecDiariaTipoFrecuencia";
            this.comboBoxFrecDiariaTipoFrecuencia.Size = new System.Drawing.Size(100, 21);
            this.comboBoxFrecDiariaTipoFrecuencia.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(-1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(566, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "Salida";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(566, 23);
            this.label13.TabIndex = 10;
            this.label13.Text = "Frecuencia Diaria";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(-1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(566, 23);
            this.label14.TabIndex = 17;
            this.label14.Text = "Configuración Semanal";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(-1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(566, 23);
            this.label15.TabIndex = 18;
            this.label15.Text = "Configuración";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(-1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(566, 23);
            this.label16.TabIndex = 19;
            this.label16.Text = "Entrada";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 609);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemanas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrecDiariaTiempoRepeticion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCalcular;
        private System.Windows.Forms.TextBox textBoxFechaActual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProximaEjecucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFechaOcurrencia;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxOcurrencia;
        private System.Windows.Forms.NumericUpDown numericDias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericSemanas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxDomingo;
        private System.Windows.Forms.CheckBox checkBoxSabado;
        private System.Windows.Forms.CheckBox checkBoxViernes;
        private System.Windows.Forms.CheckBox checkBoxJueves;
        private System.Windows.Forms.CheckBox checkBoxMiércoles;
        private System.Windows.Forms.CheckBox checkBoxMartes;
        private System.Windows.Forms.CheckBox checkBoxLunes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBoxFreDiariaVariasVeces;
        private System.Windows.Forms.CheckBox checkBoxFreDiariaUnaVez;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraFinal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerUnaVez;
        private System.Windows.Forms.ComboBox comboBoxFrecDiariaTipoFrecuencia;
        private System.Windows.Forms.NumericUpDown numericUpDownFrecDiariaTiempoRepeticion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
    }
}

