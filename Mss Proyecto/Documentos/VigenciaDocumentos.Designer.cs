﻿namespace Mss_Proyecto
{
    partial class VigenciaDocumentos
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
            this.gprBusqueda = new System.Windows.Forms.GroupBox();
            this.txtDv = new Mss_Proyecto.Int32TextBox();
            this.txtRut = new Mss_Proyecto.Int32TextBox();
            this.cboCentroCostos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vWDOCHistorialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gprBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCHistorialBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gprBusqueda
            // 
            this.gprBusqueda.Controls.Add(this.txtDv);
            this.gprBusqueda.Controls.Add(this.txtRut);
            this.gprBusqueda.Controls.Add(this.cboCentroCostos);
            this.gprBusqueda.Controls.Add(this.label3);
            this.gprBusqueda.Controls.Add(this.label2);
            this.gprBusqueda.Controls.Add(this.label1);
            this.gprBusqueda.Controls.Add(this.txtApellidos);
            this.gprBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gprBusqueda.Name = "gprBusqueda";
            this.gprBusqueda.Size = new System.Drawing.Size(552, 64);
            this.gprBusqueda.TabIndex = 34;
            this.gprBusqueda.TabStop = false;
            this.gprBusqueda.Text = "Búsqueda";
            // 
            // txtDv
            // 
            this.txtDv.Enabled = false;
            this.txtDv.Location = new System.Drawing.Point(235, 13);
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(34, 20);
            this.txtDv.TabIndex = 2;
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(117, 13);
            this.txtRut.MaxLength = 9;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(112, 20);
            this.txtRut.TabIndex = 1;
            // 
            // cboCentroCostos
            // 
            this.cboCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroCostos.FormattingEnabled = true;
            this.cboCentroCostos.Location = new System.Drawing.Point(384, 13);
            this.cboCentroCostos.Name = "cboCentroCostos";
            this.cboCentroCostos.Size = new System.Drawing.Size(154, 21);
            this.cboCentroCostos.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Centro de costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rut";
            // 
            // txtApellidos
            // 
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Location = new System.Drawing.Point(117, 38);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(154, 20);
            this.txtApellidos.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(995, 344);
            this.dataGridView1.TabIndex = 35;
            // 
            // personalBindingSource
            // 
            this.personalBindingSource.DataSource = typeof(MssBD.Personal);
            // 
            // vWDOCHistorialBindingSource
            // 
            this.vWDOCHistorialBindingSource.DataSource = typeof(MssBD.VW_DOC_Historial);
            // 
            // VigenciaDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 466);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gprBusqueda);
            this.Name = "VigenciaDocumentos";
            this.Text = "Vigencia de Contratos";
            this.gprBusqueda.ResumeLayout(false);
            this.gprBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCHistorialBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gprBusqueda;
        private Int32TextBox txtDv;
        private Int32TextBox txtRut;
        private System.Windows.Forms.ComboBox cboCentroCostos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource personalBindingSource;
        private System.Windows.Forms.BindingSource vWDOCHistorialBindingSource;
    }
}