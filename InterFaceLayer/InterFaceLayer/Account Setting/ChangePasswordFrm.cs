using BusinessLayer;
using InterFaceLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterFaceLayer.Account_Setting
{
    public partial class ChangePasswordFrm : Form
    {
        public ChangePasswordFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlChangePassword1.CurrentPassword == clsGlobal.CurrentUser.Password) {
                if (ctrlChangePassword1.NewPassword == ctrlChangePassword1.ConfirmPassword) {
                    clsGlobal.CurrentUser.Password = ctrlChangePassword1.NewPassword;
                    if (clsGlobal.CurrentUser.Save())
                    {
                        MessageBox.Show("Password Saved Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Password Didn't Saved");
                    }
                }
                else
                {
                    MessageBox.Show("Confirm Password Don't Match New Password");
                }

            }
            else
            {
                MessageBox.Show("Current Password Is Not Correct");
            }
        }

        private void ctrlShowUserInfo1_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.CtrlLoad(clsGlobal.CurrentUser);
        }
    }
}
