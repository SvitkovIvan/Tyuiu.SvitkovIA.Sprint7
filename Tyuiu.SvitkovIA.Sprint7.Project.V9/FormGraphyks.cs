using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            buttonDelete_SIA.Visible = false;
            buttonAdd_SIA.Visible = false;
            buttonAddGraphyks_SIA.Visible = false;
            buttonDeleteGraphyks_SIA.Visible = false;
            splitContainer1.Visible = false;
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
        static string[,] matrix;
        DataService ds = new DataService();
        private void buttonOpenFile_URI_Click(object sender, EventArgs e)
        {
            try
            {
                buttonDelete_SIA.Visible = true;
                buttonAdd_SIA.Visible = true;
                buttonAddGraphyks_SIA.Visible = true;
                buttonDeleteGraphyks_SIA.Visible = true;
                splitContainer1.Visible = true;

                openFileDialog_SIA.ShowDialog();
                openFile = openFileDialog_SIA.FileName;

                matrix = ds.LoadFromDataFile(openFile);
                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);

                dataGridViewGraphyks_SIA.Rows.Clear();
                dataGridViewGraphyks_SIA.Columns.Clear();
                dataGridViewGraphyks_SIA.RowCount = rows + 1;
                dataGridViewGraphyks_SIA.ColumnCount = columns + 10;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewGraphyks_SIA.Rows[i].Cells[j].Value = matrix[i, j];
                        dataGridViewGraphyks_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
                this.dataGridViewGraphyks_SIA.DefaultCellStyle.Font = new Font("Tahoma", 9);
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

        private void buttonAddGraphyks_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewGraphyks_SIA.RowCount != 0)
            {
                if (dataGridViewGraphyks_SIA.RowCount > 2)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewGraphyks_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewGraphyks_SIA.Rows[i].Cells[j].Value != null)
                            {
                                if (dataGridViewGraphyks_SIA.Rows[i].Cells[j].Selected == true)
                                {
                                    nugno = j;
                                    break;
                                }
                            }
                            if (nugno > -1) break;
                        }
                    }

                    if (nugno > -1)
                    {
                        int kaktak = 0;
                        for (int i = 0; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                        {
                            if (dataGridViewGraphyks_SIA.Rows[i].Cells[0].Selected == true) kaktak++;
                        }
                        if (kaktak == 0)
                        {
                            int nadopodumati = 0;
                            for (int i = 1; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewGraphyks_SIA.Rows[i].Cells[nugno].Value != null)
                                {
                                    double cellValue;
                                    if (double.TryParse(dataGridViewGraphyks_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue)) nadopodumati += 0;
                                    else if (dataGridViewGraphyks_SIA.Rows[i].Cells[nugno].ValueType.ToString().Any(char.IsLetter)) nadopodumati++;
                                }
                            }
                            if (nadopodumati == 0)
                            {
                                this.chartFunction_SIA.ChartAreas[0].AxisX.Title = "ID";
                                string name = Convert.ToString(dataGridViewGraphyks_SIA.Rows[0].Cells[nugno].Value);
                                this.chartFunction_SIA.ChartAreas[0].AxisY.Title = name;

                                int startValue = Convert.ToInt32(dataGridViewGraphyks_SIA.Rows[1].Cells[0].Value);
                                for (int i = 1; i < dataGridViewGraphyks_SIA.RowCount - 1; i++)
                                {
                                    this.chartFunction_SIA.Series[0].Points.AddXY(startValue, Convert.ToDouble(dataGridViewGraphyks_SIA.Rows[i].Cells[nugno].Value));
                                    startValue++;
                                }
                            }
                            else MessageBox.Show("Пожалуйста, выберите столбец с числами!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Нельзя выбрать первый столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Нет данных для построения графика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void buttonDeleteGraphyks_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewGraphyks_SIA.RowCount != 0) chartFunction_SIA.Series[0].Points.Clear();
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
    






