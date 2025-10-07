using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MTAProject.Form2;

namespace MTAProject
{
    public partial class Form2 : Form
    {
        internal enum Modes
        {
            ADD,
            MODIFY,
            FINALGRADE
        }
        internal static Form2 current;

        private Modes mode = Modes.ADD;

        private string[] assignInitial;

        public Form2()
        {
            current = this;
            InitializeComponent();
        }

        internal void Start(Modes m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;

            comboBoxStudentID.DisplayMember = "StId";
            comboBoxStudentID.ValueMember = "StId";
            comboBoxStudentID.DataSource = Data.Students.GetStudents();
            comboBoxStudentID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudentID.SelectedIndex = 0;

            comboBoxCourseID.DisplayMember = "CId";
            comboBoxCourseID.ValueMember = "CId";
            comboBoxCourseID.DataSource = Data.Courses.GetCourses();
            comboBoxStudentID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCourseID.SelectedIndex = 0;

            textBoxStudentName.ReadOnly = true;
            textBoxCourseName.ReadOnly = true;
            textBoxGrade.Enabled = false;

            if (((mode == Modes.MODIFY) || (mode == Modes.FINALGRADE)) && (c != null))
            {
                comboBoxStudentID.SelectedValue = c[0].Cells["StId"].Value;
                comboBoxCourseID.SelectedValue = c[0].Cells["CId"].Value;
                textBoxGrade.Text = "" + c[0].Cells["FinalGrade"].Value;
                assignInitial = new string[] { (string)c[0].Cells["StId"].Value, (string)c[0].Cells["CId"].Value };
            }
            if (mode == Modes.MODIFY)
            {
                textBoxGrade.Enabled = false;
                comboBoxStudentID.Enabled = true;
                comboBoxCourseID.Enabled = true;
            }
            if (mode == Modes.FINALGRADE)
            {
                textBoxGrade.Enabled = true;
                textBoxGrade.ReadOnly = false;
                comboBoxStudentID.Enabled = false;
                comboBoxCourseID.Enabled = false;

            }
            ShowDialog();
        }

        private void comboBoxStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudentID.SelectedItem != null)
            {
                var a = from r in Data.Students.GetStudents().AsEnumerable()
                        where r.Field<string>("StId") == (string)comboBoxStudentID.SelectedValue
                        select new { Name = r.Field<string>("StName") };
                textBoxStudentName.Text = a.Single().Name;
            }
        }

        private void comboBoxCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourseID.SelectedItem != null)
            {
                var a = from r in Data.Courses.GetCourses().AsEnumerable()
                        where r.Field<string>("CId") == (string)comboBoxCourseID.SelectedValue
                        select new { Name = r.Field<string>("CName") };
                textBoxCourseName.Text = a.Single().Name;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int r = -1;
            if(mode == Modes.ADD)
            {

                r = Data.Enrollments.InsertData(new string[] { (string)comboBoxStudentID.SelectedValue, (string)comboBoxCourseID.SelectedValue });
            }
            if (mode == Modes.MODIFY)
            {
                List<string[]> lId = new List<string[]>();
                lId.Add(assignInitial);

                r = Data.Enrollments.InsertData(new string[] { (string)comboBoxStudentID.SelectedValue, (string)comboBoxCourseID.SelectedValue });

                if(r == 0)
                {
                    r = Data.Enrollments.DeleteData(lId);
                }
            }
            if (mode == Modes.FINALGRADE)
            {
                r = BusinessLayer.Enrollments.UpdateFinalGrade(assignInitial, textBoxGrade.Text);
            }

            if (r == 0)
            {
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Text = "Final Grade";
        }
    }
}
