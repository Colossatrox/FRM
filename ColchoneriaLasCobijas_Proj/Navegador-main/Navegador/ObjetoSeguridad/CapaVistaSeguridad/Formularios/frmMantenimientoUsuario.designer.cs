namespace CapaVistaSeguridad.Formularios.Mantenimientos
{
    partial class frmMantenimientoUsuario
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.dtlRegistroUsuario = new System.Windows.Forms.DataGridView();
            this.txtCodigoUsuario = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.navegadorMUsuario = new CapaVistaNavegador.Navegador();
            this.gbxEstado = new System.Windows.Forms.GroupBox();
            this.rbtnDesabilitado = new System.Windows.Forms.RadioButton();
            this.rbtnHabilitado = new System.Windows.Forms.RadioButton();
            this.txtEstado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtlRegistroUsuario)).BeginInit();
            this.gbxEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(29, 230);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(112, 17);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(29, 286);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(29, 340);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(85, 17);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Location = new System.Drawing.Point(29, 385);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(133, 17);
            this.lblNombreCompleto.TabIndex = 4;
            this.lblNombreCompleto.Text = "Nombre Completo:\r\n";
            // 
            // dtlRegistroUsuario
            // 
            this.dtlRegistroUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtlRegistroUsuario.Location = new System.Drawing.Point(596, 220);
            this.dtlRegistroUsuario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtlRegistroUsuario.Name = "dtlRegistroUsuario";
            this.dtlRegistroUsuario.RowHeadersWidth = 51;
            this.dtlRegistroUsuario.RowTemplate.Height = 24;
            this.dtlRegistroUsuario.Size = new System.Drawing.Size(582, 251);
            this.dtlRegistroUsuario.TabIndex = 5;
            this.dtlRegistroUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtl_registro_usuario_CellContentClick);
            // 
            // txtCodigoUsuario
            // 
            this.txtCodigoUsuario.Location = new System.Drawing.Point(279, 230);
            this.txtCodigoUsuario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtCodigoUsuario.Name = "txtCodigoUsuario";
            this.txtCodigoUsuario.Size = new System.Drawing.Size(58, 23);
            this.txtCodigoUsuario.TabIndex = 6;
            this.txtCodigoUsuario.Tag = "pk_id_login";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(279, 286);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 23);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.Tag = "usuario_login";
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(279, 332);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(200, 23);
            this.txtContraseña.TabIndex = 8;
            this.txtContraseña.Tag = "contraseña_login";
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(279, 385);
            this.txtCodigoEmpleado.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(200, 23);
            this.txtCodigoEmpleado.TabIndex = 10;
            this.txtCodigoEmpleado.Tag = "nombreCompleto_login";
            // 
            // navegadorMUsuario
            // 
            this.navegadorMUsuario.BackColor = System.Drawing.Color.Transparent;
            this.navegadorMUsuario.Location = new System.Drawing.Point(4, 32);
            this.navegadorMUsuario.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.navegadorMUsuario.Name = "navegadorMUsuario";
            this.navegadorMUsuario.Size = new System.Drawing.Size(1532, 119);
            this.navegadorMUsuario.TabIndex = 16;
            this.navegadorMUsuario.Load += new System.EventHandler(this.navegadorMUsuario_Load);
            // 
            // gbxEstado
            // 
            this.gbxEstado.Controls.Add(this.rbtnDesabilitado);
            this.gbxEstado.Controls.Add(this.rbtnHabilitado);
            this.gbxEstado.Font = new System.Drawing.Font("Rockwell", 9.75F);
            this.gbxEstado.Location = new System.Drawing.Point(125, 456);
            this.gbxEstado.Margin = new System.Windows.Forms.Padding(4);
            this.gbxEstado.Name = "gbxEstado";
            this.gbxEstado.Padding = new System.Windows.Forms.Padding(4);
            this.gbxEstado.Size = new System.Drawing.Size(388, 80);
            this.gbxEstado.TabIndex = 17;
            this.gbxEstado.TabStop = false;
            this.gbxEstado.Text = "Estado";
            this.gbxEstado.Enter += new System.EventHandler(this.gbxEstado_Enter);
            // 
            // rbtnDesabilitado
            // 
            this.rbtnDesabilitado.AutoSize = true;
            this.rbtnDesabilitado.Location = new System.Drawing.Point(207, 27);
            this.rbtnDesabilitado.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnDesabilitado.Name = "rbtnDesabilitado";
            this.rbtnDesabilitado.Size = new System.Drawing.Size(105, 20);
            this.rbtnDesabilitado.TabIndex = 8;
            this.rbtnDesabilitado.TabStop = true;
            this.rbtnDesabilitado.Text = "Deshabilitado";
            this.rbtnDesabilitado.UseVisualStyleBackColor = true;
            this.rbtnDesabilitado.CheckedChanged += new System.EventHandler(this.rbtnDesabilitado_CheckedChanged);
            // 
            // rbtnHabilitado
            // 
            this.rbtnHabilitado.AutoSize = true;
            this.rbtnHabilitado.Location = new System.Drawing.Point(24, 27);
            this.rbtnHabilitado.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnHabilitado.Name = "rbtnHabilitado";
            this.rbtnHabilitado.Size = new System.Drawing.Size(85, 20);
            this.rbtnHabilitado.TabIndex = 7;
            this.rbtnHabilitado.TabStop = true;
            this.rbtnHabilitado.Text = "Habilitado";
            this.rbtnHabilitado.UseVisualStyleBackColor = true;
            this.rbtnHabilitado.CheckedChanged += new System.EventHandler(this.rbtnHabilitado_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(33, 444);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(65, 23);
            this.txtEstado.TabIndex = 19;
            this.txtEstado.Tag = "estado_login";
            this.txtEstado.Visible = false;
            // 
            // frmMantenimientoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1345, 549);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.gbxEstado);
            this.Controls.Add(this.navegadorMUsuario);
            this.Controls.Add(this.txtCodigoEmpleado);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtCodigoUsuario);
            this.Controls.Add(this.dtlRegistroUsuario);
            this.Controls.Add(this.lblNombreCompleto);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblCodigo);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "frmMantenimientoUsuario";
            this.Text = "0002-Mantenimiento Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.dtlRegistroUsuario)).EndInit();
            this.gbxEstado.ResumeLayout(false);
            this.gbxEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.DataGridView dtlRegistroUsuario;
        private System.Windows.Forms.TextBox txtCodigoUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtCodigoEmpleado;
        private CapaVistaNavegador.Navegador navegadorMUsuario;
        private System.Windows.Forms.GroupBox gbxEstado;
        private System.Windows.Forms.RadioButton rbtnDesabilitado;
        private System.Windows.Forms.RadioButton rbtnHabilitado;
        private System.Windows.Forms.TextBox txtEstado;
    }
}