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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            pictureBoxInformation_SIA.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonOK_SIA_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
