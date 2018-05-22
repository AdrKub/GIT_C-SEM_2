using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolCourseApp.Controller;
using SchoolCourseApp.Model;




namespace SchoolCourseApp
{
    public partial class Form1 : Form
    {
        SchoolController controller;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new SchoolController();
            ShowAllDepartments();
            ShowAllCourses();
        }

        private void ShowAllDepartments()
        {
            CmbBx_Department.DataSource = null;
            CmbBx_Department.DataSource = controller.LoadAllDepartments();
            CmbBx_Department.DisplayMember = "Name";
        }
        private void ShowAllCourses()
        {
            LstBx_AllCourses.DataSource = null;
            LstBx_AllCourses.DataSource = controller.LoadAllCourse();
            LstBx_AllCourses.DisplayMember = "Title";
        }

        private void RefreshCoursesOfDepartment(Department dep)
        {
            LstBx_Courses.DataSource = null;
            LstBx_Courses.DataSource = controller.LoadAllCoursesOfDepartment(dep);
            LstBx_Courses.DisplayMember = "Title";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CmbBx_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCoursesOfDepartment((Department)CmbBx_Department.SelectedItem);

            //Department _test3 = CmbBx_Department.SelectedItem as Department;

            //using(SchoolEntities context = new SchoolEntities())
            //{
            //    var _test2 = context.Courses.Where(c => c.DepartmentID == _test.DepartmentID).ToList();
            //}
        }

        private void Btn_AddToDepartment_Click(object sender, EventArgs e)
        {
            controller.AddCoursToDepartment((Department)CmbBx_Department.SelectedItem, (Course)LstBx_AllCourses.SelectedItem);
            RefreshCoursesOfDepartment((Department)CmbBx_Department.SelectedItem);
        }
    }
}
