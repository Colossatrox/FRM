namespace CapaVistaBryan.Mantenimientos
{
    partial class frmPolizas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPolizas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlContCuentasDatos = new System.Windows.Forms.Panel();
            this.pnlTreeView = new System.Windows.Forms.Panel();
            this.tvwCuentas = new System.Windows.Forms.TreeView();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.gbxDatosPoliza = new System.Windows.Forms.GroupBox();
            this.txtCodPeticion = new System.Windows.Forms.TextBox();
            this.btnVerPeticiones = new System.Windows.Forms.Button();
            this.gbxDatosParte = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.rbtnHaber = new System.Windows.Forms.RadioButton();
            this.rbtnDebe = new System.Windows.Forms.RadioButton();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblCodPeticion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.chkPeticion = new System.Windows.Forms.CheckBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvPoliza = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitulo.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.pnlContCuentasDatos.SuspendLayout();
            this.pnlTreeView.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.gbxDatosPoliza.SuspendLayout();
            this.gbxDatosParte.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoliza)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.btnAyuda);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1802, 66);
            this.pnlTitulo.TabIndex = 0;
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.Transparent;
            this.btnAyuda.FlatAppearance.BorderSize = 0;
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAyuda.Image")));
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAyuda.Location = new System.Drawing.Point(12, 2);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(88, 58);
            this.btnAyuda.TabIndex = 18;
            this.btnAyuda.Text = "AYUDA";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAyuda.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(626, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(73, 19);
            this.lblTitulo.TabIndex = 17;
            this.lblTitulo.Text = "PÓLIZAS";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.pnlContCuentasDatos);
            this.pnlContenedor.Controls.Add(this.pnlTabla);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 66);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1802, 622);
            this.pnlContenedor.TabIndex = 1;
            // 
            // pnlContCuentasDatos
            // 
            this.pnlContCuentasDatos.Controls.Add(this.pnlTreeView);
            this.pnlContCuentasDatos.Controls.Add(this.pnlDatos);
            this.pnlContCuentasDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContCuentasDatos.Location = new System.Drawing.Point(0, 0);
            this.pnlContCuentasDatos.Name = "pnlContCuentasDatos";
            this.pnlContCuentasDatos.Size = new System.Drawing.Size(1202, 622);
            this.pnlContCuentasDatos.TabIndex = 1;
            // 
            // pnlTreeView
            // 
            this.pnlTreeView.Controls.Add(this.tvwCuentas);
            this.pnlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTreeView.Location = new System.Drawing.Point(0, 354);
            this.pnlTreeView.Name = "pnlTreeView";
            this.pnlTreeView.Size = new System.Drawing.Size(1202, 268);
            this.pnlTreeView.TabIndex = 1;
            // 
            // tvwCuentas
            // 
            this.tvwCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCuentas.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwCuentas.Location = new System.Drawing.Point(0, 0);
            this.tvwCuentas.Name = "tvwCuentas";
            this.tvwCuentas.Size = new System.Drawing.Size(1202, 268);
            this.tvwCuentas.TabIndex = 12;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.gbxDatosPoliza);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Location = new System.Drawing.Point(0, 0);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1202, 354);
            this.pnlDatos.TabIndex = 0;
            // 
            // gbxDatosPoliza
            // 
            this.gbxDatosPoliza.Controls.Add(this.txtCodPeticion);
            this.gbxDatosPoliza.Controls.Add(this.btnVerPeticiones);
            this.gbxDatosPoliza.Controls.Add(this.gbxDatosParte);
            this.gbxDatosPoliza.Controls.Add(this.btnGuardar);
            this.gbxDatosPoliza.Controls.Add(this.lblCodPeticion);
            this.gbxDatosPoliza.Controls.Add(this.txtDescripcion);
            this.gbxDatosPoliza.Controls.Add(this.chkPeticion);
            this.gbxDatosPoliza.Controls.Add(this.lblDescripcion);
            this.gbxDatosPoliza.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosPoliza.Location = new System.Drawing.Point(3, 6);
            this.gbxDatosPoliza.Name = "gbxDatosPoliza";
            this.gbxDatosPoliza.Size = new System.Drawing.Size(980, 342);
            this.gbxDatosPoliza.TabIndex = 23;
            this.gbxDatosPoliza.TabStop = false;
            this.gbxDatosPoliza.Text = "DATOS DE PÓLIZA";
            // 
            // txtCodPeticion
            // 
            this.txtCodPeticion.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPeticion.Location = new System.Drawing.Point(512, 116);
            this.txtCodPeticion.Name = "txtCodPeticion";
            this.txtCodPeticion.Size = new System.Drawing.Size(228, 25);
            this.txtCodPeticion.TabIndex = 30;
            this.txtCodPeticion.Visible = false;
            this.txtCodPeticion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodPeticion_KeyPress);
            // 
            // btnVerPeticiones
            // 
            this.btnVerPeticiones.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPeticiones.Location = new System.Drawing.Point(766, 120);
            this.btnVerPeticiones.Name = "btnVerPeticiones";
            this.btnVerPeticiones.Size = new System.Drawing.Size(150, 25);
            this.btnVerPeticiones.TabIndex = 31;
            this.btnVerPeticiones.Text = "VER PETICIONES";
            this.btnVerPeticiones.UseVisualStyleBackColor = true;
            this.btnVerPeticiones.Visible = false;
            this.btnVerPeticiones.Click += new System.EventHandler(this.btnVerPeticiones_Click);
            // 
            // gbxDatosParte
            // 
            this.gbxDatosParte.Controls.Add(this.btnAgregar);
            this.gbxDatosParte.Controls.Add(this.rbtnHaber);
            this.gbxDatosParte.Controls.Add(this.rbtnDebe);
            this.gbxDatosParte.Controls.Add(this.lblCuenta);
            this.gbxDatosParte.Controls.Add(this.lblTipoCuenta);
            this.gbxDatosParte.Controls.Add(this.txtCantidad);
            this.gbxDatosParte.Controls.Add(this.lblCantidad);
            this.gbxDatosParte.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatosParte.Location = new System.Drawing.Point(10, 168);
            this.gbxDatosParte.Name = "gbxDatosParte";
            this.gbxDatosParte.Size = new System.Drawing.Size(964, 168);
            this.gbxDatosParte.TabIndex = 26;
            this.gbxDatosParte.TabStop = false;
            this.gbxDatosParte.Text = "DATOS DE PARTE";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(756, 137);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 25);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "AGREGAR PARTE";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // rbtnHaber
            // 
            this.rbtnHaber.AutoSize = true;
            this.rbtnHaber.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHaber.Location = new System.Drawing.Point(146, 111);
            this.rbtnHaber.Name = "rbtnHaber";
            this.rbtnHaber.Size = new System.Drawing.Size(78, 23);
            this.rbtnHaber.TabIndex = 26;
            this.rbtnHaber.TabStop = true;
            this.rbtnHaber.Text = "HABER";
            this.rbtnHaber.UseVisualStyleBackColor = true;
            // 
            // rbtnDebe
            // 
            this.rbtnDebe.AutoSize = true;
            this.rbtnDebe.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDebe.Location = new System.Drawing.Point(146, 82);
            this.rbtnDebe.Name = "rbtnDebe";
            this.rbtnDebe.Size = new System.Drawing.Size(68, 23);
            this.rbtnDebe.TabIndex = 25;
            this.rbtnDebe.TabStop = true;
            this.rbtnDebe.Text = "DEBE";
            this.rbtnDebe.UseVisualStyleBackColor = true;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(237, 143);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(402, 19);
            this.lblCuenta.TabIndex = 24;
            this.lblCuenta.Text = "SELECCIONE UNA CUENTA DEL CUADRO INFERIOR";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCuenta.Location = new System.Drawing.Point(15, 82);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(115, 19);
            this.lblTipoCuenta.TabIndex = 23;
            this.lblTipoCuenta.Text = "SELECCIONE:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(146, 33);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(258, 25);
            this.txtCantidad.TabIndex = 22;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(40, 33);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(90, 17);
            this.lblCantidad.TabIndex = 21;
            this.lblCantidad.Text = "CANTIDAD:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(765, 40);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 25);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "GUARDAR PÓLIZA";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblCodPeticion
            // 
            this.lblCodPeticion.AutoSize = true;
            this.lblCodPeticion.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPeticion.Location = new System.Drawing.Point(332, 120);
            this.lblCodPeticion.Name = "lblCodPeticion";
            this.lblCodPeticion.Size = new System.Drawing.Size(174, 17);
            this.lblCodPeticion.TabIndex = 29;
            this.lblCodPeticion.Text = "CÓDIGO DE PETICIÓN:";
            this.lblCodPeticion.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(155, 25);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(585, 70);
            this.txtDescripcion.TabIndex = 24;
            // 
            // chkPeticion
            // 
            this.chkPeticion.AutoSize = true;
            this.chkPeticion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPeticion.Location = new System.Drawing.Point(29, 116);
            this.chkPeticion.Name = "chkPeticion";
            this.chkPeticion.Size = new System.Drawing.Size(263, 23);
            this.chkPeticion.TabIndex = 28;
            this.chkPeticion.Text = "POLIZA SOBRE UNA PETICIÓN?";
            this.chkPeticion.UseVisualStyleBackColor = true;
            this.chkPeticion.CheckedChanged += new System.EventHandler(this.chkPeticion_CheckedChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(26, 25);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(113, 17);
            this.lblDescripcion.TabIndex = 23;
            this.lblDescripcion.Text = "DESCRIPCIÓN:";
            // 
            // pnlTabla
            // 
            this.pnlTabla.Controls.Add(this.dgvPoliza);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTabla.Location = new System.Drawing.Point(1202, 0);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Size = new System.Drawing.Size(600, 622);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvPoliza
            // 
            this.dgvPoliza.AllowUserToAddRows = false;
            this.dgvPoliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPoliza.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPoliza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPoliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoliza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPoliza.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPoliza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoliza.Location = new System.Drawing.Point(0, 0);
            this.dgvPoliza.Name = "dgvPoliza";
            this.dgvPoliza.ReadOnly = true;
            this.dgvPoliza.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPoliza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoliza.Size = new System.Drawing.Size(600, 622);
            this.dgvPoliza.TabIndex = 0;
            this.dgvPoliza.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPoliza_UserDeletedRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CÓDIGO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 102;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NOMBRE DE CUENTA";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 179;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "DEBE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "HABER";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 85;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "NaturalezaCuenta";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 167;
            // 
            // frmPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(1802, 688);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlTitulo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPolizas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polizas -1311";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContCuentasDatos.ResumeLayout(false);
            this.pnlTreeView.ResumeLayout(false);
            this.pnlDatos.ResumeLayout(false);
            this.gbxDatosPoliza.ResumeLayout(false);
            this.gbxDatosPoliza.PerformLayout();
            this.gbxDatosParte.ResumeLayout(false);
            this.gbxDatosParte.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoliza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlContCuentasDatos;
        private System.Windows.Forms.Panel pnlTreeView;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.TreeView tvwCuentas;
        private System.Windows.Forms.DataGridView dgvPoliza;
        private System.Windows.Forms.GroupBox gbxDatosPoliza;
        private System.Windows.Forms.GroupBox gbxDatosParte;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RadioButton rbtnHaber;
        private System.Windows.Forms.RadioButton rbtnDebe;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnVerPeticiones;
        private System.Windows.Forms.TextBox txtCodPeticion;
        private System.Windows.Forms.Label lblCodPeticion;
        private System.Windows.Forms.CheckBox chkPeticion;
    }
}