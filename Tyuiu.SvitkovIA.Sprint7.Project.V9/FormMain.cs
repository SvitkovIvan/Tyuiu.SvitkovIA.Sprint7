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

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    public partial class FormMain_SIA : Form
    {
        public FormMain_SIA()
        {
             InitializeComponent();
        }

        private void FormMain_SIA_Load(object sender, EventArgs e)
        {
            LoadVideoClipsFromCSV(); // Загрузить видеоклипы из CSV-файла
            PopulateDataGridView(); // Отобразить видеоклипы в DataGridView
        }
    }
    }

