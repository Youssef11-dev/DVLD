namespace InterFaceLayer
{
    partial class AddUpdatefrm
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
            this.AddUpdatePerson = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PersonIdlbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ctrlEditPersonInfo1 = new InterFaceLayer.Controls.CtrlEditPersonInfo();
            this.SuspendLayout();
            // 
            // AddUpdatePerson
            // 
            this.AddUpdatePerson.AutoSize = true;
            this.AddUpdatePerson.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUpdatePerson.Location = new System.Drawing.Point(230, 30);
            this.AddUpdatePerson.Name = "AddUpdatePerson";
            this.AddUpdatePerson.Size = new System.Drawing.Size(204, 36);
            this.AddUpdatePerson.TabIndex = 1;
            this.AddUpdatePerson.Text = "Add New Person";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Person Id :";
            // 
            // PersonIdlbl
            // 
            this.PersonIdlbl.AutoSize = true;
            this.PersonIdlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonIdlbl.Location = new System.Drawing.Point(148, 92);
            this.PersonIdlbl.Name = "PersonIdlbl";
            this.PersonIdlbl.Size = new System.Drawing.Size(43, 20);
            this.PersonIdlbl.TabIndex = 3;
            this.PersonIdlbl.Text = "[N/A]";
            // 
            // button1
            // 
            this.button1.Image = global::InterFaceLayer.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(103, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::InterFaceLayer.Properties.Resources.Save_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(469, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 40);
            this.button2.TabIndex = 5;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ctrlEditPersonInfo1
            // 
            this.ctrlEditPersonInfo1.Location = new System.Drawing.Point(21, 116);
            this.ctrlEditPersonInfo1.Name = "ctrlEditPersonInfo1";
            this.ctrlEditPersonInfo1.Size = new System.Drawing.Size(680, 280);
            this.ctrlEditPersonInfo1.TabIndex = 0;
            // 
            // AddUpdatefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 465);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PersonIdlbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddUpdatePerson);
            this.Controls.Add(this.ctrlEditPersonInfo1);
            this.Name = "AddUpdatefrm";
            this.Text = "AddUpdatefrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CtrlEditPersonInfo ctrlEditPersonInfo1;
        private System.Windows.Forms.Label AddUpdatePerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PersonIdlbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}