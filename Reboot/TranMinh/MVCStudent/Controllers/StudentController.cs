using Microsoft.AspNetCore.Mvc;
using MVCStudent.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MVCStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var studentList = _context.Students.ToList();
            return View(studentList);
        }

        public IActionResult Details(int id)
        {
            var selected = _context.Students.Find(id);
            if (selected == null)
            {
                return NotFound();
            }

            return View(selected);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var selected = _context.Students.Find(id);
            if (selected == null)
            {
                return NotFound();
            }

            return View(selected);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var selected = _context.Students.Find(id);
            if (selected == null)
            {
                return NotFound();
            }

            return View(selected);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var selected = _context.Students.Find(id);
            if (selected == null)
            {
                return NotFound();
            }

            _context.Students.Remove(selected);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
