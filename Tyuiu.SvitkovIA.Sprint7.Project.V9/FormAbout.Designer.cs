namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    partial class FormAbout
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
            this.buttonOK_SIA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK_SIA
            // 
            this.buttonOK_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonOK_SIA.Location = new System.Drawing.Point(646, 377);
            this.buttonOK_SIA.Name = "buttonOK_SIA";
            this.buttonOK_SIA.Size = new System.Drawing.Size(131, 52);
            this.buttonOK_SIA.TabIndex = 0;
            this.buttonOK_SIA.Text = "ОК";
            this.buttonOK_SIA.UseVisualStyleBackColor = false;
            this.buttonOK_SIA.Click += new System.EventHandler(this.buttonOK_SIA_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 450);
            this.Controls.Add(this.buttonOK_SIA);
            this.Name = "FormAbout";
            this.Text = "FormAbout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK_SIA;
    }
}