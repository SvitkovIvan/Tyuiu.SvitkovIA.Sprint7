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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGuied_SIA));
            this.toolStripMenuItemBack_SIA = new System.Windows.Forms.Button();
            this.toolStripMenuItemHelp_SIA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toolStripMenuItemBack_SIA
            // 
            this.toolStripMenuItemBack_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemBack_SIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripMenuItemBack_SIA.Location = new System.Drawing.Point(12, 359);
            this.toolStripMenuItemBack_SIA.Name = "toolStripMenuItemBack_SIA";
            this.toolStripMenuItemBack_SIA.Size = new System.Drawing.Size(180, 79);
            this.toolStripMenuItemBack_SIA.TabIndex = 0;
            this.toolStripMenuItemBack_SIA.Text = "Назад";
            this.toolStripMenuItemBack_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemBack_SIA.Click += new System.EventHandler(this.toolStripMenuItemBack_SIA_Click);
            // 
            // toolStripMenuItemHelp_SIA
            // 
            this.toolStripMenuItemHelp_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemHelp_SIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStripMenuItemHelp_SIA.Location = new System.Drawing.Point(633, 359);
            this.toolStripMenuItemHelp_SIA.Name = "toolStripMenuItemHelp_SIA";
            this.toolStripMenuItemHelp_SIA.Size = new System.Drawing.Size(186, 79);
            this.toolStripMenuItemHelp_SIA.TabIndex = 1;
            this.toolStripMenuItemHelp_SIA.Text = "Справка";
            this.toolStripMenuItemHelp_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemHelp_SIA.Click += new System.EventHandler(this.toolStripMenuItemHelp_SIA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(793, 176);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(9, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(715, 80);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // FormGuied_SIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(851, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripMenuItemHelp_SIA);
            this.Controls.Add(this.toolStripMenuItemBack_SIA);
            this.Name = "FormGuied_SIA";
            this.Text = "Информация о приложении ( условие создания )";
            this.Load += new System.EventHandler(this.FormGuied_SIA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toolStripMenuItemBack_SIA;
        private System.Windows.Forms.Button toolStripMenuItemHelp_SIA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}