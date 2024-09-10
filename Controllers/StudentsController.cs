
// using Microsoft.AspNetCore.Mvc;
// using MVCCoreDemo.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace MVCCoreDemo.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class StudentsController : ControllerBase
//     {
//         private readonly StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

//         // GET: api/Student
//         [HttpGet]
//         public IActionResult GetAllStudents()
//         {
//             List<Student> lststudent = objstudent.GetAllStudent().ToList();
//             return Ok(lststudent); // Return JSON for API
//         }

//         // GET: api/Student/{id}
//         [HttpGet("{id}")]
//         public IActionResult GetStudent(int id)
//         {
//             var student = objstudent.GetStudentData(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             return Ok(student);
//         }

//         // POST: api/Student
//         [HttpPost]
//         public IActionResult Create([FromBody] Student student)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             objstudent.AddStudent(student);
//             return CreatedAtAction(nameof(GetStudent), new { id = student.StudId }, student);
//         }

//         // PUT: api/Student/{id}
//         [HttpPut("{id}")]
//         public IActionResult Update(int id, [FromBody] Student student)
//         {
//             if (id != student.StudId)
//             {
//                 return BadRequest();
//             }
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             objstudent.UpdateStudent(student);
//             return NoContent();
//         }

//         // DELETE: api/Student/{id}
//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             var student = objstudent.GetStudentData(id);
//             if (student == null)
//             {
//                 return NotFound();
//             }
//             objstudent.DeleteStudent(id);
//             return NoContent();
//         }
//     }
// }
