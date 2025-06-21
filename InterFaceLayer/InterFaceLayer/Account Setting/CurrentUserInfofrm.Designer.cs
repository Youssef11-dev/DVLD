namespace InterFaceLayer.Account_Setting
{
    partial class CurrentUserInfofrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlShowUserInfo1 = new InterFaceLayer.Controls.CtrlShowUserInfo();
            this.SuspendLayout();
            // 
            // ctrlShowUserInfo1
            // 
            this.ctrlShowUserInfo1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ctrlShowUserInfo1.Location = new System.Drawing.Point(-4, -3);
            this.ctrlShowUserInfo1.Name = "ctrlShowUserInfo1";
            this.ctrlShowUserInfo1.Size = new System.Drawing.Size(700, 441);
            this.ctrlShowUserInfo1.TabIndex = 0;
            // 
            // CurrentUserInfofrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(693, 428);
            this.Controls.Add(this.ctrlShowUserInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CurrentUserInfofrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrentUserInfofrm";
            this.Load += new System.EventHandler(this.CurrentUserInfofrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlShowUserInfo ctrlShowUserInfo1;
    }
}