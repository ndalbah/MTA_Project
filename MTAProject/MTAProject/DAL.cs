using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    internal class Connect
    {
        private static String cliComConnectionString = GetConnectionString();

        internal static String ConnectionString
        {
            get => cliComConnectionString;
        }

        private static String GetConnectionString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;

        }
    }
    internal class DataTables
    {

        private static SqlDataAdapter adapterStudents = InitAdapterStudents();
        private static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();
        private static SqlDataAdapter adapterCourses = InitAdapterCourses();
        private static SqlDataAdapter adapterPrograms = InitAdapterPrograms();


        private static DataSet ds = InitDataSet();



        private static SqlDataAdapter InitAdapterPrograms()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Programs ORDER BY ProgId",
                    Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterCourses()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Courses ORDER BY CId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterStudents()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Students ORDER BY StId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;

        }

        private static SqlDataAdapter InitAdapterEnrollments()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * FROM Enrollments ORDER BY StId, CId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;

        }


        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            loadPrograms(ds);
            loadCourses(ds);
            loadStudents(ds);
            loadEnrollments(ds);
            return ds;
        }


        private static void loadPrograms(DataSet ds)
        {
            adapterPrograms.Fill(ds, "Programs");

            ds.Tables["Programs"].Columns["ProgId"].AllowDBNull = false;
            ds.Tables["Programs"].Columns["ProgName"].AllowDBNull = false;

            ds.Tables["Programs"].PrimaryKey = new DataColumn[1]
            {
                ds.Tables["Programs"].Columns["ProgId"]
            };
        }
        private static void loadCourses(DataSet ds)
        {
            adapterCourses.Fill(ds, "Courses");

            ds.Tables["Courses"].Columns["Cid"].AllowDBNull = false;
            ds.Tables["Courses"].Columns["CName"].AllowDBNull = false;

            ds.Tables["Programs"].PrimaryKey = new DataColumn[1]
            {
                ds.Tables["Programs"].Columns["ProgId"]
            };
            ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                new DataColumn[]
                {
                    ds.Tables["Programs"].Columns["ProgId"],
                },
                new DataColumn[]
                {
                    ds.Tables["Courses"].Columns["ProgId"],
                }
            );
            myFK01.DeleteRule = Rule.None;
            myFK01.UpdateRule = Rule.Cascade;
            ds.Tables["Courses"].Constraints.Add(myFK01);
        }

        private static void loadStudents(DataSet ds)
        {
            adapterStudents.Fill(ds, "Students");

            ds.Tables["Students"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Students"].Columns["StName"].AllowDBNull = false;

            ds.Tables["Students"].PrimaryKey = new DataColumn[1]
            {
                ds.Tables["Students"].Columns["StId"]
            };
            ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                new DataColumn[]
                {
                    ds.Tables["Programs"].Columns["ProgId"],
                },
                new DataColumn[]
                {
                    ds.Tables["Students"].Columns["ProgId"],
                }
            );
            myFK01.DeleteRule = Rule.None;
            myFK01.UpdateRule = Rule.Cascade;
            ds.Tables["Students"].Constraints.Add(myFK01);
        }

        private static void loadEnrollments(DataSet ds)
        {
            adapterEnrollments.Fill(ds, "Enrollments");

            ds.Tables["Enrollments"].Columns["StId"].AllowDBNull = false;
            ds.Tables["Enrollments"].Columns["CId"].AllowDBNull = false;

            ds.Tables["Enrollments"].PrimaryKey = new DataColumn[2]
            {
                ds.Tables["Enrollments"].Columns["StId"], ds.Tables["Enrollments"].Columns["CId"]
            };
            ForeignKeyConstraint myFK01 = new ForeignKeyConstraint("MyFK01",
                new DataColumn[]
                {
                    ds.Tables["Students"].Columns["StId"]
                },
                new DataColumn[]
                {
                    ds.Tables["Enrollments"].Columns["StId"]
                }
            );
            myFK01.DeleteRule = Rule.Cascade;
            myFK01.UpdateRule = Rule.Cascade;

            ds.Tables["Enrollments"].Constraints.Add(myFK01);
            ForeignKeyConstraint myFK02 = new ForeignKeyConstraint("MyFK02",
                new DataColumn[]
                {
                    ds.Tables["Courses"].Columns["CId"]
                },
                new DataColumn[]
                {
                    ds.Tables["Enrollments"].Columns["CId"]
                }
            );
            myFK02.DeleteRule = Rule.None;
            myFK02.DeleteRule = Rule.Cascade;
            ds.Tables["Enrollments"].Constraints.Add(myFK02);
        }

        internal static SqlDataAdapter getAdapterPrograms()
        {
            return adapterPrograms;
        }

        internal static SqlDataAdapter getAdapterCourses()
        {
            return adapterCourses;
        }

        internal static SqlDataAdapter getAdapterStudents()
        {
            return adapterStudents;
        }

        internal static SqlDataAdapter getAdapterEnrollments()
        {
            return adapterEnrollments;
        }

        internal static DataSet getDataSet()
        {
            return ds;
        }
    }


    internal class Programs
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterPrograms();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetPrograms()
        {
            return ds.Tables["Programs"];
        }

        internal static int UpdatePrograms()
        {
            if (!ds.Tables["Programs"].HasErrors)
            {
                return adapter.Update(ds.Tables["Programs"]);
            }
            else
            {
                return -1;
            }
        }
    }


    internal class Courses
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCourses();
        private static DataSet ds = DataTables.getDataSet();


        internal static DataTable GetCourses()
        {
            return ds.Tables["Courses"];
        }

        internal static int UpdateCourses()
        {
            if (!ds.Tables["Courses"].HasErrors)
            {
                return adapter.Update(ds.Tables["Courses"]);
            }
            else
            {
                return -1;
            }
        }
    }


    internal class Students
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterStudents();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetStudents()
        {
            return ds.Tables["Students"];
        }

        internal static int UpdateStudents()
        {
            if (!ds.Tables["Students"].HasErrors)
            {
                return adapter.Update(ds.Tables["Students"]);
            }
            else
            {
                return -1;
            }
        }
    }



    internal class Enrollments
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterEnrollments();
        private static DataSet ds = DataTables.getDataSet();

        private static DataTable displayEnrollment = null;


        internal static DataTable GetDisplayEnrollments()
        {
            ds.Tables["Enrollments"].AcceptChanges();

            var query = (
                from enroll in ds.Tables["Enrollments"].AsEnumerable()
                from student in ds.Tables["Students"].AsEnumerable()
                from course in ds.Tables["Courses"].AsEnumerable()
                where enroll.Field<string>("StId") == student.Field<string>("StId")
                where enroll.Field<string>("CId") == course.Field<string>("CId")
                select new
                {
                    StId = student.Field<string>("StId"),
                    StName = student.Field<string>("StName"),
                    CId = course.Field<string>("CId"),
                    CName = course.Field<string>("CName"),
                    FinalGrade = enroll.Field<Nullable<int>>("FinalGrade")
                });
            DataTable result = new DataTable();
            result.Columns.Add("StId");
            result.Columns.Add("StName");
            result.Columns.Add("CId");
            result.Columns.Add("CName");
            result.Columns.Add("FinalGrade");
            foreach (var x in query)
            {
                object[] allFields = { x.StId, x.StName, x.CId, x.CName, x.FinalGrade };
                result.Rows.Add(allFields);
            }
            displayEnrollment = result;
            return displayEnrollment;
        }
        internal static int InsertData(string[] a)
        {
            var test = (
                   from enroll in ds.Tables["Enrollments"].AsEnumerable()
                   where enroll.Field<string>("StId") == a[0]
                   where enroll.Field<string>("CId") == a[1]
                   select enroll);
            if (test.Count() > 0)
            {
                MTAProject.Form1.DALMessage("This enrollment already exists.");
                return -1;
            }
            try
            {
                DataRow line = ds.Tables["Enrollments"].NewRow();
                line.SetField("StId", a[0]);
                line.SetField("CId", a[1]);
                ds.Tables["Enrollments"].Rows.Add(line);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    var query = (
                           from emp in ds.Tables["Students"].AsEnumerable()
                           from proj in ds.Tables["Courses"].AsEnumerable()
                           where emp.Field<string>("StId") == a[0]
                           where proj.Field<string>("CId") == a[1]
                           select new
                           {
                               StId = emp.Field<string>("StId"),
                               StName = emp.Field<string>("StName"),
                               CId = proj.Field<string>("CId"),
                               CName = proj.Field<string>("CName"),
                               FinalGrade = line.Field<Nullable<int>>("FinalGrade")
                           });

                    var r = query.Single();
                    displayEnrollment.Rows.Add(new object[] { r.StId, r.StName, r.CId, r.CName, r.FinalGrade });
                }
                return 0;
            }
            catch (Exception)
            {
                MTAProject.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }
        internal static int UpdateData(string[] a)
        {
            return 0;
        }
        internal static int DeleteData(List<string[]> lId)
        {
            try
            {
                var lines = ds.Tables["Enrollments"].AsEnumerable()
                .Where(s => lId.Any(x => (x[0] == s.Field<string>("StId") && x[1] == s.Field<string>("CId"))));


                foreach (var line in lines)
                {
                    line.Delete();
                }

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    foreach (var p in lId)
                    {
                        var r = displayEnrollment.AsEnumerable()
                                .Where(s => (s.Field<string>("StId") == p[0] && s.Field<string>("CId") == p[1]))
                                .Single();
                        displayEnrollment.Rows.Remove(r);
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                MTAProject.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }
        internal static int UpdateFinalGrade(string[] a, Nullable<int> finalgrade)
        {
            try
            {
                var line = ds.Tables["Enrollments"].AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                                    .Single();

                line.SetField("FinalGrade", finalgrade);

                adapter.Update(ds.Tables["Enrollments"]);

                if (displayEnrollment != null)
                {
                    var r = displayEnrollment.AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("StId") == a[0] && s.Field<string>("CId") == a[1]))
                                    .Single();
                    r.SetField("FinalGrade", finalgrade);
                }
                return 0;
            }
            catch (Exception)
            {
                MTAProject.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }
    }
}
