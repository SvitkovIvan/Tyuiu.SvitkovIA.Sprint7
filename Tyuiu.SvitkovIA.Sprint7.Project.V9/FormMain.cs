using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    public partial class FormMain_SIA : Form
    {


        public FormMain_SIA()
        {
            InitializeComponent();

        }



        private void toolStripMenuItemHelp_SIA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void перейтиКРазделуToolStripMenuItem_SIA_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGraphyks_SIA formGraphyks = new FormGraphyks_SIA();
            formGraphyks.Show();
        }

        private void открытьToolStripMenuItemGuied_SIA_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGuied_SIA formGuied = new FormGuied_SIA();
            formGuied.Show();
        }

        static string openFile;
        static int rows;
        static int columns;
        static string[,] matrix;
        DataService ds = new DataService();

        private void открытьToolStripMenuItemFile_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_SIA.ShowDialog();
                openFile = openFileDialog_SIA.FileName;

                matrix = ds.LoadFromDataFile(openFile);
                rows = matrix.GetLength(0);
                columns = matrix.GetLength(1);
                dataGridViewOpenFile_SIA.RowCount = 250;
                dataGridViewOpenFile_SIA.ColumnCount = 50;

                for (int i = 0; i < rows; i++)
                {

                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value = matrix[i, j];
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
                dataGridViewOpenFile_SIA.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьToolStripMenuItemFile_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_SIA.FileName = ".csv";
                saveFileDialog_SIA.InitialDirectory = @":C";
                if (saveFileDialog_SIA.ShowDialog() == DialogResult.OK)
                {
                    string savepath = saveFileDialog_SIA.FileName;

                    if (File.Exists(savepath)) File.Delete(savepath);

                    int rows = dataGridViewOpenFile_SIA.RowCount;
                    int columns = dataGridViewOpenFile_SIA.ColumnCount;

                    StringBuilder strBuilder = new StringBuilder();

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);

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

        static string[,] mtrxSearch;

        private void textBoxSearch_SIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                mtrxSearch = new string[dataGridViewOpenFile_SIA.RowCount, dataGridViewOpenFile_SIA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        mtrxSearch[i, j] = Convert.ToString(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAdd_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewOpenFile_SIA.Rows.Add();
            }
            catch
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                int konechno = 0;
                var result = MessageBox.Show($"{"Удалить данную строку?" + "\r"}{"Ее невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) konechno = 1;
                if (konechno == 1)
                {
                    int a = dataGridViewOpenFile_SIA.CurrentCell.RowIndex;
                    dataGridViewOpenFile_SIA.Rows.Remove(dataGridViewOpenFile_SIA.Rows[a]);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxSearch_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                {
                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value != null)
                        {
                            string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value.ToString().ToLower();
                            if (elmnt.Contains(textBoxSearch_SIA.Text.ToLower())) dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = true;
                        }
                    }
                }

                int clear = 0;
                for (int r = 1; r < dataGridViewOpenFile_SIA.RowCount - 1; r++)
                {
                    for (int c = 0; c < dataGridViewOpenFile_SIA.ColumnCount - 1; c++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[r].Cells[c].Selected == true) clear += 1;
                    }
                    if (clear == 0) dataGridViewOpenFile_SIA.Rows[r].Visible = false;
                    else
                    {
                        dataGridViewOpenFile_SIA.Rows[r].Visible = true;
                        clear = 0;
                    }
                }
            }
        }

        private void textBoxSearch_SIA_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                {
                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value = mtrxSearch[i, j];
                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                }
            }
        }








        private void textBoxFilter_SIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                mtrxSearch = new string[dataGridViewOpenFile_SIA.RowCount, dataGridViewOpenFile_SIA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        mtrxSearch[i, j] = Convert.ToString(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxFilter_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                {
                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value != null)
                        {
                            string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value.ToString().ToLower();
                            if (elmnt.Contains(comboBoxFilter_SIA.Text.ToLower())) dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = true;
                        }
                    }
                }

                int clear = 0;
                for (int r = 1; r < dataGridViewOpenFile_SIA.RowCount - 1; r++)
                {
                    for (int c = 0; c < dataGridViewOpenFile_SIA.ColumnCount - 1; c++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[r].Cells[c].Selected == true) clear += 1;
                    }
                    if (clear == 0) dataGridViewOpenFile_SIA.Rows[r].Visible = false;
                    else
                    {
                        dataGridViewOpenFile_SIA.Rows[r].Visible = true;
                        clear = 0;
                    }
                }
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
            }
        }

        private void comboBoxSort_SIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort_SIA.SelectedItem != null)
            {
                int columnIndex = 0;
                int stolbets = 0;
                for (int i = 0; i < dataGridViewOpenFile_SIA.ColumnCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                columnIndex = j;
                                stolbets = j;
                                break;
                            }
                        }
                        if (columnIndex > 0) break;
                    }
                    bool Num = true;

                    foreach (DataGridViewRow row in dataGridViewOpenFile_SIA.Rows)
                    {
                        int cellValue;
                        if (row.Cells[columnIndex].Value != null && int.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                        {
                            row.Cells[columnIndex].Value = cellValue;
                        }
                        else
                        {
                            row.Cells[columnIndex].Value = 0;
                            Num = false;
                        }
                    }
                    if (Num)
                    {
                        DataGridViewColumn column = dataGridViewOpenFile_SIA.Columns[stolbets];
                        string selectedItem = comboBoxSort_SIA.SelectedItem.ToString();

                        if (selectedItem == "По возрастанию") dataGridViewOpenFile_SIA.Sort(column, ListSortDirection.Ascending);
                        if (selectedItem == "По убыванию") dataGridViewOpenFile_SIA.Sort(column, ListSortDirection.Descending);
                    }

                }
            }
        }



        private void textBoxQuantity_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value != null)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                                {
                                    nugno = j;
                                    break;
                                }
                            }
                            if (nugno > -1) break;
                        }
                    }

                    int counter = 0;
                    for (int r = 0; r < dataGridViewOpenFile_SIA.RowCount - 1; r++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Selected == true) counter++;
                    }
                    textBoxQuantity_SIA.Text = Convert.ToString(counter);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void textBoxSum_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                        }
                        if (nugno > -1) break;
                    }

                    if (nugno > -1)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[0].Cells[nugno].Selected != true)
                        {
                            double sum = 0;
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true)
                                {
                                    string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString();
                                    if (elmnt.Contains(","))
                                    {
                                        elmnt.Replace(",", ".");
                                        sum += Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString());
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                        {
                                            sum += Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString());
                                        }
                                    }
                                }
                            }
                            if (sum != 0) textBoxSum_SIA.Text = Convert.ToString(sum);
                            else
                            {
                                MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxSum_SIA.Text = "";

                                textBoxMiddleValue_SIA.Text = "";
                                textBoxMinValue_SIA.Text = "";
                                textBoxMaxValue_SIA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxSum_SIA.Text = "";

                            textBoxMiddleValue_SIA.Text = "";
                            textBoxMinValue_SIA.Text = "";
                            textBoxMaxValue_SIA.Text = "";
                        }
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxMiddleValue_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                        }
                        if (nugno > -1) break;
                    }

                    if (nugno > -1)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[0].Cells[nugno].Selected != true)
                        {
                            double srznach = 0; int kol = 0;
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true)
                                {
                                    string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString();
                                    if (elmnt.Contains(","))
                                    {
                                        elmnt.Replace(",", ".");
                                        srznach += Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString());
                                        kol++;
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                        {
                                            srznach += Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString());
                                            kol++;
                                        }
                                    }
                                }
                            }
                            if (srznach != 0) textBoxMiddleValue_SIA.Text = Convert.ToString(srznach / kol);
                            else
                            {
                                MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMiddleValue_SIA.Text = "";

                                textBoxSum_SIA.Text = "";
                                textBoxMinValue_SIA.Text = "";
                                textBoxMaxValue_SIA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMiddleValue_SIA.Text = "";

                            textBoxSum_SIA.Text = "";
                            textBoxMinValue_SIA.Text = "";
                            textBoxMaxValue_SIA.Text = "";
                        }
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxMinValue_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                        }
                        if (nugno > -1) break;
                    }

                    if (nugno > -1)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[0].Cells[nugno].Selected != true)
                        {
                            double min = 9999999;
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true)
                                {
                                    string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString();
                                    if (elmnt.Contains(","))
                                    {
                                        elmnt.Replace(",", ".");
                                        min = Math.Min(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), min);
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                        {
                                            min = Math.Min(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), min);
                                        }
                                    }
                                }
                            }
                            if (min != 9999999) textBoxMinValue_SIA.Text = Convert.ToString(min);
                            else
                            {
                                MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMinValue_SIA.Text = "";

                                textBoxSum_SIA.Text = "";
                                textBoxMiddleValue_SIA.Text = "";
                                textBoxMaxValue_SIA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMinValue_SIA.Text = "";

                            textBoxSum_SIA.Text = "";
                            textBoxMiddleValue_SIA.Text = "";
                            textBoxMaxValue_SIA.Text = "";
                        }
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxMaxValue_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                        }
                        if (nugno > -1) break;
                    }

                    if (nugno > -1)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[0].Cells[nugno].Selected != true)
                        {
                            double max = -9999999;
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true)
                                {
                                    string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString();
                                    if (elmnt.Contains(","))
                                    {
                                        elmnt.Replace(",", ".");
                                        max = Math.Max(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), max);
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                        {
                                            max = Math.Max(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), max);
                                        }
                                    }
                                }
                            }
                            if (max != -9999999) textBoxMaxValue_SIA.Text = Convert.ToString(max);
                            else
                            {
                                MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMaxValue_SIA.Text = "";

                                textBoxSum_SIA.Text = "";
                                textBoxMiddleValue_SIA.Text = "";
                                textBoxMinValue_SIA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMaxValue_SIA.Text = "";

                            textBoxSum_SIA.Text = "";
                            textBoxMiddleValue_SIA.Text = "";
                            textBoxMinValue_SIA.Text = "";
                        }
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



    }
}

        
    




   


