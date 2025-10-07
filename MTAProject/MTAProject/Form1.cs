using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTAProject
{
    public partial class Form1 : Form
    {
        internal enum Grids
        {
            Program,
            Course,
            Student,
            Enrollment
        }



        internal static Form1 current;
        
        private Grids grid;

        private bool OKToChange = true;


        public Form1()
        {
            current = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2();
            Form2.current.Visible = false;

            Text = "Students & Courses";
            dataGridView1.Dock = DockStyle.Fill;


        }

        private void programsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OKToChange)
            {
                grid = Grids.Program;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ProgramsBindingSource.DataSource = Data.Programs.GetPrograms();
                ProgramsBindingSource.Sort = "ProgId";
                dataGridView1.DataSource = ProgramsBindingSource;

                dataGridView1.Columns["ProgName"].HeaderText = "Program Name";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";
                dataGridView1.Columns["ProgId"].DisplayIndex = 0;
                dataGridView1.Columns["ProgName"].DisplayIndex = 1;
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OKToChange)
            {
                grid = Grids.Course;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                CoursesBindingSource.DataSource = Data.Courses.GetCourses();
                CoursesBindingSource.Sort = "CId";
                dataGridView1.DataSource = CoursesBindingSource;

                dataGridView1.Columns["CName"].HeaderText = "Course Name";
                dataGridView1.Columns["CId"].HeaderText = "Course ID";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";
                dataGridView1.Columns["CId"].DisplayIndex = 0;
                dataGridView1.Columns["CName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.Student;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                StudentsBindingSource.DataSource = Data.Students.GetStudents();
                StudentsBindingSource.Sort = "StId";
                dataGridView1.DataSource = StudentsBindingSource;

                dataGridView1.Columns["StName"].HeaderText = "Student Name";
                dataGridView1.Columns["StId"].HeaderText = "Student ID";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";
                dataGridView1.Columns["StId"].DisplayIndex = 0;
                dataGridView1.Columns["StName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange && (grid != Grids.Enrollment))
            {
                grid = Grids.Enrollment;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                EnrollmentsBindingSource.DataSource = Data.Enrollments.GetDisplayEnrollments();
                EnrollmentsBindingSource.Sort = "StId, CId";
                dataGridView1.DataSource = EnrollmentsBindingSource;

                dataGridView1.Columns["StName"].HeaderText = "Student Name";
                dataGridView1.Columns["StId"].HeaderText = "Student ID";
                dataGridView1.Columns["CName"].HeaderText = "Course Name";
                dataGridView1.Columns["CId"].HeaderText = "Course ID";
                dataGridView1.Columns["FinalGrade"].HeaderText = "Final Grade";
                dataGridView1.Columns["StId"].DisplayIndex = 0;
                dataGridView1.Columns["StName"].DisplayIndex = 1;
                dataGridView1.Columns["CId"].DisplayIndex = 2;
                dataGridView1.Columns["CName"].DisplayIndex = 3;
                dataGridView1.Columns["FinalGrade"].DisplayIndex = 4;
            }
        }

        private void ProgramsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if(BusinessLayer.Programs.UpdatePrograms() == -1)
            {


                ProgramsBindingSource.ResetBindings(false);
            }
        }

        private void CoursesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (BusinessLayer.Courses.UpdateCourses() == -1)
            {

                CoursesBindingSource.ResetBindings(false);
            }
        }

        private void StudentsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (BusinessLayer.Students.UpdateStudents() == -1)
            {

                StudentsBindingSource.ResetBindings(false);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            OKToChange = true;
            Validate();
            if(grid == Grids.Program)
            {
                if(BusinessLayer.Programs.UpdatePrograms() == -1)
                {
                    OKToChange = false;
                }
            }
            else if(grid == Grids.Course)
            {
                if(BusinessLayer.Courses.UpdateCourses() == -1)
                {
                    OKToChange = false;
                }
            }
            else if(grid == Grids.Student)
            {
                if(BusinessLayer.Students.UpdateStudents() == -1)
                {
                    OKToChange = false;
                }
            }
        }

        internal static void BLLMessage(string s)
        {
            MessageBox.Show("Business Layer: " + s);
        }

        internal static void DALMessage(string s)
        {
            MessageBox.Show("Data Layer: " + s);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.current.Start(Form2.Modes.ADD, null);
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if(c.Count == 0)
            {
                MessageBox.Show("Please select a line to update.");
            }
            else if(c.Count > 1)
            {
                MessageBox.Show("You can only update one line at a time.");
            }
            else
            {
                if("" + c[0].Cells["FinalGrade"].Value == "")
                {
                    Form2.current.Start(Form2.Modes.MODIFY, c);
                }
                else
                {
                    MessageBox.Show("To update this line, Final Grade value must be removed first.");
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;

            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion.");
            }
            else
            {
                List<string[]> lId = new List<string[]>();
                for(int i = 0; i < c.Count; i++)
                {

                    lId.Add(new string[] { "" + c[i].Cells["StId"].Value, "" + c[i].Cells["CId"].Value });
                    Data.Enrollments.DeleteData(lId);
                    
                }
            }
        }

        
        
        
        private void manageFinalGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for evaluation update");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for update");
            }
            else
            {
                Form2.current.Start(Form2.Modes.FINALGRADE, c);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert / update");
            e.Cancel = false;
            OKToChange = false;
        }
    }
}
