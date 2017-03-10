namespace Mss_Proyecto
{
    partial class CentroDeCostos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CentroDeCostos));
            this.gprCentroPrincipal = new System.Windows.Forms.GroupBox();
            this.cboCentroCostos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpInformacion = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSugerencia = new System.Windows.Forms.Label();
            this.chkVigencia = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCentroEdit = new Mss_Proyecto.Int32TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNo = new System.Windows.Forms.CheckBox();
            this.chkSi = new System.Windows.Forms.CheckBox();
            this.cboEstructura = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.BtnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.gprCentroPrincipal.SuspendLayout();
            this.grpInformacion.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gprCentroPrincipal
            // 
            this.gprCentroPrincipal.Controls.Add(this.cboCentroCostos);
            this.gprCentroPrincipal.Controls.Add(this.label9);
            this.gprCentroPrincipal.Location = new System.Drawing.Point(12, 28);
            this.gprCentroPrincipal.Name = "gprCentroPrincipal";
            this.gprCentroPrincipal.Size = new System.Drawing.Size(434, 60);
            this.gprCentroPrincipal.TabIndex = 3;
            this.gprCentroPrincipal.TabStop = false;
            this.gprCentroPrincipal.Text = "Seleccionar centros de costo";
            // 
            // cboCentroCostos
            // 
            this.cboCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroCostos.FormattingEnabled = true;
            this.cboCentroCostos.Location = new System.Drawing.Point(103, 26);
            this.cboCentroCostos.Name = "cboCentroCostos";
            this.cboCentroCostos.Size = new System.Drawing.Size(267, 21);
            this.cboCentroCostos.TabIndex = 24;
            this.cboCentroCostos.SelectedIndexChanged += new System.EventHandler(this.cboCentroCostos_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Centro Codigo";
            // 
            // grpInformacion
            // 
            this.grpInformacion.Controls.Add(this.txtDireccion);
            this.grpInformacion.Controls.Add(this.label5);
            this.grpInformacion.Controls.Add(this.lblSugerencia);
            this.grpInformacion.Controls.Add(this.chkVigencia);
            this.grpInformacion.Controls.Add(this.label4);
            this.grpInformacion.Controls.Add(this.txtCentroEdit);
            this.grpInformacion.Controls.Add(this.groupBox3);
            this.grpInformacion.Controls.Add(this.txtDescripcion);
            this.grpInformacion.Controls.Add(this.label1);
            this.grpInformacion.Controls.Add(this.label2);
            this.grpInformacion.Location = new System.Drawing.Point(12, 94);
            this.grpInformacion.Name = "grpInformacion";
            this.grpInformacion.Size = new System.Drawing.Size(434, 250);
            this.grpInformacion.TabIndex = 25;
            this.grpInformacion.TabStop = false;
            this.grpInformacion.Text = "Información Centros de Costo";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(103, 81);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(299, 43);
            this.txtDireccion.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Dirección";
            // 
            // lblSugerencia
            // 
            this.lblSugerencia.AutoSize = true;
            this.lblSugerencia.Location = new System.Drawing.Point(206, 32);
            this.lblSugerencia.Name = "lblSugerencia";
            this.lblSugerencia.Size = new System.Drawing.Size(160, 13);
            this.lblSugerencia.TabIndex = 30;
            this.lblSugerencia.Text = "Código sugerido para ser creado";
            // 
            // chkVigencia
            // 
            this.chkVigencia.AutoSize = true;
            this.chkVigencia.Location = new System.Drawing.Point(103, 131);
            this.chkVigencia.Name = "chkVigencia";
            this.chkVigencia.Size = new System.Drawing.Size(15, 14);
            this.chkVigencia.TabIndex = 29;
            this.chkVigencia.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Vigencia";
            // 
            // txtCentroEdit
            // 
            this.txtCentroEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCentroEdit.Location = new System.Drawing.Point(103, 29);
            this.txtCentroEdit.Name = "txtCentroEdit";
            this.txtCentroEdit.Size = new System.Drawing.Size(97, 20);
            this.txtCentroEdit.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.cboEstructura);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 87);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccionar centros de costo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNo);
            this.groupBox1.Controls.Add(this.chkSi);
            this.groupBox1.Location = new System.Drawing.Point(10, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 32);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // chkNo
            // 
            this.chkNo.AutoSize = true;
            this.chkNo.Location = new System.Drawing.Point(52, 9);
            this.chkNo.Name = "chkNo";
            this.chkNo.Size = new System.Drawing.Size(40, 17);
            this.chkNo.TabIndex = 26;
            this.chkNo.Text = "No";
            this.chkNo.UseVisualStyleBackColor = true;
            this.chkNo.CheckedChanged += new System.EventHandler(this.chkNo_CheckedChanged);
            // 
            // chkSi
            // 
            this.chkSi.AutoSize = true;
            this.chkSi.Location = new System.Drawing.Point(11, 9);
            this.chkSi.Name = "chkSi";
            this.chkSi.Size = new System.Drawing.Size(35, 17);
            this.chkSi.TabIndex = 25;
            this.chkSi.Text = "Si";
            this.chkSi.UseVisualStyleBackColor = true;
            this.chkSi.CheckedChanged += new System.EventHandler(this.chkSi_CheckedChanged);
            // 
            // cboEstructura
            // 
            this.cboEstructura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstructura.FormattingEnabled = true;
            this.cboEstructura.Location = new System.Drawing.Point(119, 57);
            this.cboEstructura.Name = "cboEstructura";
            this.cboEstructura.Size = new System.Drawing.Size(268, 21);
            this.cboEstructura.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Estructura de Sueldo";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(103, 56);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(299, 20);
            this.txtDescripcion.TabIndex = 23;
            this.txtDescripcion.Leave += new System.EventHandler(this.txtDescripcion_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Centro Código";
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
            this.ToolBar.Size = new System.Drawing.Size(457, 25);
            this.ToolBar.TabIndex = 26;
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            // CentroDeCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 354);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.grpInformacion);
            this.Controls.Add(this.gprCentroPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CentroDeCostos";
            this.Text = "Centro de Costos";
            this.Load += new System.EventHandler(this.CentroDeCostos_Load);
            this.gprCentroPrincipal.ResumeLayout(false);
            this.gprCentroPrincipal.PerformLayout();
            this.grpInformacion.ResumeLayout(false);
            this.grpInformacion.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gprCentroPrincipal;
        private System.Windows.Forms.ComboBox cboCentroCostos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpInformacion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboEstructura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNo;
        private System.Windows.Forms.CheckBox chkSi;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private Int32TextBox txtCentroEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkVigencia;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton BtnLimpiar;
        private System.Windows.Forms.Label lblSugerencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
    }
}