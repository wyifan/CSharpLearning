using MvcLearning.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcLearning.Controllers
{
    public class StudentController : Controller
    {
        public IEnumerable<Student> students = new List<Student> {
            new Student{ Id =1, Age =20, StudentName="wsf"},
            new Student{ Id =2, Age =33, StudentName="sf"},
            new Student{ Id =3, Age =24, StudentName="ff"},

        };

        // GET: Student
        public ActionResult Index()
        {
            if (TempData.ContainsKey("model"))
            {
                var stuModel = TempData["model"] as List<Student>;

                TempData.Keep();

                return View(stuModel);

            }

            return View(students);
        }

        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(p => p.Id == id);

            if (TempData.ContainsKey("model"))
            {
                var stuModel = TempData["model"] as List<Student>;
                student = stuModel.FirstOrDefault(p => p.Id == id);
            }

            return View(student);
        }

        public ActionResult Details(int id)
        {

            if (TempData.ContainsKey("model"))
            {
                var stuModel = TempData["model"] as List<Student>;

                var stu = stuModel.FirstOrDefault(p => p.Id == id);

                TempData.Keep();
                return View(stu);

            }
            else
            {
                var student = students.FirstOrDefault(p => p.Id == id);
                return View(student);
            }

        }


        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            List<Student> list = new List<Student>();

            IEnumerable<Student> stuList = students;

            if (TempData.ContainsKey("model"))
            {
                stuList = TempData["model"] as List<Student>;
            }

            foreach (var item in stuList)
            {
                if (item.Id == stu.Id)
                {
                    list.Add(stu);
                }
                else
                {
                    list.Add(item);
                }
            }

            TempData["model"] = list;

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            return RedirectToAction("Index");
        }
    }
}