namespace Mss_Proyecto
{
    partial class EstructuraSueldos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstructuraSueldos));
            this.grpInformacion = new System.Windows.Forms.GroupBox();
            this.txtTurno = new Mss_Proyecto.Int32TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSueldoBase = new Mss_Proyecto.Int32TextBox();
            this.txtEstructuraCodigo = new System.Windows.Forms.TextBox();
            this.txtBonoAsistencia = new Mss_Proyecto.Int32TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMovilizacion = new Mss_Proyecto.Int32TextBox();
            this.txtColacion = new Mss_Proyecto.Int32TextBox();
            this.txtBonoProduccion = new Mss_Proyecto.Int32TextBox();
            this.txtGratificacion = new Mss_Proyecto.Int32TextBox();
            this.txtDescipcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp = new System.Windows.Forms.GroupBox();
            this.cboEstructuras = new System.Windows.Forms.ComboBox();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.BtnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.grpInformacion.SuspendLayout();
            this.grp.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInformacion
            // 
            this.grpInformacion.Controls.Add(this.txtTurno);
            this.grpInformacion.Controls.Add(this.label9);
            this.grpInformacion.Controls.Add(this.txtSueldoBase);
            this.grpInformacion.Controls.Add(this.txtEstructuraCodigo);
            this.grpInformacion.Controls.Add(this.txtBonoAsistencia);
            this.grpInformacion.Controls.Add(this.label6);
            this.grpInformacion.Controls.Add(this.txtMovilizacion);
            this.grpInformacion.Controls.Add(this.txtColacion);
            this.grpInformacion.Controls.Add(this.txtBonoProduccion);
            this.grpInformacion.Controls.Add(this.txtGratificacion);
            this.grpInformacion.Controls.Add(this.txtDescipcion);
            this.grpInformacion.Controls.Add(this.label8);
            this.grpInformacion.Controls.Add(this.label7);
            this.grpInformacion.Controls.Add(this.label5);
            this.grpInformacion.Controls.Add(this.label4);
            this.grpInformacion.Controls.Add(this.label3);
            this.grpInformacion.Controls.Add(this.label2);
            this.grpInformacion.Controls.Add(this.label1);
            this.grpInformacion.Location = new System.Drawing.Point(12, 89);
            this.grpInformacion.Name = "grpInformacion";
            this.grpInformacion.Size = new System.Drawing.Size(434, 202);
            this.grpInformacion.TabIndex = 0;
            this.grpInformacion.TabStop = false;
            this.grpInformacion.Text = "Estructura de Sueldo";
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(103, 165);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(100, 20);
            this.txtTurno.TabIndex = 32;
            this.txtTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Bono Turno";
            // 
            // txtSueldoBase
            // 
            this.txtSueldoBase.Location = new System.Drawing.Point(103, 83);
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.Size = new System.Drawing.Size(100, 20);
            this.txtSueldoBase.TabIndex = 30;
            this.txtSueldoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEstructuraCodigo
            // 
            this.txtEstructuraCodigo.Location = new System.Drawing.Point(103, 22);
            this.txtEstructuraCodigo.Name = "txtEstructuraCodigo";
            this.txtEstructuraCodigo.Size = new System.Drawing.Size(127, 20);
            this.txtEstructuraCodigo.TabIndex = 29;
            this.txtEstructuraCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstructuraCodigo_KeyPress);
            // 
            // txtBonoAsistencia
            // 
            this.txtBonoAsistencia.Location = new System.Drawing.Point(103, 139);
            this.txtBonoAsistencia.Name = "txtBonoAsistencia";
            this.txtBonoAsistencia.Size = new System.Drawing.Size(100, 20);
            this.txtBonoAsistencia.TabIndex = 27;
            this.txtBonoAsistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Bono Asistencia";
            // 
            // txtMovilizacion
            // 
            this.txtMovilizacion.Location = new System.Drawing.Point(308, 139);
            this.txtMovilizacion.Name = "txtMovilizacion";
            this.txtMovilizacion.Size = new System.Drawing.Size(100, 20);
            this.txtMovilizacion.TabIndex = 19;
            this.txtMovilizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtColacion
            // 
            this.txtColacion.Location = new System.Drawing.Point(308, 111);
            this.txtColacion.Name = "txtColacion";
            this.txtColacion.Size = new System.Drawing.Size(100, 20);
            this.txtColacion.TabIndex = 18;
            this.txtColacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBonoProduccion
            // 
            this.txtBonoProduccion.Location = new System.Drawing.Point(308, 83);
            this.txtBonoProduccion.Name = "txtBonoProduccion";
            this.txtBonoProduccion.Size = new System.Drawing.Size(100, 20);
            this.txtBonoProduccion.TabIndex = 17;
            this.txtBonoProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGratificacion
            // 
            this.txtGratificacion.Location = new System.Drawing.Point(103, 111);
            this.txtGratificacion.Name = "txtGratificacion";
            this.txtGratificacion.Size = new System.Drawing.Size(100, 20);
            this.txtGratificacion.TabIndex = 16;
            this.txtGratificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescipcion
            // 
            this.txtDescipcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescipcion.Location = new System.Drawing.Point(103, 51);
            this.txtDescipcion.MaxLength = 50;
            this.txtDescipcion.Name = "txtDescipcion";
            this.txtDescipcion.Size = new System.Drawing.Size(305, 20);
            this.txtDescipcion.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Colación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Movilización";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bono Producción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gratificación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sueldo Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estructura Codigo";
            // 
            // grp
            // 
            this.grp.Controls.Add(this.cboEstructuras);
            this.grp.Location = new System.Drawing.Point(12, 28);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(434, 55);
            this.grp.TabIndex = 2;
            this.grp.TabStop = false;
            this.grp.Text = "Estructuras de Sueldo";
            // 
            // cboEstructuras
            // 
            this.cboEstructuras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstructuras.FormattingEnabled = true;
            this.cboEstructuras.Location = new System.Drawing.Point(16, 19);
            this.cboEstructuras.Name = "cboEstructuras";
            this.cboEstructuras.Size = new System.Drawing.Size(349, 21);
            this.cboEstructuras.TabIndex = 24;
            this.cboEstructuras.SelectedIndexChanged += new System.EventHandler(this.cboEstructuras_SelectedIndexChanged);
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEliminar,
            this.btnGuardar,
            this.BtnLimpiar});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(458, 25);
            this.ToolBar.TabIndex = 27;
            this.ToolBar.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::Mss_Proyecto.Properties.Resources.add_1;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "Agregar Nuevo";
            this.btnNuevo.ToolTipText = "Agregar Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::Mss_Proyecto.Properties.Resources.garbage_2;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.ToolTipText = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = global::Mss_Proyecto.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(23, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLimpiar.Image = global::Mss_Proyecto.Properties.Resources.repeat_1;
            this.BtnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(23, 22);
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // EstructuraSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 303);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.grpInformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EstructuraSueldos";
            this.Text = "Estructura Sueldos";
            this.Load += new System.EventHandler(this.EstructuraSueldos_Load);
            this.grpInformacion.ResumeLayout(false);
            this.grpInformacion.PerformLayout();
            this.grp.ResumeLayout(false);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInformacion;
        private System.Windows.Forms.TextBox txtDescipcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Int32TextBox txtMovilizacion;
        private Int32TextBox txtColacion;
        private Int32TextBox txtBonoProduccion;
        private Int32TextBox txtGratificacion;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.ComboBox cboEstructuras;
        private Int32TextBox txtBonoAsistencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton BtnLimpiar;
        private System.Windows.Forms.TextBox txtEstructuraCodigo;
        private Int32TextBox txtSueldoBase;
        private Int32TextBox txtTurno;
        private System.Windows.Forms.Label label9;
    }
}