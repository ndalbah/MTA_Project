namespace MTAProject
{
    partial class Form2
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
            this.labelStudentID = new System.Windows.Forms.Label();
            this.labelCourseID = new System.Windows.Forms.Label();
            this.labelGrade = new System.Windows.Forms.Label();
            this.labelStudentName = new System.Windows.Forms.Label();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.comboBoxStudentID = new System.Windows.Forms.ComboBox();
            this.comboBoxCourseID = new System.Windows.Forms.ComboBox();
            this.textBoxGrade = new System.Windows.Forms.TextBox();
            this.textBoxStudentName = new System.Windows.Forms.TextBox();
            this.textBoxCourseName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStudentID
            // 
            this.labelStudentID.AutoSize = true;
            this.labelStudentID.Location = new System.Drawing.Point(89, 63);
            this.labelStudentID.Name = "labelStudentID";
            this.labelStudentID.Size = new System.Drawing.Size(118, 25);
            this.labelStudentID.TabIndex = 0;
            this.labelStudentID.Text = "Student ID:";
            // 
            // labelCourseID
            // 
            this.labelCourseID.AutoSize = true;
            this.labelCourseID.Location = new System.Drawing.Point(637, 63);
            this.labelCourseID.Name = "labelCourseID";
            this.labelCourseID.Size = new System.Drawing.Size(113, 25);
            this.labelCourseID.TabIndex = 1;
            this.labelCourseID.Text = "Course ID:";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Location = new System.Drawing.Point(1211, 63);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(77, 25);
            this.labelGrade.TabIndex = 2;
            this.labelGrade.Text = "Grade:";
            // 
            // labelStudentName
            // 
            this.labelStudentName.AutoSize = true;
            this.labelStudentName.Location = new System.Drawing.Point(328, 63);
            this.labelStudentName.Name = "labelStudentName";
            this.labelStudentName.Size = new System.Drawing.Size(148, 25);
            this.labelStudentName.TabIndex = 3;
            this.labelStudentName.Text = "Student Name";
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Location = new System.Drawing.Point(895, 63);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(143, 25);
            this.labelCourseName.TabIndex = 4;
            this.labelCourseName.Text = "Course Name";
            // 
            // comboBoxStudentID
            // 
            this.comboBoxStudentID.FormattingEnabled = true;
            this.comboBoxStudentID.Location = new System.Drawing.Point(46, 107);
            this.comboBoxStudentID.Name = "comboBoxStudentID";
            this.comboBoxStudentID.Size = new System.Drawing.Size(198, 33);
            this.comboBoxStudentID.TabIndex = 5;
            this.comboBoxStudentID.SelectedIndexChanged += new System.EventHandler(this.comboBoxStudentID_SelectedIndexChanged);
            // 
            // comboBoxCourseID
            // 
            this.comboBoxCourseID.FormattingEnabled = true;
            this.comboBoxCourseID.Location = new System.Drawing.Point(593, 105);
            this.comboBoxCourseID.Name = "comboBoxCourseID";
            this.comboBoxCourseID.Size = new System.Drawing.Size(198, 33);
            this.comboBoxCourseID.TabIndex = 6;
            this.comboBoxCourseID.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourseID_SelectedIndexChanged);
            // 
            // textBoxGrade
            // 
            this.textBoxGrade.Location = new System.Drawing.Point(1152, 107);
            this.textBoxGrade.Name = "textBoxGrade";
            this.textBoxGrade.Size = new System.Drawing.Size(198, 31);
            this.textBoxGrade.TabIndex = 7;
            // 
            // textBoxStudentName
            // 
            this.textBoxStudentName.Location = new System.Drawing.Point(265, 105);
            this.textBoxStudentName.Name = "textBoxStudentName";
            this.textBoxStudentName.Size = new System.Drawing.Size(300, 31);
            this.textBoxStudentName.TabIndex = 8;
            // 
            // textBoxCourseName
            // 
            this.textBoxCourseName.Location = new System.Drawing.Point(818, 107);
            this.textBoxCourseName.Name = "textBoxCourseName";
            this.textBoxCourseName.Size = new System.Drawing.Size(300, 31);
            this.textBoxCourseName.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(1070, 215);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(125, 54);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1242, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(125, 54);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 317);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCourseName);
            this.Controls.Add(this.textBoxStudentName);
            this.Controls.Add(this.textBoxGrade);
            this.Controls.Add(this.comboBoxCourseID);
            this.Controls.Add(this.comboBoxStudentID);
            this.Controls.Add(this.labelCourseName);
            this.Controls.Add(this.labelStudentName);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.labelCourseID);
            this.Controls.Add(this.labelStudentID);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStudentID;
        private System.Windows.Forms.Label labelCourseID;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelStudentName;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.ComboBox comboBoxStudentID;
        private System.Windows.Forms.ComboBox comboBoxCourseID;
        private System.Windows.Forms.TextBox textBoxGrade;
        private System.Windows.Forms.TextBox textBoxStudentName;
        private System.Windows.Forms.TextBox textBoxCourseName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}