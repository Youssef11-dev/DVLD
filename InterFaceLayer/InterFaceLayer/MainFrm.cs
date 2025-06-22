using InterFaceLayer.Account_Setting;
using InterFaceLayer.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterFaceLayer
{
    public partial class MainFrm : Form
    {
        private bool _SignOut = false;
        public bool IsSignedOut => _SignOut;
        public MainFrm()
        {
            InitializeComponent();
            
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUserInfofrm currentUserInfofrm = new CurrentUserInfofrm();
            currentUserInfofrm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm changePasswordFrm = new ChangePasswordFrm();
            changePasswordFrm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SignOut = true;
            this.Close();
           
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleFrm peopleFrm = new PeopleFrm();
            peopleFrm.ShowDialog();
        }
    }
}
