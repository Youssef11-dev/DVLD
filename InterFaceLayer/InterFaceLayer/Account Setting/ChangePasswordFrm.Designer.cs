namespace InterFaceLayer.Account_Setting
{
    partial class ChangePasswordFrm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlChangePassword1 = new InterFaceLayer.Controls.CtrlChangePassword();
            this.ctrlShowUserInfo1 = new InterFaceLayer.Controls.CtrlShowUserInfo();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(520, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 33);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(520, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlChangePassword1
            // 
            this.ctrlChangePassword1.ConfirmPassword = "";
            this.ctrlChangePassword1.CurrentPassword = "";
            this.ctrlChangePassword1.Location = new System.Drawing.Point(12, 417);
            this.ctrlChangePassword1.Name = "ctrlChangePassword1";
            this.ctrlChangePassword1.NewPassword = "";
            this.ctrlChangePassword1.Size = new System.Drawing.Size(432, 172);
            this.ctrlChangePassword1.TabIndex = 1;
            // 
            // ctrlShowUserInfo1
            // 
            this.ctrlShowUserInfo1.Location = new System.Drawing.Point(-10, -1);
            this.ctrlShowUserInfo1.Name = "ctrlShowUserInfo1";
            this.ctrlShowUserInfo1.Size = new System.Drawing.Size(700, 441);
            this.ctrlShowUserInfo1.TabIndex = 0;
            this.ctrlShowUserInfo1.Load += new System.EventHandler(this.ctrlShowUserInfo1_Load);
            // 
            // ChangePasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 626);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlChangePassword1);
            this.Controls.Add(this.ctrlShowUserInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChangePasswordFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CtrlShowUserInfo ctrlShowUserInfo1;
        private Controls.CtrlChangePassword ctrlChangePassword1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}