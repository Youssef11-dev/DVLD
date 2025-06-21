using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using InterFaceLayer.Utilities;

namespace InterFaceLayer.Login
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

       

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindUserByUserNameAndPassword(UserNamelbl.Text.Trim(), Passwordlbl.Text.Trim());
            if (User != null) {
                if (!User.IsActive)
                {
                    MessageBox.Show("User Is Not Active");
                    UserNamelbl.Focus();  
                }
                else
                {
                    bool SignOut = false;
                    clsGlobal.CurrentUser = User;
                    MainFrm mainFrm = new MainFrm();
                    this.Hide();
                    mainFrm.ShowDialog();
                    if (mainFrm.IsSignedOut)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                    
                }


            }
            else
            {
                MessageBox.Show("Error User Name And Password");
            }

        }
        
    }
}
