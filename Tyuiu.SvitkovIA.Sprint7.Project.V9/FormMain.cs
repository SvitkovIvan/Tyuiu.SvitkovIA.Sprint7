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
        private VideoLibrary videoLibrary;
        private BindingList<DataService> videoClipsBindingList;

        public FormMain_SIA()
        {
            InitializeComponent();
            videoClipsBindingList = new BindingList<DataService>();
            videoLibrary = new VideoLibrary("videoClips.csv");
        }

        private void FormMain_SIA_Load(object sender, EventArgs e)
        {
            LoadVideoClipsFromCSV();
            PopulateDataGridView();
        }

        private void LoadVideoClipsFromCSV()
        {
            List<DataService> videoClips = videoLibrary.LoadVideoClipsFromCSV();

            foreach (DataService videoClip in videoClips)
            {
                videoClipsBindingList.Add(videoClip);
            }
        }

        private void PopulateDataGridView()
        {
            DataGridViewColumn columnId = new DataGridViewTextBoxColumn();
            columnId.DataPropertyName = " Id ";
            columnId.HeaderText = " ID ";

            DataGridViewColumn columnTitle = new DataGridViewTextBoxColumn();
            columnTitle.DataPropertyName = " Заголовок ";
            columnTitle.HeaderText = " Заголовок ";

            DataGridViewColumn columnDuration = new DataGridViewTextBoxColumn();
            columnDuration.DataPropertyName = " Продолжительность ";
            columnDuration.HeaderText = " Продолжительность ";

        }
    }
}
        




