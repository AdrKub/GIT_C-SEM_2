using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCourseApp.Model;

namespace SchoolCourseApp.Controller
{
    class SchoolController
    {
        public SchModel model = new SchModel();


        public List<Department> LoadAllDepartments()
        {
            return model.LoadDepartments();
        }

        public List<Course> LoadAllCoursesOfDepartment(Department dep)
        {
            return model.LoadCourses(dep);
        }


        public List<Course> LoadAllCourse()
        {
            return model.LoadAllCourses();
        }

        public void AddCoursToDepartment(Department _dep, Course _cour)
        {
            model.AddCourseToDepartment(_dep, _cour);
        }
    }
}
