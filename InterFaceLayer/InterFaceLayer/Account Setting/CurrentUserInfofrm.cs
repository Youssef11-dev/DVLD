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
    public partial class CurrentUserInfofrm : Form
    {
        public CurrentUserInfofrm()
        {
            InitializeComponent();
        }

        private void CurrentUserInfofrm_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.CtrlLoad(clsGlobal.CurrentUser);
        }
    }
}
