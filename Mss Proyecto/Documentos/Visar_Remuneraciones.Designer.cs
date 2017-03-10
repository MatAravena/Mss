namespace Mss_Proyecto
{
    partial class Visar_Remuneraciones
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visar_Remuneraciones));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtNumeroArt = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.GroupBox();
            this.txtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTeleCel = new System.Windows.Forms.MaskedTextBox();
            this.txtTeleFijo = new System.Windows.Forms.MaskedTextBox();
            this.txtRutDato = new Mss_Proyecto.Int32TextBox();
            this.txtDvDato = new Mss_Proyecto.Int32TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridRemuneraciones = new System.Windows.Forms.DataGridView();
            this.remuneracionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtVacaciones = new Mss_Proyecto.Int32TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTotalRemuneraciones = new Mss_Proyecto.Int32TextBox();
            this.remuneracionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaTerminoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finiquitoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRemuneraciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remuneracionesBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Controls.Add(this.txtNumeroArt);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboArticulo);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(294, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motivo Finiquito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Artículo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Location = new System.Drawing.Point(80, 48);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(565, 45);
            this.txtMotivo.TabIndex = 3;
            // 
            // txtNumeroArt
            // 
            this.txtNumeroArt.Location = new System.Drawing.Point(255, 19);
            this.txtNumeroArt.Mask = "9";
            this.txtNumeroArt.Name = "txtNumeroArt";
            this.txtNumeroArt.Size = new System.Drawing.Size(52, 20);
            this.txtNumeroArt.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "N°";
            // 
            // cboArticulo
            // 
            this.cboArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Items.AddRange(new object[] {
            "Artículo 159",
            "Artículo 160",
            "Artículo 161",
            "Artículo 163 bis"});
            this.cboArticulo.Location = new System.Drawing.Point(80, 19);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(129, 21);
            this.cboArticulo.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtFechaVencimiento);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtFechaInicio);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtDireccion);
            this.panel3.Controls.Add(this.txtTeleCel);
            this.panel3.Controls.Add(this.txtTeleFijo);
            this.panel3.Controls.Add(this.txtRutDato);
            this.panel3.Controls.Add(this.txtDvDato);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.txtFechaNacimiento);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtNombres);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtApellidoPaterno);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtApellidoMaterno);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 305);
            this.panel3.TabIndex = 25;
            this.panel3.TabStop = false;
            this.panel3.Text = "Datos del Personal";
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.Enabled = false;
            this.txtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaVencimiento.Location = new System.Drawing.Point(112, 256);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.Size = new System.Drawing.Size(154, 20);
            this.txtFechaVencimiento.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Fecha Vencimiento";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Enabled = false;
            this.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaInicio.Location = new System.Drawing.Point(112, 230);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(154, 20);
            this.txtFechaInicio.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 233);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Fecha Inicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(112, 124);
            this.txtDireccion.MaxLength = 70;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(154, 20);
            this.txtDireccion.TabIndex = 6;
            // 
            // txtTeleCel
            // 
            this.txtTeleCel.Enabled = false;
            this.txtTeleCel.Location = new System.Drawing.Point(112, 204);
            this.txtTeleCel.Mask = "(+569)99999999";
            this.txtTeleCel.Name = "txtTeleCel";
            this.txtTeleCel.Size = new System.Drawing.Size(152, 20);
            this.txtTeleCel.TabIndex = 9;
            // 
            // txtTeleFijo
            // 
            this.txtTeleFijo.Enabled = false;
            this.txtTeleFijo.Location = new System.Drawing.Point(112, 178);
            this.txtTeleFijo.Mask = "(022)9999999";
            this.txtTeleFijo.Name = "txtTeleFijo";
            this.txtTeleFijo.Size = new System.Drawing.Size(152, 20);
            this.txtTeleFijo.TabIndex = 8;
            // 
            // txtRutDato
            // 
            this.txtRutDato.Enabled = false;
            this.txtRutDato.Location = new System.Drawing.Point(112, 22);
            this.txtRutDato.Name = "txtRutDato";
            this.txtRutDato.Size = new System.Drawing.Size(112, 20);
            this.txtRutDato.TabIndex = 1;
            // 
            // txtDvDato
            // 
            this.txtDvDato.Enabled = false;
            this.txtDvDato.Location = new System.Drawing.Point(230, 22);
            this.txtDvDato.MaxLength = 1;
            this.txtDvDato.Name = "txtDvDato";
            this.txtDvDato.Size = new System.Drawing.Size(34, 20);
            this.txtDvDato.TabIndex = 2;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 25);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 13);
            this.label30.TabIndex = 23;
            this.label30.Text = "Rut";
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Enabled = false;
            this.txtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaNacimiento.Location = new System.Drawing.Point(112, 152);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(154, 20);
            this.txtFechaNacimiento.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Teléfono Celular";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Teléfono Fijo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Fecha Nacimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Enabled = false;
            this.txtNombres.Location = new System.Drawing.Point(112, 48);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(154, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Apellido Materno";
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidoPaterno.Enabled = false;
            this.txtApellidoPaterno.Location = new System.Drawing.Point(112, 73);
            this.txtApellidoPaterno.MaxLength = 50;
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(154, 20);
            this.txtApellidoPaterno.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Apellido Paterno";
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidoMaterno.Enabled = false;
            this.txtApellidoMaterno.Location = new System.Drawing.Point(112, 98);
            this.txtApellidoMaterno.MaxLength = 50;
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(154, 20);
            this.txtApellidoMaterno.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridRemuneraciones);
            this.groupBox3.Location = new System.Drawing.Point(294, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 199);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remuneraciones";
            // 
            // gridRemuneraciones
            // 
            this.gridRemuneraciones.AllowUserToResizeColumns = false;
            this.gridRemuneraciones.AllowUserToResizeRows = false;
            this.gridRemuneraciones.AutoGenerateColumns = false;
            this.gridRemuneraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRemuneraciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remuneracionIdDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.fechaTerminoDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.finiquitoIdDataGridViewTextBoxColumn});
            this.gridRemuneraciones.DataSource = this.remuneracionesBindingSource;
            this.gridRemuneraciones.Location = new System.Drawing.Point(6, 18);
            this.gridRemuneraciones.Name = "gridRemuneraciones";
            this.gridRemuneraciones.Size = new System.Drawing.Size(357, 175);
            this.gridRemuneraciones.TabIndex = 0;
            // 
            // remuneracionesBindingSource
            // 
            this.remuneracionesBindingSource.DataSource = typeof(MssBD.Remuneraciones);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtVacaciones);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(669, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(334, 62);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Vacaciones";
            // 
            // txtVacaciones
            // 
            this.txtVacaciones.Enabled = false;
            this.txtVacaciones.Location = new System.Drawing.Point(148, 28);
            this.txtVacaciones.Name = "txtVacaciones";
            this.txtVacaciones.Size = new System.Drawing.Size(152, 20);
            this.txtVacaciones.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Vacaciones Proporcionales";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(675, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 15);
            this.label17.TabIndex = 34;
            this.label17.Text = "TotalRemuneraciones";
            // 
            // txtTotalRemuneraciones
            // 
            this.txtTotalRemuneraciones.Enabled = false;
            this.txtTotalRemuneraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRemuneraciones.Location = new System.Drawing.Point(829, 192);
            this.txtTotalRemuneraciones.Name = "txtTotalRemuneraciones";
            this.txtTotalRemuneraciones.Size = new System.Drawing.Size(174, 21);
            this.txtTotalRemuneraciones.TabIndex = 33;
            // 
            // remuneracionIdDataGridViewTextBoxColumn
            // 
            this.remuneracionIdDataGridViewTextBoxColumn.DataPropertyName = "Remuneracion_Id";
            this.remuneracionIdDataGridViewTextBoxColumn.HeaderText = "Remuneracion_Id";
            this.remuneracionIdDataGridViewTextBoxColumn.Name = "remuneracionIdDataGridViewTextBoxColumn";
            this.remuneracionIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "FechaInicio";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaInicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio";
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            this.fechaInicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaTerminoDataGridViewTextBoxColumn
            // 
            this.fechaTerminoDataGridViewTextBoxColumn.DataPropertyName = "FechaTermino";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaTerminoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaTerminoDataGridViewTextBoxColumn.HeaderText = "Fecha Término";
            this.fechaTerminoDataGridViewTextBoxColumn.Name = "fechaTerminoDataGridViewTextBoxColumn";
            this.fechaTerminoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "monto";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finiquitoIdDataGridViewTextBoxColumn
            // 
            this.finiquitoIdDataGridViewTextBoxColumn.DataPropertyName = "Finiquito_Id";
            this.finiquitoIdDataGridViewTextBoxColumn.HeaderText = "Finiquito_Id";
            this.finiquitoIdDataGridViewTextBoxColumn.Name = "finiquitoIdDataGridViewTextBoxColumn";
            this.finiquitoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // Visar_Remuneraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 337);
            this.Controls.Add(this.txtTotalRemuneraciones);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visar_Remuneraciones";
            this.Text = "Finiquitos";
            this.Load += new System.EventHandler(this.Finiquitos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRemuneraciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remuneracionesBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.MaskedTextBox txtTeleCel;
        private System.Windows.Forms.MaskedTextBox txtTeleFijo;
        private Int32TextBox txtRutDato;
        private Int32TextBox txtDvDato;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker txtFechaNacimiento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Int32TextBox txtVacaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboArticulo;
        private System.Windows.Forms.MaskedTextBox txtNumeroArt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtFechaVencimiento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private Int32TextBox txtTotalRemuneraciones;
        private System.Windows.Forms.DataGridView gridRemuneraciones;
        private System.Windows.Forms.BindingSource remuneracionesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn remuneracionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaTerminoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finiquitoIdDataGridViewTextBoxColumn;
    }
}