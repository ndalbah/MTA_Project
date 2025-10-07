﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{

    class Programs
    {
        internal static int UpdatePrograms()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["Programs"].GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dt != null)
            {
                if (dt.AsEnumerable().Any(r => !IsValidProgId(r.Field<string>("ProgId"))))
                {
                    MTAProject.Form1.BLLMessage("Invalid Program ID.");

                    ds.RejectChanges();
                    return -1;
                }

                else
                {
                    return Data.Programs.UpdatePrograms();
                }
            }
            else
            {
                return Data.Programs.UpdatePrograms();
            }
        }
        private static bool IsValidProgId(string progId)
        {
            bool r = true;
            if (progId.Length != 5) { r = false; }
            else if (progId[0] != 'P') { r = false; }
            else
            {
                for (int i = 1; i < progId.Length; i++)
                {
                    r = r && Char.IsDigit(progId[i]);
                }
            }
            return r;
        }
    }

    class Courses
    {
        internal static int UpdateCourses()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["Courses"].GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dt != null)
            {
                if (dt.AsEnumerable().Any(r => !IsValidCourseId(r.Field<string>("CId"))))
                {
                    MTAProject.Form1.BLLMessage("Invalid Course ID.");

                    ds.RejectChanges();
                    return -1;
                }

                else
                {
                    return Data.Courses.UpdateCourses();
                }
            }
            else
            {
                return Data.Courses.UpdateCourses();
            }
        }



        private static bool IsValidCourseId(string cId)
        {
            bool r = true;
            if (cId.Length != 7) { r = false; }

            else if (cId[0] != 'C') { r = false; }
            else
            {
                for (int i = 1; i < cId.Length; i++)
                {
                    r = r && Char.IsDigit(cId[i]);
                }
            }
            return r;
        }
    }
    class Students
    {
        internal static int UpdateStudents()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["Students"].GetChanges(DataRowState.Added | DataRowState.Modified);

            if (dt != null)
            {
                if (dt.AsEnumerable().Any(r => !IsValidStudentId(r.Field<string>("StId"))))
                {
                    MTAProject.Form1.BLLMessage("Invalid Student ID.");

                    ds.RejectChanges();
                    return -1;
                }

                else
                {
                    return Data.Students.UpdateStudents();
                }
            }
            else
            {
                return Data.Students.UpdateStudents();
            }
        }

        private static bool IsValidStudentId(string stId)
        {
            bool r = true;
            if (stId.Length != 10) { r = false; }
            else if (stId[0] != 'S') { r = false; }
            else
            {
                for (int i = 1; i < stId.Length; i++)
                {
                    r = r && Char.IsDigit(stId[i]);
                }
            }
            return r;
        }
    }

    class Enrollments
    {
        internal static int UpdateFinalGrade(string[] a, string fg)
        {
            Nullable<int> finalgrade;
            int temp;

            if (fg == "")
            {
                finalgrade = null;
            }
            else if (int.TryParse(fg, out temp) && (0 <= temp && temp <= 100))
            {
                finalgrade = temp;
            }
            else
            {
                MTAProject.Form1.BLLMessage("Final grade must be an integer between 0 and 100.");
                return -1;
            }

            return Data.Enrollments.UpdateFinalGrade(a, finalgrade);
        }
    }
}
