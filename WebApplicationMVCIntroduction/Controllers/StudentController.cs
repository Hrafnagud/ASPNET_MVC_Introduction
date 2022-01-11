using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCIntroduction.Models;

namespace WebApplicationMVCIntroduction.Controllers
{
    public class StudentController : Controller
    {
        // GET: Stuent
        public ActionResult List()
        {
            List<Student> studentList = Student.BringStudents();
            return View(studentList);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            var allStudents = Student.BringStudents();
            student.Id = allStudents.Count + 1;

            Student.StudentList.Add(student);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                Student foundStudent = Student.StudentList.FirstOrDefault(x => x.Id == id);
                return View(foundStudent);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            Student toBeUpdated = Student.StudentList.FirstOrDefault(x => x.Id == student.Id);
            if (toBeUpdated != null)
            {

                //Updated information fields for a student will be assigned to student's fields.
                toBeUpdated.Name = student.Name;
                toBeUpdated.Surname = student.Surname;
                toBeUpdated.BirthDate = student.BirthDate;
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var studentTobeDeleted = Student.StudentList.FirstOrDefault(x => x.Id == id);
            return View(studentTobeDeleted);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            if (student.Id > 0)
            {
                Student.StudentList.Remove(student);
            }
            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public ActionResult DeleteConfirm(Student student)
        {
            if (student.Id > 0)
            {
                Student.StudentList.Remove(student);
                return Json(new { success = true });
            }

            return Json(new { success = false, error = "Unexpected Error!" });
        }
    }
}