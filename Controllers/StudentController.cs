using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCCoreDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

        public IActionResult Index()
        {
            List<Student> lststudent = objstudent.GetAllStudent().ToList();
            return View(lststudent);
        }

        // GET: /Student/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Gender,Department,City")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objstudent.AddStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // _logger.LogError(ex, "Error occurred while adding a student.");
                    ModelState.AddModelError(string.Empty, "An error occurred while adding the student.");
                }
            }
            return View(student);
        }

        // GET: /Student/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = objstudent.GetStudentData(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Student student)
        {
            if (id != student.StudId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    objstudent.UpdateStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // _logger.LogError(ex, "Error occurred while updating student.");
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the student.");
                }
            }
            return View(student);
        }
         [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Student student = objstudent.GetStudentData(id);

        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    [HttpGet]  
public IActionResult Delete(int? id)  
{  
    if (id == null)  
    {  
        return NotFound();  
    }  
    Student student = objstudent.GetStudentData(id);  
  
    if (student == null)  
    {  
        return NotFound();  
    }  
    return View(student);  
}  
  
[HttpPost, ActionName("Delete")]  
[ValidateAntiForgeryToken]  
public IActionResult DeleteConfirmed(int? id)  
{  
    objstudent.DeleteStudent(id);  
 return RedirectToAction(nameof(Index));
}
    }
   
}

