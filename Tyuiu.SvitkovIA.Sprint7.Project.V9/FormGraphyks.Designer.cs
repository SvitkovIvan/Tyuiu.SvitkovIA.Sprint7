namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    partial class FormGraphyks_SIA
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
            this.openFileDialog_SIA = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItemHelp_SIA = new System.Windows.Forms.Button();
            this.toolStripMenuItemBack_SIA = new System.Windows.Forms.Button();
            this.сохранитьToolStripMenuItemGraphyks_SIA = new System.Windows.Forms.Button();
            this.saveFileDialog_SIA = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewGraphyks_SIA = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphyks_SIA)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_SIA
            // 
            this.openFileDialog_SIA.FileName = "openFileDialog_SIA";
            // 
            // toolStripMenuItemHelp_SIA
            // 
            this.toolStripMenuItemHelp_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripMenuItemHelp_SIA.Location = new System.Drawing.Point(608, 311);
            this.toolStripMenuItemHelp_SIA.Name = "toolStripMenuItemHelp_SIA";
            this.toolStripMenuItemHelp_SIA.Size = new System.Drawing.Size(100, 37);
            this.toolStripMenuItemHelp_SIA.TabIndex = 0;
            this.toolStripMenuItemHelp_SIA.Text = "Помощь";
            this.toolStripMenuItemHelp_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemHelp_SIA.Click += new System.EventHandler(this.toolStripMenuItemHelp_SIA_Click);
            // 
            // toolStripMenuItemBack_SIA
            // 
            this.toolStripMenuItemBack_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStripMenuItemBack_SIA.Location = new System.Drawing.Point(485, 311);
            this.toolStripMenuItemBack_SIA.Name = "toolStripMenuItemBack_SIA";
            this.toolStripMenuItemBack_SIA.Size = new System.Drawing.Size(95, 37);
            this.toolStripMenuItemBack_SIA.TabIndex = 1;
            this.toolStripMenuItemBack_SIA.Text = "Назад";
            this.toolStripMenuItemBack_SIA.UseVisualStyleBackColor = false;
            this.toolStripMenuItemBack_SIA.Click += new System.EventHandler(this.toolStripMenuItemBack_SIA_Click);
            // 
            // сохранитьToolStripMenuItemGraphyks_SIA
            // 
            this.сохранитьToolStripMenuItemGraphyks_SIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.сохранитьToolStripMenuItemGraphyks_SIA.Location = new System.Drawing.Point(328, 311);
            this.сохранитьToolStripMenuItemGraphyks_SIA.Name = "сохранитьToolStripMenuItemGraphyks_SIA";
            this.сохранитьToolStripMenuItemGraphyks_SIA.Size = new System.Drawing.Size(103, 37);
            this.сохранитьToolStripMenuItemGraphyks_SIA.TabIndex = 2;
            this.сохранитьToolStripMenuItemGraphyks_SIA.Text = "Сохранить";
            this.сохранитьToolStripMenuItemGraphyks_SIA.UseVisualStyleBackColor = false;
            this.сохранитьToolStripMenuItemGraphyks_SIA.Click += new System.EventHandler(this.сохранитьToolStripMenuItemGraphyks_SIA_Click);
            // 
            // dataGridViewGraphyks_SIA
            // 
            this.dataGridViewGraphyks_SIA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphyks_SIA.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGraphyks_SIA.Name = "dataGridViewGraphyks_SIA";
            this.dataGridViewGraphyks_SIA.RowHeadersWidth = 51;
            this.dataGridViewGraphyks_SIA.RowTemplate.Height = 24;
            this.dataGridViewGraphyks_SIA.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewGraphyks_SIA.TabIndex = 3;
            // 
            // FormGraphyks_SIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewGraphyks_SIA);
            this.Controls.Add(this.сохранитьToolStripMenuItemGraphyks_SIA);
            this.Controls.Add(this.toolStripMenuItemBack_SIA);
            this.Controls.Add(this.toolStripMenuItemHelp_SIA);
            this.Name = "FormGraphyks_SIA";
            this.Text = "FormGraphyks";
            this.Load += new System.EventHandler(this.FormGraphyks_SIA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphyks_SIA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_SIA;
        private System.Windows.Forms.Button toolStripMenuItemHelp_SIA;
        private System.Windows.Forms.Button toolStripMenuItemBack_SIA;
        private System.Windows.Forms.Button сохранитьToolStripMenuItemGraphyks_SIA;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_SIA;
        private System.Windows.Forms.DataGridView dataGridViewGraphyks_SIA;
    }
}