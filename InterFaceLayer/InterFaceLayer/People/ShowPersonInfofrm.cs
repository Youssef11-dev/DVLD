using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace InterFaceLayer.People
{
    public partial class ShowPersonInfofrm : Form
    {
        int _PersonId;
        public ShowPersonInfofrm(int PersonId)
        {
            
            InitializeComponent();
            _PersonId = PersonId;
        }
        private void LoadForm()
        {
            if (!ctrlShowPersonInfo1.CtrlLoad(clsPerson.FindPersonById(_PersonId)))
            {
                this.Close();
            }
        }

        private void ShowPersonInfofrm_Load(object sender, EventArgs e)
        {
                  LoadForm();  
        }
    }
}
