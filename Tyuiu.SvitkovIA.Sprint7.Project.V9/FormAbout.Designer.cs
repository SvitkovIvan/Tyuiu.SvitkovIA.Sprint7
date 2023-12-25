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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.buttonOK_SIA = new System.Windows.Forms.Button();
            this.pictureBoxInformation_SIA = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInformation_SIA)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK_SIA
            // 
            this.buttonOK_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonOK_SIA.Location = new System.Drawing.Point(684, 422);
            this.buttonOK_SIA.Name = "buttonOK_SIA";
            this.buttonOK_SIA.Size = new System.Drawing.Size(159, 63);
            this.buttonOK_SIA.TabIndex = 0;
            this.buttonOK_SIA.Text = "ОК";
            this.buttonOK_SIA.UseVisualStyleBackColor = false;
            this.buttonOK_SIA.Click += new System.EventHandler(this.buttonOK_SIA_Click);
            // 
            // pictureBoxInformation_SIA
            // 
            this.pictureBoxInformation_SIA.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxInformation_SIA.ErrorImage")));
            this.pictureBoxInformation_SIA.Image = global::Tyuiu.SvitkovIA.Sprint7.Project.V9.Properties.Resources.Разработчик;
            this.pictureBoxInformation_SIA.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxInformation_SIA.InitialImage")));
            this.pictureBoxInformation_SIA.Location = new System.Drawing.Point(3, 12);
            this.pictureBoxInformation_SIA.Name = "pictureBoxInformation_SIA";
            this.pictureBoxInformation_SIA.Size = new System.Drawing.Size(467, 408);
            this.pictureBoxInformation_SIA.TabIndex = 1;
            this.pictureBoxInformation_SIA.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 176);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxInformation_SIA);
            this.Controls.Add(this.buttonOK_SIA);
            this.Name = "FormAbout";
            this.Text = "Справка Разработчика | Свитков И.А. | Спринт 7 | Вариант 9 ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInformation_SIA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK_SIA;
        private System.Windows.Forms.PictureBox pictureBoxInformation_SIA;
        private System.Windows.Forms.Label label1;
    }
}