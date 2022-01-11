using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCIntroduction.Models;

namespace WebApplicationMVCIntroduction.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            var estudianteData = Student.BringStudents();
            return View(estudianteData);
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                var estudiante = Student.StudentList.FirstOrDefault(x => x.Id == id);
                return View(estudiante);
            }
            return View("Error");
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                student.Id = Student.StudentList.Count + 1;
                Student.StudentList.Add(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                var estudiante = Student.StudentList.FirstOrDefault(x => x.Id == id);
                return View(estudiante);
            }
            return View("Error");
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here
                if (student.Id > 0)
                {
                    var oldStudentRecord = Student.StudentList.FirstOrDefault(x => x.Id == student.Id);
                    oldStudentRecord.Name = student.Name;
                    oldStudentRecord.Surname = student.Surname;
                    oldStudentRecord.BirthDate = student.BirthDate;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var estudiante = Student.StudentList.FirstOrDefault(x => x.Id == id);
                return View(estudiante);
            }
            return View("Error");
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here
                if (student.Id > 0)
                {
                    Student.StudentList.Remove(student);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
