using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    public partial class FormGraphyks_SIA : Form
    {
        public FormGraphyks_SIA()
        {
            InitializeComponent();
            openFileDialog_SIA.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Всефайлы(*.*)|*.*";
        }

        private void toolStripMenuItemHelp_SIA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void toolStripMenuItemBack_SIA_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMain_SIA formMain = new FormMain_SIA();
            formMain.Show();
        }

        private void FormGraphyks_SIA_Load(object sender, EventArgs e)
        {
            this.Hide();
            FormMain_SIA formMain = new FormMain_SIA();
            formMain.Show();
        }

        private void сохранитьToolStripMenuItemGraphyks_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_SIA.FileName = ".csv";
                saveFileDialog_SIA.InitialDirectory = @":C";
                saveFileDialog_SIA.ShowDialog();
                string path = saveFileDialog_SIA.FileName;
                FileInfo fileInfo = new FileInfo(path);
                bool fileExists = fileInfo.Exists;
                if (fileExists)
                {
                    File.Delete(path);
                }
            }
            catch
            {
                MessageBox.Show("Файл не сохранен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string openFile;
        static int rows;
        static int columns;
        DataService ds = new DataService();
        private void buttonOpenFile_URI_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_SIA.ShowDialog();
                openFile = openFileDialog_SIA.FileName;

                string[,] matrix = ds.LoadFromDataFile(openFile);
                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);
                dataGridViewGraphyks_SIA.RowCount = 250;
                dataGridViewGraphyks_SIA.ColumnCount = 50;

                for (int i = 0; i < rows; i++)
                {
                    dataGridViewGraphyks_SIA.Columns[i].Width = 135;
                }
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewGraphyks_SIA.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
    

