//------------------------------Web Api--------------------------------------
using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

        // GET: api/Student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Student> lststudent = objstudent.GetAllStudent().ToList();
            return Ok(lststudent); // Return JSON for API
        }

        // GET: api/Student/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = objstudent.GetStudentData(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            objstudent.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudId }, student);
        }

        // PUT: api/Student/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (id != student.StudId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            objstudent.UpdateStudent(student);
            return NoContent();
        }

        // DELETE: api/Student/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = objstudent.GetStudentData(id);
            if (student == null)
            {
                return NotFound();
            }
            objstudent.DeleteStudent(id);
            return NoContent();
        }
    }
}


//--------------------Model View Controller-------------------------------------------
// using Microsoft.AspNetCore.Mvc;
// using MVCCoreDemo.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace MVCCoreDemo.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class StudentController : Controller
//     {
//         private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

//         public IActionResult Index()
//         {
//             List<Student> lststudent = objstudent.GetAllStudent().ToList();
//             return View(lststudent);
//         }

//         // GET: /Student/Create
//         [HttpGet]
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // POST: /Student/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Create([Bind("Name,Gender,Department,City")] Student student)
//         {
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     objstudent.AddStudent(student);
//                     return RedirectToAction(nameof(Index));
//                 }
//                 catch (Exception ex)
//                 {
//                     // Log the exception
//                     // _logger.LogError(ex, "Error occurred while adding a student.");
//                     ModelState.AddModelError(string.Empty, "An error occurred while adding the student.");
//                 }
//             }
//             return View(student);
//         }

//         // GET: /Student/Edit/5
//         [HttpGet]
//         public IActionResult Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }

//         // POST: /Student/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Edit(int id, [Bind] Student student)
//         {
//             if (id != student.StudId)
//             {
//                 return NotFound();
//             }
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     objstudent.UpdateStudent(student);
//                     return RedirectToAction(nameof(Index));
//                 }
//                 catch (Exception ex)
//                 {
//                     // Log the exception
//                     // _logger.LogError(ex, "Error occurred while updating student.");
//                     ModelState.AddModelError(string.Empty, "An error occurred while updating the student.");
//                 }
//             }
//             return View(student);
//         }
//         [HttpGet]
//         public IActionResult Details(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }
//         [HttpGet]
//         public IActionResult Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }

//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public IActionResult DeleteConfirmed(int? id)
//         {
//             objstudent.DeleteStudent(id);
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }


// using Microsoft.AspNetCore.Mvc;
// using MVCCoreDemo.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace MVCCoreDemo.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class StudentController : Controller
//     {
//         private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

//         // ================= API Endpoints ================= //

//         // API - GET: api/Student/GetStudents
//         [HttpGet]
//         [Route("GetStudents")]
//         public IActionResult GetStudents()
//         {
//             var students = objstudent.GetAllStudent();
//             return Ok(students); // Returns JSON data
//         }

//         // API - GET: api/Student/GetStudent/{id}
//         [HttpGet("{id}")]
//         [Route("GetStudent/{id}")]
//         public IActionResult GetStudent(int id)
//         {
//             var student = objstudent.GetStudentData(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return Ok(student);
//         }

//         // API - POST: api/Student/AddStudent
//         [HttpPost]
//         [Route("AddStudent")]
//         public IActionResult AddStudent([FromBody] Student student)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             try
//             {
//                 objstudent.AddStudent(student);
//                 return Ok(student); // Returns JSON data
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, "An error occurred while adding the student.");
//             }
//         }

//         // API - PUT: api/Student/UpdateStudent/{id}
//         [HttpPut("{id}")]
//         [Route("UpdateStudent/{id}")]
//         public IActionResult UpdateStudent(int id, [FromBody] Student student)
//         {
//             if (id != student.StudId)
//             {
//                 return BadRequest("Student ID mismatch.");
//             }

//             try
//             {
//                 objstudent.UpdateStudent(student);
//                 return Ok(student); // Returns JSON data
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, "An error occurred while updating the student.");
//             }
//         }

//         // API - DELETE: api/Student/DeleteStudent/{id}
//         [HttpDelete("{id}")]
//         [Route("DeleteStudent/{id}")]
//         public IActionResult DeleteStudent(int id)
//         {
//             try
//             {
//                 objstudent.DeleteStudent(id);
//                 return NoContent(); // HTTP 204
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, "An error occurred while deleting the student.");
//             }
//         }

//         // ================= MVC Actions ================= //

//         // MVC - Return List View of Students
//         public IActionResult Index()
//         {
//             List<Student> lststudent = objstudent.GetAllStudent().ToList();
//             return View(lststudent);
//         }

//         // MVC - GET: /Student/Create
//         [HttpGet]
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // MVC - POST: /Student/Create
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Create([Bind("Name,Gender,Department,City")] Student student)
//         {
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     objstudent.AddStudent(student);
//                     return RedirectToAction(nameof(Index));
//                 }
//                 catch (Exception ex)
//                 {
//                     ModelState.AddModelError(string.Empty, "An error occurred while adding the student.");
//                 }
//             }
//             return View(student);
//         }

//         // MVC - GET: /Student/Edit/5
//         [HttpGet]
//         public IActionResult Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }

//         // MVC - POST: /Student/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Edit(int id, [Bind] Student student)
//         {
//             if (id != student.StudId)
//             {
//                 return NotFound();
//             }
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     objstudent.UpdateStudent(student);
//                     return RedirectToAction(nameof(Index));
//                 }
//                 catch (Exception ex)
//                 {
//                     ModelState.AddModelError(string.Empty, "An error occurred while updating the student.");
//                 }
//             }
//             return View(student);
//         }

//         // MVC - GET: /Student/Details/5
//         [HttpGet]
//         public IActionResult Details(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }

//         // MVC - GET: /Student/Delete/5
//         [HttpGet]
//         public IActionResult Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//             Student student = objstudent.GetStudentData(id);

//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return View(student);
//         }

//         // MVC - POST: /Student/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public IActionResult DeleteConfirmed(int? id)
//         {
//             objstudent.DeleteStudent(id);
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }


// // using Microsoft.AspNetCore.Mvc;
// // using MVCCoreDemo.Models;
// // using System.Collections.Generic;
// // using System.Linq;

// // namespace MVCCoreDemo.Controllers
// // {
// //     [Route("api/[controller]")]
// //     [ApiController]
// //     public class StudentController : ControllerBase
// //     {
// //         private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

// //         // GET: api/Student
// //         [HttpGet]
// //         public IActionResult GetAllStudents()
// //         {
// //             List<Student> lststudent = objstudent.GetAllStudent().ToList();
// //             return Ok(lststudent); // Return JSON for API
// //         }

// //         // GET: api/Student/{id}
// //         [HttpGet("{id}")]
// //         public IActionResult GetStudent(int id)
// //         {
// //             var student = objstudent.GetStudentData(id);
// //             if (student == null)
// //             {
// //                 return NotFound();
// //             }
// //             return Ok(student);
// //         }

// //         // POST: api/Student
// //         [HttpPost]
// //         public IActionResult Create([FromBody] Student student)
// //         {
// //             if (!ModelState.IsValid)
// //             {
// //                 return BadRequest(ModelState);
// //             }
// //             objstudent.AddStudent(student);
// //             return CreatedAtAction(nameof(GetStudent), new { id = student.StudId }, student);
// //         }

// //         // PUT: api/Student/{id}
// //         [HttpPut("{id}")]
// //         public IActionResult Update(int id, [FromBody] Student student)
// //         {
// //             if (id != student.StudId)
// //             {
// //                 return BadRequest();
// //             }
// //             if (!ModelState.IsValid)
// //             {
// //                 return BadRequest(ModelState);
// //             }
// //             objstudent.UpdateStudent(student);
// //             return NoContent();
// //         }

// //         // DELETE: api/Student/{id}
// //         [HttpDelete("{id}")]
// //         public IActionResult Delete(int id)
// //         {
// //             var student = objstudent.GetStudentData(id);
// //             if (student == null)
// //             {
// //                 return NotFound();
// //             }
// //             objstudent.DeleteStudent(id);
// //             return NoContent();
// //         }
// //     }
// // }
