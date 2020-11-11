namespace CapaVista.Resultados
{
    partial class frmResultado
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
            this.dgvDatosMostrar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosMostrar
            // 
            this.dgvDatosMostrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosMostrar.Location = new System.Drawing.Point(12, 120);
            this.dgvDatosMostrar.Name = "dgvDatosMostrar";
            this.dgvDatosMostrar.RowHeadersWidth = 51;
            this.dgvDatosMostrar.Size = new System.Drawing.Size(776, 318);
            this.dgvDatosMostrar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 14F);
            this.label1.Location = new System.Drawing.Point(281, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Resultado Consulta";
            // 
            // frmResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatosMostrar);
            this.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado de la Consulta";
            this.Load += new System.EventHandler(this.frmResultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDatosMostrar;
        private System.Windows.Forms.Label label1;
    }
}