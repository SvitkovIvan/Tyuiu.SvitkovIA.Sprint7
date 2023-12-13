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
        public FormMain_SIA()
        {
            InitializeComponent();
            videoLibrary = new VideoLibrary(("videoClips.csv"));

        }

        private void FormMain_SIA_Load(object sender, EventArgs e)
        {
            LoadVideoClipsFromCSV(); 
            PopulateDataGridView(); 
        }
    }
}

