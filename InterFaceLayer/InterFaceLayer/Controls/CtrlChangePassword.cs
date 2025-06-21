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
    public partial class CtrlChangePassword : UserControl
    {
        public string CurrentPassword
        {
            get => CurrentPasswordtxt.Text;
            set => CurrentPasswordtxt.Text = value;
        }
        public string NewPassword
        {
            get => NewPasswordtxt.Text;
            set => NewPasswordtxt.Text = value;
        }
        public string ConfirmPassword
        {
            get => ConfirmPasswordtxt.Text;
            set => ConfirmPasswordtxt.Text = value;
        }
        public CtrlChangePassword()
        {
            InitializeComponent();  
            
        }
    }
}
