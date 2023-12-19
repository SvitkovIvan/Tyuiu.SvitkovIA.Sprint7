using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9
{
    public partial class FormGuied_SIA : Form
    {
        public FormGuied_SIA()
        {
            InitializeComponent();
        }

        private void FormGuied_SIA_Load(object sender, EventArgs e)
        {
            this.Hide();
            FormMain_SIA formMain = new FormMain_SIA();
            formMain.Show();
        }

        private void toolStripMenuItemBack_SIA_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMain_SIA formMain = new FormMain_SIA();
            formMain.Show();
        }

        private void toolStripMenuItemHelp_SIA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
    }
}
