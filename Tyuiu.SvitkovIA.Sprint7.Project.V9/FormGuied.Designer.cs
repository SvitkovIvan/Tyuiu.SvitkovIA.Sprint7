namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    partial class FormGuied_SIA
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
            this.toolStripMenuItemBack_SIA = new System.Windows.Forms.Button();
            this.toolStripMenuItemHelp_SIA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toolStripMenuItemBack_SIA
            // 
            this.toolStripMenuItemBack_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemBack_SIA.Location = new System.Drawing.Point(12, 359);
            this.toolStripMenuItemBack_SIA.Name = "toolStripMenuItemBack_SIA";
            this.toolStripMenuItemBack_SIA.Size = new System.Drawing.Size(169, 79);
            this.toolStripMenuItemBack_SIA.TabIndex = 0;
            this.toolStripMenuItemBack_SIA.Text = "Назад";
            this.toolStripMenuItemBack_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemBack_SIA.Click += new System.EventHandler(this.toolStripMenuItemBack_SIA_Click);
            // 
            // toolStripMenuItemHelp_SIA
            // 
            this.toolStripMenuItemHelp_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemHelp_SIA.Location = new System.Drawing.Point(611, 359);
            this.toolStripMenuItemHelp_SIA.Name = "toolStripMenuItemHelp_SIA";
            this.toolStripMenuItemHelp_SIA.Size = new System.Drawing.Size(177, 79);
            this.toolStripMenuItemHelp_SIA.TabIndex = 1;
            this.toolStripMenuItemHelp_SIA.Text = "Помощь";
            this.toolStripMenuItemHelp_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemHelp_SIA.Click += new System.EventHandler(this.toolStripMenuItemHelp_SIA_Click);
            // 
            // FormGuied_SIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 450);
            this.Controls.Add(this.toolStripMenuItemHelp_SIA);
            this.Controls.Add(this.toolStripMenuItemBack_SIA);
            this.Name = "FormGuied_SIA";
            this.Text = "FormGuied_SIA";
            this.Load += new System.EventHandler(this.FormGuied_SIA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toolStripMenuItemBack_SIA;
        private System.Windows.Forms.Button toolStripMenuItemHelp_SIA;
    }
}