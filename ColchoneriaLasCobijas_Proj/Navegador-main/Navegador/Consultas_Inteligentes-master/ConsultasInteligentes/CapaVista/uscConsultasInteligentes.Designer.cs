namespace CapaVista
{
    partial class uscConsultasInteligentes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscConsultasInteligentes));
            this.btnConsultaInteligente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConsultaInteligente
            // 
            this.btnConsultaInteligente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultaInteligente.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultaInteligente.Image")));
            this.btnConsultaInteligente.Location = new System.Drawing.Point(0, 0);
            this.btnConsultaInteligente.Name = "btnConsultaInteligente";
            this.btnConsultaInteligente.Size = new System.Drawing.Size(43, 38);
            this.btnConsultaInteligente.TabIndex = 0;
            this.btnConsultaInteligente.UseVisualStyleBackColor = true;
            this.btnConsultaInteligente.Click += new System.EventHandler(this.btnConsultaInteligente_Click);
            // 
            // uscConsultasInteligentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConsultaInteligente);
            this.Name = "uscConsultasInteligentes";
            this.Size = new System.Drawing.Size(43, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsultaInteligente;
    }
}
