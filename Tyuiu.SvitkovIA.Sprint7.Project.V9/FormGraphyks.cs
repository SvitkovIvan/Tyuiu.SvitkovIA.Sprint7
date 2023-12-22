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
                    
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewGraphyks_SIA.Rows[i].Cells[j].Value = matrix[i, j];
                        dataGridViewGraphyks_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
                dataGridViewGraphyks_SIA.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveFile_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_SIA.FileName = ".csv";
                saveFileDialog_SIA.InitialDirectory = @":C";
                if (saveFileDialog_SIA.ShowDialog() == DialogResult.OK)
                {
                    string savepath = saveFileDialog_SIA.FileName;

                    if (File.Exists(savepath)) File.Delete(savepath);

                    int rows = dataGridViewGraphyks_SIA.RowCount;
                    int columns = dataGridViewGraphyks_SIA.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewGraphyks_SIA.Rows[i].Cells[j].Value);

                            if (j != columns - 1) strBuilder.Append(";");
                        }
                        strBuilder.AppendLine();
                    }
                    File.WriteAllText(savepath, strBuilder.ToString(), Encoding.GetEncoding(1251));
                    MessageBox.Show("Файл успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Файл не сохранен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewGraphyks_SIA.RowCount != 0)
            {
                int nugno = -1; int udal = 0;
                for (int i = 0; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewGraphyks_SIA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewGraphyks_SIA.Rows[i].Cells[j].Selected == true)
                        {
                            nugno = j;
                            break;
                        }
                    }
                    if (nugno > -1) udal++;
                }
                if (nugno > -1)
                {
                    var result = MessageBox.Show($"{"Удалить данную строку?" + "\r"}{"Ее невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int k = -1;
                        for (int i = 0; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                        {
                            if (dataGridViewGraphyks_SIA.Rows[i].Cells[nugno].Selected == true)
                            {
                                k = i;
                                break;
                            }
                            if (k > -1) break;
                        }
                        for (int r = 0; r < udal; r++) dataGridViewGraphyks_SIA.Rows.Remove(dataGridViewGraphyks_SIA.Rows[k]);
                        for (int i = 0; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridViewGraphyks_SIA.ColumnCount - 1; j++)
                            {
                                dataGridViewGraphyks_SIA.Rows[i].Cells[j].Selected = false;
                            }
                        }
                    }
                }
                else MessageBox.Show("Выберите строку, которую ходите удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAdd_SIA_Click(object sender, EventArgs e)
        {
            try
            {
               dataGridViewGraphyks_SIA.Rows.Add();
            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void открытьToolStripMenuItemGuied_SIA_Click(object sender, EventArgs e)
        {
            FormGuied_SIA formGuied = new FormGuied_SIA();
            formGuied.Show();
        }
    }
}
    






