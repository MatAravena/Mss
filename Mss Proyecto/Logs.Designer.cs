namespace Mss_Proyecto
{
    partial class Logs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs));
            this.gprBusqueda = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gridLogs = new System.Windows.Forms.DataGridView();
            this.vWLogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gprBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWLogsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gprBusqueda
            // 
            this.gprBusqueda.Controls.Add(this.label1);
            this.gprBusqueda.Controls.Add(this.txtHasta);
            this.gprBusqueda.Controls.Add(this.txtDesde);
            this.gprBusqueda.Controls.Add(this.label2);
            this.gprBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gprBusqueda.Name = "gprBusqueda";
            this.gprBusqueda.Size = new System.Drawing.Size(389, 59);
            this.gprBusqueda.TabIndex = 34;
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
            this.txtHasta.ValueChanged += new System.EventHandler(this.txtHasta_ValueChanged);
            // 
            // txtDesde
            // 
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(90, 19);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(100, 20);
            this.txtDesde.TabIndex = 9;
            this.txtDesde.ValueChanged += new System.EventHandler(this.txtDesde_ValueChanged);
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
            // gridLogs
            // 
            this.gridLogs.AllowUserToAddRows = false;
            this.gridLogs.AllowUserToDeleteRows = false;
            this.gridLogs.AutoGenerateColumns = false;
            this.gridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rutDataGridViewTextBoxColumn,
            this.dvDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.apellidoPaternoDataGridViewTextBoxColumn,
            this.accionDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn});
            this.gridLogs.DataSource = this.vWLogsBindingSource;
            this.gridLogs.Location = new System.Drawing.Point(12, 77);
            this.gridLogs.Name = "gridLogs";
            this.gridLogs.RowHeadersVisible = false;
            this.gridLogs.Size = new System.Drawing.Size(634, 383);
            this.gridLogs.TabIndex = 35;
            // 
            // vWLogsBindingSource
            // 
            this.vWLogsBindingSource.DataSource = typeof(MssBD.VW_Logs);
            // 
            // rutDataGridViewTextBoxColumn
            // 
            this.rutDataGridViewTextBoxColumn.DataPropertyName = "Rut";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.rutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.rutDataGridViewTextBoxColumn.HeaderText = "Rut";
            this.rutDataGridViewTextBoxColumn.Name = "rutDataGridViewTextBoxColumn";
            this.rutDataGridViewTextBoxColumn.Width = 80;
            // 
            // dvDataGridViewTextBoxColumn
            // 
            this.dvDataGridViewTextBoxColumn.DataPropertyName = "Dv";
            this.dvDataGridViewTextBoxColumn.HeaderText = "Dv";
            this.dvDataGridViewTextBoxColumn.Name = "dvDataGridViewTextBoxColumn";
            this.dvDataGridViewTextBoxColumn.Width = 40;
            // 
            // nombresDataGridViewTextBoxColumn
            // 
            this.nombresDataGridViewTextBoxColumn.DataPropertyName = "Nombres";
            this.nombresDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nombresDataGridViewTextBoxColumn.Name = "nombresDataGridViewTextBoxColumn";
            // 
            // apellidoPaternoDataGridViewTextBoxColumn
            // 
            this.apellidoPaternoDataGridViewTextBoxColumn.DataPropertyName = "ApellidoPaterno";
            this.apellidoPaternoDataGridViewTextBoxColumn.HeaderText = "Apellido Paterno";
            this.apellidoPaternoDataGridViewTextBoxColumn.Name = "apellidoPaternoDataGridViewTextBoxColumn";
            // 
            // accionDataGridViewTextBoxColumn
            // 
            this.accionDataGridViewTextBoxColumn.DataPropertyName = "Accion";
            this.accionDataGridViewTextBoxColumn.HeaderText = "Accion";
            this.accionDataGridViewTextBoxColumn.Name = "accionDataGridViewTextBoxColumn";
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 472);
            this.Controls.Add(this.gridLogs);
            this.Controls.Add(this.gprBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logs";
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.Logs_Load);
            this.gprBusqueda.ResumeLayout(false);
            this.gprBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWLogsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gprBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridLogs;
        private System.Windows.Forms.BindingSource vWLogsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    }
}