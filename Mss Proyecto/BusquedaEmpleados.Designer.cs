namespace Mss_Proyecto
{
    partial class BusquedaEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusquedaEmpleados));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDv = new Mss_Proyecto.Int32TextBox();
            this.txtRut = new Mss_Proyecto.Int32TextBox();
            this.cboCentroCostos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.gridEmpleados = new System.Windows.Forms.DataGridView();
            this.rutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMaternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centroNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paisNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionnombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincianombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunanombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paisCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provinciaCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comunaCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telFijoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telCelularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreContactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentescoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoContratoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cursoOS10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credencialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calzadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pantalonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poleraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casacaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corbataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cazadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centroCostoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vwEmpleadosTodosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.cboRegiones = new System.Windows.Forms.ComboBox();
            this.cboComunas = new System.Windows.Forms.ComboBox();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEmpleadosTodosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDv);
            this.panel1.Controls.Add(this.txtRut);
            this.panel1.Controls.Add(this.cboCentroCostos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtApellidos);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 117);
            this.panel1.TabIndex = 0;
            // 
            // txtDv
            // 
            this.txtDv.Location = new System.Drawing.Point(235, 13);
            this.txtDv.Name = "txtDv";
            this.txtDv.Size = new System.Drawing.Size(34, 20);
            this.txtDv.TabIndex = 15;
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(117, 13);
            this.txtRut.MaxLength = 9;
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(112, 20);
            this.txtRut.TabIndex = 14;
            this.txtRut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRut.TextChanged += new System.EventHandler(this.txtRut_TextChanged);
            // 
            // cboCentroCostos
            // 
            this.cboCentroCostos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroCostos.FormattingEnabled = true;
            this.cboCentroCostos.Location = new System.Drawing.Point(24, 84);
            this.cboCentroCostos.Name = "cboCentroCostos";
            this.cboCentroCostos.Size = new System.Drawing.Size(280, 21);
            this.cboCentroCostos.TabIndex = 13;
            this.cboCentroCostos.SelectedIndexChanged += new System.EventHandler(this.cboCentroCostos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Centro de costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
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
            this.txtApellidos.TabIndex = 2;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // gridEmpleados
            // 
            this.gridEmpleados.AllowUserToAddRows = false;
            this.gridEmpleados.AllowUserToDeleteRows = false;
            this.gridEmpleados.AutoGenerateColumns = false;
            this.gridEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rutDataGridViewTextBoxColumn,
            this.dvDataGridViewTextBoxColumn,
            this.apellidoPaternoDataGridViewTextBoxColumn,
            this.apellidoMaternoDataGridViewTextBoxColumn,
            this.nombresDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.centroNombreDataGridViewTextBoxColumn,
            this.paisNombreDataGridViewTextBoxColumn,
            this.regionnombreDataGridViewTextBoxColumn,
            this.provincianombreDataGridViewTextBoxColumn,
            this.comunanombreDataGridViewTextBoxColumn,
            this.paisCodigoDataGridViewTextBoxColumn,
            this.regionCodigoDataGridViewTextBoxColumn,
            this.provinciaCodigoDataGridViewTextBoxColumn,
            this.comunaCodigoDataGridViewTextBoxColumn,
            this.fechaNacimientoDataGridViewTextBoxColumn,
            this.telFijoDataGridViewTextBoxColumn,
            this.telCelularDataGridViewTextBoxColumn,
            this.nombreContactoDataGridViewTextBoxColumn,
            this.parentescoDataGridViewTextBoxColumn,
            this.tipoContratoDataGridViewTextBoxColumn,
            this.fechaIngresoDataGridViewTextBoxColumn,
            this.cursoOS10DataGridViewTextBoxColumn,
            this.credencialDataGridViewTextBoxColumn,
            this.fechaVencimientoDataGridViewTextBoxColumn,
            this.calzadoDataGridViewTextBoxColumn,
            this.pantalonDataGridViewTextBoxColumn,
            this.poleraDataGridViewTextBoxColumn,
            this.polarDataGridViewTextBoxColumn,
            this.casacaDataGridViewTextBoxColumn,
            this.corbataDataGridViewTextBoxColumn,
            this.gorroDataGridViewTextBoxColumn,
            this.cazadoraDataGridViewTextBoxColumn,
            this.centroCostoIdDataGridViewTextBoxColumn,
            this.usuarioIdDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn});
            this.gridEmpleados.DataSource = this.vwEmpleadosTodosBindingSource;
            this.gridEmpleados.Location = new System.Drawing.Point(12, 135);
            this.gridEmpleados.Name = "gridEmpleados";
            this.gridEmpleados.ReadOnly = true;
            this.gridEmpleados.RowHeadersVisible = false;
            this.gridEmpleados.Size = new System.Drawing.Size(694, 377);
            this.gridEmpleados.TabIndex = 1;
            // 
            // rutDataGridViewTextBoxColumn
            // 
            this.rutDataGridViewTextBoxColumn.DataPropertyName = "Rut";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.rutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.rutDataGridViewTextBoxColumn.Frozen = true;
            this.rutDataGridViewTextBoxColumn.HeaderText = "Rut";
            this.rutDataGridViewTextBoxColumn.Name = "rutDataGridViewTextBoxColumn";
            this.rutDataGridViewTextBoxColumn.ReadOnly = true;
            this.rutDataGridViewTextBoxColumn.Width = 60;
            // 
            // dvDataGridViewTextBoxColumn
            // 
            this.dvDataGridViewTextBoxColumn.DataPropertyName = "Dv";
            this.dvDataGridViewTextBoxColumn.Frozen = true;
            this.dvDataGridViewTextBoxColumn.HeaderText = "Dv";
            this.dvDataGridViewTextBoxColumn.Name = "dvDataGridViewTextBoxColumn";
            this.dvDataGridViewTextBoxColumn.ReadOnly = true;
            this.dvDataGridViewTextBoxColumn.Width = 30;
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
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // centroNombreDataGridViewTextBoxColumn
            // 
            this.centroNombreDataGridViewTextBoxColumn.DataPropertyName = "CentroNombre";
            this.centroNombreDataGridViewTextBoxColumn.HeaderText = "Centro de Costo";
            this.centroNombreDataGridViewTextBoxColumn.Name = "centroNombreDataGridViewTextBoxColumn";
            this.centroNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paisNombreDataGridViewTextBoxColumn
            // 
            this.paisNombreDataGridViewTextBoxColumn.DataPropertyName = "Pais_Nombre";
            this.paisNombreDataGridViewTextBoxColumn.HeaderText = "Pais";
            this.paisNombreDataGridViewTextBoxColumn.Name = "paisNombreDataGridViewTextBoxColumn";
            this.paisNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // regionnombreDataGridViewTextBoxColumn
            // 
            this.regionnombreDataGridViewTextBoxColumn.DataPropertyName = "region_nombre";
            this.regionnombreDataGridViewTextBoxColumn.HeaderText = "Región";
            this.regionnombreDataGridViewTextBoxColumn.Name = "regionnombreDataGridViewTextBoxColumn";
            this.regionnombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // provincianombreDataGridViewTextBoxColumn
            // 
            this.provincianombreDataGridViewTextBoxColumn.DataPropertyName = "provincia_nombre";
            this.provincianombreDataGridViewTextBoxColumn.HeaderText = "Provincia";
            this.provincianombreDataGridViewTextBoxColumn.Name = "provincianombreDataGridViewTextBoxColumn";
            this.provincianombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comunanombreDataGridViewTextBoxColumn
            // 
            this.comunanombreDataGridViewTextBoxColumn.DataPropertyName = "comuna_nombre";
            this.comunanombreDataGridViewTextBoxColumn.HeaderText = "Comuna";
            this.comunanombreDataGridViewTextBoxColumn.Name = "comunanombreDataGridViewTextBoxColumn";
            this.comunanombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paisCodigoDataGridViewTextBoxColumn
            // 
            this.paisCodigoDataGridViewTextBoxColumn.DataPropertyName = "Pais_Codigo";
            this.paisCodigoDataGridViewTextBoxColumn.HeaderText = "Pais_Codigo";
            this.paisCodigoDataGridViewTextBoxColumn.Name = "paisCodigoDataGridViewTextBoxColumn";
            this.paisCodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.paisCodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // regionCodigoDataGridViewTextBoxColumn
            // 
            this.regionCodigoDataGridViewTextBoxColumn.DataPropertyName = "Region_Codigo";
            this.regionCodigoDataGridViewTextBoxColumn.HeaderText = "Region_Codigo";
            this.regionCodigoDataGridViewTextBoxColumn.Name = "regionCodigoDataGridViewTextBoxColumn";
            this.regionCodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.regionCodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // provinciaCodigoDataGridViewTextBoxColumn
            // 
            this.provinciaCodigoDataGridViewTextBoxColumn.DataPropertyName = "Provincia_Codigo";
            this.provinciaCodigoDataGridViewTextBoxColumn.HeaderText = "Provincia_Codigo";
            this.provinciaCodigoDataGridViewTextBoxColumn.Name = "provinciaCodigoDataGridViewTextBoxColumn";
            this.provinciaCodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.provinciaCodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // comunaCodigoDataGridViewTextBoxColumn
            // 
            this.comunaCodigoDataGridViewTextBoxColumn.DataPropertyName = "Comuna_Codigo";
            this.comunaCodigoDataGridViewTextBoxColumn.HeaderText = "Comuna_Codigo";
            this.comunaCodigoDataGridViewTextBoxColumn.Name = "comunaCodigoDataGridViewTextBoxColumn";
            this.comunaCodigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.comunaCodigoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaNacimientoDataGridViewTextBoxColumn
            // 
            this.fechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = "19000101";
            this.fechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Nacimiento";
            this.fechaNacimientoDataGridViewTextBoxColumn.Name = "fechaNacimientoDataGridViewTextBoxColumn";
            this.fechaNacimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telFijoDataGridViewTextBoxColumn
            // 
            this.telFijoDataGridViewTextBoxColumn.DataPropertyName = "TelFijo";
            dataGridViewCellStyle3.NullValue = "0";
            this.telFijoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.telFijoDataGridViewTextBoxColumn.HeaderText = "TelFijo";
            this.telFijoDataGridViewTextBoxColumn.Name = "telFijoDataGridViewTextBoxColumn";
            this.telFijoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telCelularDataGridViewTextBoxColumn
            // 
            this.telCelularDataGridViewTextBoxColumn.DataPropertyName = "TelCelular";
            dataGridViewCellStyle4.NullValue = "0";
            this.telCelularDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.telCelularDataGridViewTextBoxColumn.HeaderText = "TelCelular";
            this.telCelularDataGridViewTextBoxColumn.Name = "telCelularDataGridViewTextBoxColumn";
            this.telCelularDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreContactoDataGridViewTextBoxColumn
            // 
            this.nombreContactoDataGridViewTextBoxColumn.DataPropertyName = "NombreContacto";
            this.nombreContactoDataGridViewTextBoxColumn.HeaderText = "Nombre Contacto";
            this.nombreContactoDataGridViewTextBoxColumn.Name = "nombreContactoDataGridViewTextBoxColumn";
            this.nombreContactoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // parentescoDataGridViewTextBoxColumn
            // 
            this.parentescoDataGridViewTextBoxColumn.DataPropertyName = "Parentesco";
            this.parentescoDataGridViewTextBoxColumn.HeaderText = "Parentesco";
            this.parentescoDataGridViewTextBoxColumn.Name = "parentescoDataGridViewTextBoxColumn";
            this.parentescoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoContratoDataGridViewTextBoxColumn
            // 
            this.tipoContratoDataGridViewTextBoxColumn.DataPropertyName = "TipoContrato";
            this.tipoContratoDataGridViewTextBoxColumn.HeaderText = "Tipo Contrato";
            this.tipoContratoDataGridViewTextBoxColumn.Name = "tipoContratoDataGridViewTextBoxColumn";
            this.tipoContratoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaIngresoDataGridViewTextBoxColumn
            // 
            this.fechaIngresoDataGridViewTextBoxColumn.DataPropertyName = "FechaIngreso";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = "19000101";
            this.fechaIngresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaIngresoDataGridViewTextBoxColumn.HeaderText = "Fecha Ingreso";
            this.fechaIngresoDataGridViewTextBoxColumn.Name = "fechaIngresoDataGridViewTextBoxColumn";
            this.fechaIngresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cursoOS10DataGridViewTextBoxColumn
            // 
            this.cursoOS10DataGridViewTextBoxColumn.DataPropertyName = "CursoOS10";
            this.cursoOS10DataGridViewTextBoxColumn.HeaderText = "Curso OS 10";
            this.cursoOS10DataGridViewTextBoxColumn.Name = "cursoOS10DataGridViewTextBoxColumn";
            this.cursoOS10DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // credencialDataGridViewTextBoxColumn
            // 
            this.credencialDataGridViewTextBoxColumn.DataPropertyName = "Credencial";
            this.credencialDataGridViewTextBoxColumn.HeaderText = "Credencial";
            this.credencialDataGridViewTextBoxColumn.Name = "credencialDataGridViewTextBoxColumn";
            this.credencialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaVencimientoDataGridViewTextBoxColumn
            // 
            this.fechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaVencimiento";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = "0";
            this.fechaVencimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaVencimientoDataGridViewTextBoxColumn.HeaderText = "FechaVencimiento";
            this.fechaVencimientoDataGridViewTextBoxColumn.Name = "fechaVencimientoDataGridViewTextBoxColumn";
            this.fechaVencimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calzadoDataGridViewTextBoxColumn
            // 
            this.calzadoDataGridViewTextBoxColumn.DataPropertyName = "Calzado";
            this.calzadoDataGridViewTextBoxColumn.HeaderText = "Calzado";
            this.calzadoDataGridViewTextBoxColumn.Name = "calzadoDataGridViewTextBoxColumn";
            this.calzadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pantalonDataGridViewTextBoxColumn
            // 
            this.pantalonDataGridViewTextBoxColumn.DataPropertyName = "Pantalon";
            this.pantalonDataGridViewTextBoxColumn.HeaderText = "Pantalon";
            this.pantalonDataGridViewTextBoxColumn.Name = "pantalonDataGridViewTextBoxColumn";
            this.pantalonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // poleraDataGridViewTextBoxColumn
            // 
            this.poleraDataGridViewTextBoxColumn.DataPropertyName = "Polera";
            this.poleraDataGridViewTextBoxColumn.HeaderText = "Polera";
            this.poleraDataGridViewTextBoxColumn.Name = "poleraDataGridViewTextBoxColumn";
            this.poleraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // polarDataGridViewTextBoxColumn
            // 
            this.polarDataGridViewTextBoxColumn.DataPropertyName = "Polar";
            this.polarDataGridViewTextBoxColumn.HeaderText = "Polar";
            this.polarDataGridViewTextBoxColumn.Name = "polarDataGridViewTextBoxColumn";
            this.polarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // casacaDataGridViewTextBoxColumn
            // 
            this.casacaDataGridViewTextBoxColumn.DataPropertyName = "Casaca";
            this.casacaDataGridViewTextBoxColumn.HeaderText = "Casaca";
            this.casacaDataGridViewTextBoxColumn.Name = "casacaDataGridViewTextBoxColumn";
            this.casacaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // corbataDataGridViewTextBoxColumn
            // 
            this.corbataDataGridViewTextBoxColumn.DataPropertyName = "Corbata";
            this.corbataDataGridViewTextBoxColumn.HeaderText = "Corbata";
            this.corbataDataGridViewTextBoxColumn.Name = "corbataDataGridViewTextBoxColumn";
            this.corbataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gorroDataGridViewTextBoxColumn
            // 
            this.gorroDataGridViewTextBoxColumn.DataPropertyName = "Gorro";
            this.gorroDataGridViewTextBoxColumn.HeaderText = "Gorro";
            this.gorroDataGridViewTextBoxColumn.Name = "gorroDataGridViewTextBoxColumn";
            this.gorroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cazadoraDataGridViewTextBoxColumn
            // 
            this.cazadoraDataGridViewTextBoxColumn.DataPropertyName = "Cazadora";
            this.cazadoraDataGridViewTextBoxColumn.HeaderText = "Cazadora";
            this.cazadoraDataGridViewTextBoxColumn.Name = "cazadoraDataGridViewTextBoxColumn";
            this.cazadoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // centroCostoIdDataGridViewTextBoxColumn
            // 
            this.centroCostoIdDataGridViewTextBoxColumn.DataPropertyName = "CentroCosto_Id";
            this.centroCostoIdDataGridViewTextBoxColumn.HeaderText = "CentroCosto_Id";
            this.centroCostoIdDataGridViewTextBoxColumn.Name = "centroCostoIdDataGridViewTextBoxColumn";
            this.centroCostoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.centroCostoIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioIdDataGridViewTextBoxColumn
            // 
            this.usuarioIdDataGridViewTextBoxColumn.DataPropertyName = "Usuario_Id";
            this.usuarioIdDataGridViewTextBoxColumn.HeaderText = "Usuario_Id";
            this.usuarioIdDataGridViewTextBoxColumn.Name = "usuarioIdDataGridViewTextBoxColumn";
            this.usuarioIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vwEmpleadosTodosBindingSource
            // 
            this.vwEmpleadosTodosBindingSource.DataSource = typeof(MssBD.Vw_EmpleadosTodos);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPais);
            this.groupBox1.Controls.Add(this.cboRegiones);
            this.groupBox1.Controls.Add(this.cboComunas);
            this.groupBox1.Controls.Add(this.cboProvincias);
            this.groupBox1.Location = new System.Drawing.Point(358, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 100);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Localidad";
            this.groupBox1.Visible = false;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.Enabled = false;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(6, 14);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(108, 21);
            this.cboPais.TabIndex = 12;
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged_1);
            // 
            // cboRegiones
            // 
            this.cboRegiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegiones.FormattingEnabled = true;
            this.cboRegiones.Location = new System.Drawing.Point(124, 14);
            this.cboRegiones.Name = "cboRegiones";
            this.cboRegiones.Size = new System.Drawing.Size(209, 21);
            this.cboRegiones.TabIndex = 9;
            this.cboRegiones.SelectedIndexChanged += new System.EventHandler(this.cboRegiones_SelectedIndexChanged);
            // 
            // cboComunas
            // 
            this.cboComunas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComunas.FormattingEnabled = true;
            this.cboComunas.Location = new System.Drawing.Point(118, 68);
            this.cboComunas.Name = "cboComunas";
            this.cboComunas.Size = new System.Drawing.Size(215, 21);
            this.cboComunas.TabIndex = 11;
            // 
            // cboProvincias
            // 
            this.cboProvincias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Location = new System.Drawing.Point(118, 41);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(215, 21);
            this.cboProvincias.TabIndex = 10;
            this.cboProvincias.SelectedIndexChanged += new System.EventHandler(this.cboProvincias_SelectedIndexChanged);
            // 
            // BusquedaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridEmpleados);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusquedaEmpleados";
            this.Text = "Historial Personal";
            this.Load += new System.EventHandler(this.Busqueda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEmpleadosTodosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.DataGridView gridEmpleados;
        private System.Windows.Forms.ComboBox cboCentroCostos;
        private Int32TextBox txtDv;
        private Int32TextBox txtRut;
        private System.Windows.Forms.BindingSource vwEmpleadosTodosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.ComboBox cboRegiones;
        private System.Windows.Forms.ComboBox cboComunas;
        private System.Windows.Forms.ComboBox cboProvincias;
        private System.Windows.Forms.DataGridViewTextBoxColumn telContactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centroNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionnombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincianombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunanombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provinciaCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comunaCodigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telFijoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telCelularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreContactoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentescoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoContratoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursoOS10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn credencialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calzadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pantalonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn poleraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn casacaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn corbataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cazadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn centroCostoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}