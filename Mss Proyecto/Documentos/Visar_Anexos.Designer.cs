namespace Mss_Proyecto
{
    partial class Visar_Anexos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visar_Anexos));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.BtnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.gprBusqueda = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.gridContratos = new System.Windows.Forms.DataGridView();
            this.documentoTipoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porVisarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rutaFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anexoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunaCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunanombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telFijoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoCivilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vWDOCAnexosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ToolBar.SuspendLayout();
            this.gprBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCAnexosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnGuardar,
            this.BtnLimpiar});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(961, 25);
            this.ToolBar.TabIndex = 31;
            this.ToolBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Mss_Proyecto.Properties.Resources.search;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Buscar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnLimpiar.ToolTipText = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // gprBusqueda
            // 
            this.gprBusqueda.Controls.Add(this.label1);
            this.gprBusqueda.Controls.Add(this.txtHasta);
            this.gprBusqueda.Controls.Add(this.txtDesde);
            this.gprBusqueda.Controls.Add(this.label2);
            this.gprBusqueda.Location = new System.Drawing.Point(12, 28);
            this.gprBusqueda.Name = "gprBusqueda";
            this.gprBusqueda.Size = new System.Drawing.Size(389, 59);
            this.gprBusqueda.TabIndex = 33;
            this.gprBusqueda.TabStop = false;
            this.gprBusqueda.Text = "Búsqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "hasta";
            // 
            // txtHasta
            // 
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtHasta.Location = new System.Drawing.Point(245, 19);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(100, 20);
            this.txtHasta.TabIndex = 10;
            // 
            // txtDesde
            // 
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(90, 19);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(100, 20);
            this.txtDesde.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha desde";
            // 
            // gridContratos
            // 
            this.gridContratos.AllowUserToAddRows = false;
            this.gridContratos.AllowUserToDeleteRows = false;
            this.gridContratos.AutoGenerateColumns = false;
            this.gridContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.documentoTipoIdDataGridViewTextBoxColumn,
            this.usuarioIdDataGridViewTextBoxColumn,
            this.personalIdDataGridViewTextBoxColumn,
            this.porVisarDataGridViewCheckBoxColumn,
            this.rutaFinalDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.rutDataGridViewTextBoxColumn,
            this.dvDataGridViewTextBoxColumn,
            this.fechaDesdeDataGridViewTextBoxColumn,
            this.fechaHastaDataGridViewTextBoxColumn,
            this.anexoIdDataGridViewTextBoxColumn,
            this.documentoIdDataGridViewTextBoxColumn,
            this.apellidoPaternoDataGridViewTextBoxColumn,
            this.apellidoMaternoDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.comunaCodigoDataGridViewTextBoxColumn,
            this.comunanombreDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.fechaNacimientoDataGridViewTextBoxColumn,
            this.telFijoDataGridViewTextBoxColumn,
            this.estadoCivilDataGridViewTextBoxColumn});
            this.gridContratos.DataSource = this.vWDOCAnexosBindingSource;
            this.gridContratos.Location = new System.Drawing.Point(12, 93);
            this.gridContratos.Name = "gridContratos";
            this.gridContratos.RowHeadersVisible = false;
            this.gridContratos.Size = new System.Drawing.Size(929, 324);
            this.gridContratos.TabIndex = 34;
            this.gridContratos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContratos_CellValueChanged);
            this.gridContratos.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridContratos_CurrentCellDirtyStateChanged);
            // 
            // documentoTipoIdDataGridViewTextBoxColumn
            // 
            this.documentoTipoIdDataGridViewTextBoxColumn.DataPropertyName = "DocumentoTipo_Id";
            this.documentoTipoIdDataGridViewTextBoxColumn.HeaderText = "DocumentoTipo_Id";
            this.documentoTipoIdDataGridViewTextBoxColumn.Name = "documentoTipoIdDataGridViewTextBoxColumn";
            this.documentoTipoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioIdDataGridViewTextBoxColumn
            // 
            this.usuarioIdDataGridViewTextBoxColumn.DataPropertyName = "Usuario_Id";
            this.usuarioIdDataGridViewTextBoxColumn.HeaderText = "Usuario_Id";
            this.usuarioIdDataGridViewTextBoxColumn.Name = "usuarioIdDataGridViewTextBoxColumn";
            this.usuarioIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // personalIdDataGridViewTextBoxColumn
            // 
            this.personalIdDataGridViewTextBoxColumn.DataPropertyName = "Personal_Id";
            this.personalIdDataGridViewTextBoxColumn.HeaderText = "Personal_Id";
            this.personalIdDataGridViewTextBoxColumn.Name = "personalIdDataGridViewTextBoxColumn";
            this.personalIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // porVisarDataGridViewCheckBoxColumn
            // 
            this.porVisarDataGridViewCheckBoxColumn.DataPropertyName = "PorVisar";
            this.porVisarDataGridViewCheckBoxColumn.HeaderText = "PorVisar";
            this.porVisarDataGridViewCheckBoxColumn.Name = "porVisarDataGridViewCheckBoxColumn";
            // 
            // rutaFinalDataGridViewTextBoxColumn
            // 
            this.rutaFinalDataGridViewTextBoxColumn.DataPropertyName = "RutaFinal";
            this.rutaFinalDataGridViewTextBoxColumn.HeaderText = "RutaFinal";
            this.rutaFinalDataGridViewTextBoxColumn.Name = "rutaFinalDataGridViewTextBoxColumn";
            this.rutaFinalDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha Anexo";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rutDataGridViewTextBoxColumn
            // 
            this.rutDataGridViewTextBoxColumn.DataPropertyName = "Rut";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.rutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rutDataGridViewTextBoxColumn.HeaderText = "Rut";
            this.rutDataGridViewTextBoxColumn.Name = "rutDataGridViewTextBoxColumn";
            this.rutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dvDataGridViewTextBoxColumn
            // 
            this.dvDataGridViewTextBoxColumn.DataPropertyName = "Dv";
            this.dvDataGridViewTextBoxColumn.HeaderText = "Dv";
            this.dvDataGridViewTextBoxColumn.Name = "dvDataGridViewTextBoxColumn";
            this.dvDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDesdeDataGridViewTextBoxColumn
            // 
            this.fechaDesdeDataGridViewTextBoxColumn.DataPropertyName = "FechaDesde";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaDesdeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaDesdeDataGridViewTextBoxColumn.HeaderText = "Fecha Desde";
            this.fechaDesdeDataGridViewTextBoxColumn.Name = "fechaDesdeDataGridViewTextBoxColumn";
            this.fechaDesdeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaHastaDataGridViewTextBoxColumn
            // 
            this.fechaHastaDataGridViewTextBoxColumn.DataPropertyName = "FechaHasta";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.fechaHastaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaHastaDataGridViewTextBoxColumn.HeaderText = "Fecha Hasta";
            this.fechaHastaDataGridViewTextBoxColumn.Name = "fechaHastaDataGridViewTextBoxColumn";
            this.fechaHastaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // anexoIdDataGridViewTextBoxColumn
            // 
            this.anexoIdDataGridViewTextBoxColumn.DataPropertyName = "Anexo_Id";
            this.anexoIdDataGridViewTextBoxColumn.HeaderText = "Anexo_Id";
            this.anexoIdDataGridViewTextBoxColumn.Name = "anexoIdDataGridViewTextBoxColumn";
            this.anexoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // documentoIdDataGridViewTextBoxColumn
            // 
            this.documentoIdDataGridViewTextBoxColumn.DataPropertyName = "Documento_Id";
            this.documentoIdDataGridViewTextBoxColumn.HeaderText = "Documento_Id";
            this.documentoIdDataGridViewTextBoxColumn.Name = "documentoIdDataGridViewTextBoxColumn";
            this.documentoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // apellidoPaternoDataGridViewTextBoxColumn
            // 
            this.apellidoPaternoDataGridViewTextBoxColumn.DataPropertyName = "ApellidoPaterno";
            this.apellidoPaternoDataGridViewTextBoxColumn.HeaderText = "Apellido Paterno";
            this.apellidoPaternoDataGridViewTextBoxColumn.Name = "apellidoPaternoDataGridViewTextBoxColumn";
            this.apellidoPaternoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoMaternoDataGridViewTextBoxColumn
            // 
            this.apellidoMaternoDataGridViewTextBoxColumn.DataPropertyName = "ApellidoMaterno";
            this.apellidoMaternoDataGridViewTextBoxColumn.HeaderText = "Apellido Materno";
            this.apellidoMaternoDataGridViewTextBoxColumn.Name = "apellidoMaternoDataGridViewTextBoxColumn";
            this.apellidoMaternoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comunaCodigoDataGridViewTextBoxColumn
            // 
            this.comunaCodigoDataGridViewTextBoxColumn.DataPropertyName = "Comuna_Codigo";
            this.comunaCodigoDataGridViewTextBoxColumn.HeaderText = "Comuna_Codigo";
            this.comunaCodigoDataGridViewTextBoxColumn.Name = "comunaCodigoDataGridViewTextBoxColumn";
            this.comunaCodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // comunanombreDataGridViewTextBoxColumn
            // 
            this.comunanombreDataGridViewTextBoxColumn.DataPropertyName = "comuna_nombre";
            this.comunanombreDataGridViewTextBoxColumn.HeaderText = "Comuna";
            this.comunanombreDataGridViewTextBoxColumn.Name = "comunanombreDataGridViewTextBoxColumn";
            this.comunanombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaNacimientoDataGridViewTextBoxColumn
            // 
            this.fechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacimiento";
            this.fechaNacimientoDataGridViewTextBoxColumn.Name = "fechaNacimientoDataGridViewTextBoxColumn";
            this.fechaNacimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telFijoDataGridViewTextBoxColumn
            // 
            this.telFijoDataGridViewTextBoxColumn.DataPropertyName = "TelFijo";
            this.telFijoDataGridViewTextBoxColumn.HeaderText = "Teléfono Fijo";
            this.telFijoDataGridViewTextBoxColumn.Name = "telFijoDataGridViewTextBoxColumn";
            this.telFijoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoCivilDataGridViewTextBoxColumn
            // 
            this.estadoCivilDataGridViewTextBoxColumn.DataPropertyName = "EstadoCivil";
            this.estadoCivilDataGridViewTextBoxColumn.HeaderText = "Estado Civil";
            this.estadoCivilDataGridViewTextBoxColumn.Name = "estadoCivilDataGridViewTextBoxColumn";
            this.estadoCivilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vWDOCAnexosBindingSource
            // 
            this.vWDOCAnexosBindingSource.DataSource = typeof(MssBD.VW_DOC_Anexos);
            // 
            // Visar_Anexos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 429);
            this.Controls.Add(this.gridContratos);
            this.Controls.Add(this.gprBusqueda);
            this.Controls.Add(this.ToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visar_Anexos";
            this.Text = "Visar Anexos";
            this.Load += new System.EventHandler(this.DocVisados_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.gprBusqueda.ResumeLayout(false);
            this.gprBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCAnexosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton BtnLimpiar;
        private System.Windows.Forms.GroupBox gprBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FolderBrowserDialog Folder;
        private System.Windows.Forms.DataGridView gridContratos;
        private System.Windows.Forms.BindingSource vWDOCAnexosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoTipoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn porVisarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDesdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anexoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunaCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunanombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telFijoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoCivilDataGridViewTextBoxColumn;
    }
}