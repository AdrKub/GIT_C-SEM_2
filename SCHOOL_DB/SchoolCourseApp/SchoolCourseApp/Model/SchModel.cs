using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCourseApp.Model
{
    class SchModel
    {

        public List<Department> departments;

        public List<Department> LoadDepartments()
        {

            using (SchoolEntities context = new SchoolEntities())
            {

                var _departments = context.Departments.ToList<Department>();

                departments = _departments;
                return _departments;
            }
        }

        public List<Course> LoadCourses(Department dep)
        {

            using (SchoolEntities context = new SchoolEntities())
            {

                var _courses = (from c in context.Courses where c.DepartmentID == dep.DepartmentID select c).ToList<Course>();

                return _courses;
            }
        }

        public List<Course> LoadAllCourses()
        {
            using (SchoolEntities context = new SchoolEntities())
            {

                var _courses = context.Courses.ToList<Course>();

                return _courses;
            }
        }


        public void AddCourseToDepartment(Department dep, Course cour)
        {
            using (SchoolEntities context = new SchoolEntities())
            {

                Department _dep = (from d in context.Departments.Include("Courses") where d.DepartmentID == dep.DepartmentID select d).FirstOrDefault();

                //Course muss auch geladen werden (aus anderen Session kann kein Kurs addiert werden)!!!

                Course _cour = context.Courses.Where(c => c.CourseID == cour.CourseID).FirstOrDefault();

                _dep.Courses.Add(_cour);
                context.SaveChanges();
            }
        }


    }
}
