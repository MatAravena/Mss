namespace Mss_Proyecto
{
    partial class Visar_Finiquitos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visar_Finiquitos));
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
            this.documentoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoTipoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porVisarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutaFinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finiquitoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloNumeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunaCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunanombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vacacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vWDOCFiniquitosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ToolBar.SuspendLayout();
            this.gprBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCFiniquitosBindingSource)).BeginInit();
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
            this.ToolBar.Text = "Buscar";
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
            this.documentoIdDataGridViewTextBoxColumn,
            this.documentoTipoIdDataGridViewTextBoxColumn,
            this.usuarioIdDataGridViewTextBoxColumn,
            this.personalIdDataGridViewTextBoxColumn,
            this.porVisarDataGridViewCheckBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.rutaFinalDataGridViewTextBoxColumn,
            this.finiquitoIdDataGridViewTextBoxColumn,
            this.rutDataGridViewTextBoxColumn,
            this.dvDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.apellidoPaternoDataGridViewTextBoxColumn,
            this.apellidoMaternoDataGridViewTextBoxColumn,
            this.articuloDataGridViewTextBoxColumn,
            this.articuloNumeroDataGridViewTextBoxColumn,
            this.comentarioDataGridViewTextBoxColumn,
            this.comunaCodigoDataGridViewTextBoxColumn,
            this.comunanombreDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.fechaVencimientoDataGridViewTextBoxColumn,
            this.vacacionesDataGridViewTextBoxColumn});
            this.gridContratos.DataSource = this.vWDOCFiniquitosBindingSource;
            this.gridContratos.Location = new System.Drawing.Point(12, 93);
            this.gridContratos.Name = "gridContratos";
            this.gridContratos.RowHeadersVisible = false;
            this.gridContratos.Size = new System.Drawing.Size(922, 324);
            this.gridContratos.TabIndex = 34;
            this.gridContratos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContratos_CellDoubleClick);
            this.gridContratos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContratos_CellValueChanged);
            this.gridContratos.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridContratos_CurrentCellDirtyStateChanged);
            // 
            // documentoIdDataGridViewTextBoxColumn
            // 
            this.documentoIdDataGridViewTextBoxColumn.DataPropertyName = "Documento_Id";
            this.documentoIdDataGridViewTextBoxColumn.HeaderText = "Documento_Id";
            this.documentoIdDataGridViewTextBoxColumn.Name = "documentoIdDataGridViewTextBoxColumn";
            this.documentoIdDataGridViewTextBoxColumn.Visible = false;
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
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha Finiquito";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rutaFinalDataGridViewTextBoxColumn
            // 
            this.rutaFinalDataGridViewTextBoxColumn.DataPropertyName = "RutaFinal";
            this.rutaFinalDataGridViewTextBoxColumn.HeaderText = "RutaFinal";
            this.rutaFinalDataGridViewTextBoxColumn.Name = "rutaFinalDataGridViewTextBoxColumn";
            this.rutaFinalDataGridViewTextBoxColumn.Visible = false;
            // 
            // finiquitoIdDataGridViewTextBoxColumn
            // 
            this.finiquitoIdDataGridViewTextBoxColumn.DataPropertyName = "Finiquito_Id";
            this.finiquitoIdDataGridViewTextBoxColumn.HeaderText = "Finiquito_Id";
            this.finiquitoIdDataGridViewTextBoxColumn.Name = "finiquitoIdDataGridViewTextBoxColumn";
            this.finiquitoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // rutDataGridViewTextBoxColumn
            // 
            this.rutDataGridViewTextBoxColumn.DataPropertyName = "Rut";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.rutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rutDataGridViewTextBoxColumn.HeaderText = "Rut";
            this.rutDataGridViewTextBoxColumn.Name = "rutDataGridViewTextBoxColumn";
            // 
            // dvDataGridViewTextBoxColumn
            // 
            this.dvDataGridViewTextBoxColumn.DataPropertyName = "Dv";
            this.dvDataGridViewTextBoxColumn.HeaderText = "Dv";
            this.dvDataGridViewTextBoxColumn.Name = "dvDataGridViewTextBoxColumn";
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            this.nombresDataGridViewTextBoxColumn.ReadOnly = true;
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
            // articuloDataGridViewTextBoxColumn
            // 
            this.articuloDataGridViewTextBoxColumn.DataPropertyName = "Articulo";
            this.articuloDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.articuloDataGridViewTextBoxColumn.Name = "articuloDataGridViewTextBoxColumn";
            this.articuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // articuloNumeroDataGridViewTextBoxColumn
            // 
            this.articuloNumeroDataGridViewTextBoxColumn.DataPropertyName = "Articulo_Numero";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.articuloNumeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.articuloNumeroDataGridViewTextBoxColumn.HeaderText = "Articulo Número";
            this.articuloNumeroDataGridViewTextBoxColumn.Name = "articuloNumeroDataGridViewTextBoxColumn";
            this.articuloNumeroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
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
            // fechaIngresoDataGridViewTextBoxColumn
            // 
            this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "FechaIngreso";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.fechaIngresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "Fecha Ingreso";
            this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
            this.fechaIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaVencimientoDataGridViewTextBoxColumn
            // 
            this.fechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaVencimiento";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fechaVencimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaVencimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Vencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.Name = "fechaVencimientoDataGridViewTextBoxColumn";
            this.fechaVencimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vacacionesDataGridViewTextBoxColumn
            // 
            this.vacacionesDataGridViewTextBoxColumn.DataPropertyName = "Vacaciones";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.vacacionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.vacacionesDataGridViewTextBoxColumn.HeaderText = "Vacaciones Proporcionales";
            this.vacacionesDataGridViewTextBoxColumn.Name = "vacacionesDataGridViewTextBoxColumn";
            this.vacacionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vWDOCFiniquitosBindingSource
            // 
            this.vWDOCFiniquitosBindingSource.DataSource = typeof(MssBD.VW_DOC_Finiquitos);
            // 
            // Visar_Finiquitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 429);
            this.Controls.Add(this.gridContratos);
            this.Controls.Add(this.gprBusqueda);
            this.Controls.Add(this.ToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visar_Finiquitos";
            this.Text = "Visar Finiquitos";
            this.Load += new System.EventHandler(this.DocVisados_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.gprBusqueda.ResumeLayout(false);
            this.gprBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWDOCFiniquitosBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource vWDOCFiniquitosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoTipoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn porVisarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaFinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finiquitoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloNumeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunaCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunanombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vacacionesDataGridViewTextBoxColumn;
    }
}