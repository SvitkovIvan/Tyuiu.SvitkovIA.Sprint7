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
                for (int i = 0; i < mtrxSearch.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < mtrxSearch.GetUpperBound(1); j++)
                    {
                        mtrxSearch[i, j] = Convert.ToString(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }

                textBoxQuantity_SIA.Text = "";
                textBoxSum_SIA.Text = "";
                textBoxMiddleValue_SIA.Text = "";
                textBoxMinValue_SIA.Text = "";
                textBoxMaxValue_SIA.Text = "";
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAdd_SIA_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewOpenFile_SIA.Rows.Add();
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }
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
                    if (dataGridViewOpenFile_SIA.Rows[0].Cells[nugno].Selected == true) MessageBox.Show("Первую строку нельзя удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var result = MessageBox.Show($"{"Удалить данную строку?" + "\r"}{"Ее невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int k = -1; int udal = 0;
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true)
                                {
                                    k = i;
                                    break;
                                }
                                if (k > -1) break;
                            }
                            for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected == true) udal++;
                            }
                            for (int r = 0; r < udal; r++) dataGridViewOpenFile_SIA.Rows.Remove(dataGridViewOpenFile_SIA.Rows[k]);
                            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                                {
                                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                                }
                            }
                        }
                    }
                }
                else MessageBox.Show("Выберите строку, которую ходите удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxSearch_SIA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < mtrxSearch.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < mtrxSearch.GetUpperBound(1); j++)
                    {
                        if (mtrxSearch[i, j] != null)
                        {
                            string elmnt = mtrxSearch[i, j].ToLower();
                            if (elmnt.Contains(textBoxSearch_SIA.Text.ToLower())) dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = true;
                        }
                    }
                }
            }
        }

        static string[,] mtrxSort;
        static int tralivali = 0;
        

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


        static string[,] mtrxFilter;
        static int bulo = 0;
        private void textBoxFilter_SIA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                mtrxFilter = new string[dataGridViewOpenFile_SIA.RowCount, dataGridViewOpenFile_SIA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        mtrxFilter[i, j] = Convert.ToString(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);
                    }
                }
                bulo++;
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxFilter_SIA_KeyUp(object sender, KeyEventArgs e)
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
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }

                if (nugno > -1)
                {
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount; i++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value != null)
                        {
                            string elmnt = dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString().ToLower();
                            //if (elmnt.StartsWith(textBoxFilter_SIA.Text.ToLower())) dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Selected = true;
                        }
                    }

                    for (int r = 1; r < dataGridViewOpenFile_SIA.RowCount - 1; r++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Selected != true) dataGridViewOpenFile_SIA.Rows[r].Visible = false;
                    }

                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                        }
                    }

                    textBoxQuantity_SIA.Text = "";
                    textBoxSum_SIA.Text = "";
                    textBoxMiddleValue_SIA.Text = "";
                    textBoxMinValue_SIA.Text = "";
                    textBoxMaxValue_SIA.Text = "";
                }
                else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBoxSort_SIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort_SIA.SelectedItem != null && dataGridViewOpenFile_SIA.RowCount != 0)
            {
                int vozmogno = 0; int k = -1;
                for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount; j++)
                    {
                        if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value == null) vozmogno++;
                    }
                    textBoxMaxValue_SIA.Text = Convert.ToString(vozmogno);
                    if (vozmogno == dataGridViewOpenFile_SIA.ColumnCount)
                    {
                        k = i;
                        break;
                    }
                    else vozmogno = 0;
                }
                if (k > 0) MessageBox.Show("Пожалуйста, удалите все пустые строки, кроме последней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    int kakbuda = 0;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == false) kakbuda++;
                        }
                    }
                    if (kakbuda != (dataGridViewOpenFile_SIA.RowCount - 1) * (dataGridViewOpenFile_SIA.ColumnCount - 1))
                    {
                        int columnIndex = -1;
                        for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                            {
                                if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value != null)
                                {
                                    if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                                    {
                                        columnIndex = j;
                                        break;
                                    }
                                }
                            }
                            if (columnIndex > -1) break;
                        }

                        for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                        {
                            double cellValue;
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[columnIndex].Value != null && double.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[columnIndex].Value.ToString(), out cellValue))
                            {
                                dataGridViewOpenFile_SIA.Rows[i].Cells[columnIndex].Value = cellValue;
                            }
                        }

                        string selectedItem = comboBoxSort_SIA.SelectedItem.ToString();
                        if (selectedItem == "По возрастанию (от А до Я)" && tralivali != 0)
                        {
                            DataGridViewRow row = dataGridViewOpenFile_SIA.Rows[0];
                            dataGridViewOpenFile_SIA.Rows.Remove(dataGridViewOpenFile_SIA.Rows[0]);

                            DataGridViewColumn column = dataGridViewOpenFile_SIA.Columns[columnIndex];

                            dataGridViewOpenFile_SIA.Sort(column, ListSortDirection.Ascending);
                            dataGridViewOpenFile_SIA.Rows.Insert(0, row);

                            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                                {
                                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                                }
                            }
                        }
                        else if (selectedItem == "По убыванию (от Я до А)" && tralivali != 0)
                        {
                            DataGridViewRow row = dataGridViewOpenFile_SIA.Rows[0];
                            dataGridViewOpenFile_SIA.Rows.Remove(dataGridViewOpenFile_SIA.Rows[0]);

                            DataGridViewColumn column = dataGridViewOpenFile_SIA.Columns[columnIndex];

                            dataGridViewOpenFile_SIA.Sort(column, ListSortDirection.Descending);
                            dataGridViewOpenFile_SIA.Rows.Insert(0, row);

                            for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                                {
                                    dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                                }
                            }
                        }
                        else MessageBox.Show("Не забудьте нажать на пустое поле ввода сортирвоки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBoxQuantity_SIA.Text = "";
                        textBoxSum_SIA.Text = "";
                        textBoxMiddleValue_SIA.Text = "";
                        textBoxMinValue_SIA.Text = "";
                        textBoxMaxValue_SIA.Text = "";
                    }
                    else if (kakbuda == (dataGridViewOpenFile_SIA.RowCount - 1) * (dataGridViewOpenFile_SIA.ColumnCount - 1) && tralivali != 0)
                    {
                        MessageBox.Show("Пожалуйста, выберите столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (kakbuda == (dataGridViewOpenFile_SIA.RowCount - 1) * (dataGridViewOpenFile_SIA.ColumnCount - 1) && tralivali == 0)
                    {
                        MessageBox.Show($"{"Пожалуйста, выберите столбец." + "\r"}{"Не забудьте нажать на пустое поле ввода сортирвоки!"}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                            if (nugno > -1) break;
                        }
                    }

                    if (nugno > -1)
                    {
                        int sum = 0; 
                        for (int r = 0; r < dataGridViewOpenFile_SIA.RowCount; r++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Selected == true)
                            {
                                int value;
                                if (Int32.TryParse(dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Value.ToString(), out value))
                                {
                                    sum += value;
                                }
                            }
                        }
                        textBoxQuantity_SIA.Text = sum.ToString(); 
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                                    double cellValue;
                                    if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value != null && double.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                    {
                                        dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value = cellValue;
                                        min = Math.Min(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), min);
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
                                    double cellValue;
                                    if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value != null && double.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                    {
                                        dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value = cellValue;
                                        max = Math.Max(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), max);
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

        private void buttonFilter_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0 && bulo != 0)
            {
                dataGridViewOpenFile_SIA.Rows.Clear();
                dataGridViewOpenFile_SIA.Columns.Clear();
                dataGridViewOpenFile_SIA.RowCount = mtrxFilter.GetUpperBound(0) + 1;
                dataGridViewOpenFile_SIA.ColumnCount = mtrxFilter.GetUpperBound(1) + 1;
                textBoxMaxValue_SIA.Text = Convert.ToString(mtrxFilter.GetUpperBound(0) + 1);
                textBoxMinValue_SIA.Text = Convert.ToString(mtrxFilter.GetUpperBound(1) + 10);
                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value = mtrxFilter[i, j];
                    }
                }
                dataGridViewOpenFile_SIA.AutoResizeColumns();

                for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                    }
                }

                textBoxQuantity_SIA.Text = "";
                textBoxSum_SIA.Text = "";
                textBoxMiddleValue_SIA.Text = "";
                textBoxMinValue_SIA.Text = "";
                textBoxMaxValue_SIA.Text = "";
            }
            else if (dataGridViewOpenFile_SIA.RowCount != 0 && bulo == 0) MessageBox.Show("Еще не были применены фильтры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonSort_SIA_Click(object sender, EventArgs e)
        {
            {
                
                if (dataGridViewOpenFile_SIA.RowCount != 0 && tralivali != 0)
                {
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value = mtrxSort[i, j];
                            dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected = false;
                        }
                    }
                }
                else if (dataGridViewOpenFile_SIA.RowCount != 0 && tralivali == 0) MessageBox.Show("Нажмите на пустое поле ввода сортировки вверху", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
            

        }

        private void comboBoxSort_SIA_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (dataGridViewOpenFile_SIA.RowCount != 0)
                {
                    mtrxSort = new string[dataGridViewOpenFile_SIA.RowCount, dataGridViewOpenFile_SIA.ColumnCount];
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            mtrxSort[i, j] = Convert.ToString(dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value);
                        }
                    }
                    tralivali++;

                    int vozmogno = 0; int k = -1;
                    for (int i = 1; i < dataGridViewOpenFile_SIA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Value == null) vozmogno++;
                        }
                        if (vozmogno == dataGridViewOpenFile_SIA.ColumnCount)
                        {
                            k = i;
                            break;
                        }
                        else vozmogno = 0;
                    }
                    if (k > 0) MessageBox.Show("Пожалуйста, удалите все пустые строки, кроме последней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMaxValue_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                
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
                                    double cellValue;
                                    if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value != null && double.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                    {
                                        dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value = cellValue;
                                        max = Math.Max(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), max);
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

        private void buttonMinValue_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                
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
                                    double cellValue;
                                    if (dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value != null && double.TryParse(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString(), out cellValue))
                                    {
                                        dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value = cellValue;
                                        min = Math.Min(Convert.ToDouble(dataGridViewOpenFile_SIA.Rows[i].Cells[nugno].Value.ToString()), min);
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

        private void buttonMiddleValue_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                
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

        private void buttonSum_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                
                {
                    int nugno = -1;
                    for (int i = 0; i < dataGridViewOpenFile_SIA.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenFile_SIA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[i].Cells[j].Selected == true)
                            {
                                nugno = j;
                                break;
                            }
                            if (nugno > -1) break;
                        }
                    }

                    if (nugno > -1)
                    {
                        int sum = 0;
                        for (int r = 0; r < dataGridViewOpenFile_SIA.RowCount; r++)
                        {
                            if (dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Selected == true)
                            {
                                int value;
                                if (Int32.TryParse(dataGridViewOpenFile_SIA.Rows[r].Cells[nugno].Value.ToString(), out value))
                                {
                                    sum += value;
                                }
                            }
                        }
                        textBoxQuantity_SIA.Text = sum.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuantity_SIA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenFile_SIA.RowCount != 0)
            {
                
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
    }
}
           
    




   


