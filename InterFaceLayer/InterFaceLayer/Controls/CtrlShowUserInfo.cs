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

namespace InterFaceLayer.Controls
{
    public partial class CtrlShowUserInfo : UserControl
    {
        private clsUser _User;
        public CtrlShowUserInfo()
        {
            InitializeComponent();
            
        }
        

       
        public void CtrlLoad(clsUser User)
        {
            _User = User;
            ctrlShowPersonInfo1.CtrlLoad(_User.PersonInfo);
            FillData();

            

        }
        private void FillData()
        {
            UserIdlbl.Text = _User.UserId.ToString();
            UserNamelbl.Text = _User.UserName.ToString();
            if (_User.IsActive)
            {
                IsActivelbl.Text = "Yes";
            }
            else
            {
                IsActivelbl.Text = "No";
            }
        }
        
    }
}
