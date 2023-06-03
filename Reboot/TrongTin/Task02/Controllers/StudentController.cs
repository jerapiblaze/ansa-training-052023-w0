// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using MvcStudent.Data;
// using MvcStudent.Models;

// namespace MvcStudent.Controllers
// {
//     public class StudentController : Controller
//     {
//         private readonly MvcStudentContext _context;

//         public StudentController(MvcStudentContext context)
//         {
//             _context = context;
//         }

//         public async Task<IResult> Index()
//         {
//             return Results.Ok();
//         }
//         // GET: Student/Details/5
//         [HttpGet("{id}")]
//         public async Task<IResult> Details(int? id)
//         {
//             if (id == null || _context.Student == null)
//             {
//                 return Results.NotFound();
//             }

//             var student = await _context.Student.FirstOrDefaultAsync(m => m.id == id);
//             if (student == null)
//             {
//                 return Results.NotFound();
//             }

//             return Results.Ok(student);
//         }
    
//         // POST: Student/Create
//         [HttpPost("/student/create")]
//         public async Task<IResult> Create(Student student)
//         {
//             Console.WriteLine("Create");
//             if (ModelState.IsValid)
//             {
//                 _context.Add(student);
//                 await _context.SaveChangesAsync();
//                 return Results.Redirect(nameof(Index));
//             }
//             return Results.Ok(student);
//         }

//         // GET: Student/Edit
//         [HttpPut("{id}")]
//         public async Task<IResult> Edit(int? id)
//         {
//             if (id == null || _context.Student == null)
//             {
//                 return Results.NotFound();
//             }

//             var student = await _context.Student.FindAsync(id);
//             if (student == null)
//             {
//                 return Results.NotFound();
//             }
//             return Results.Ok(student);
//         }

//         // POST: Student/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPut("{id}")]
//         public async Task<IResult> Edit(int id, [Bind("id,name,GPA")] Student student)
//         {
//             if (id != student.id)
//             {
//                 return Results.NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(student);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!StudentExists(student.id))
//                     {
//                         return Results.NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return Results.Redirect(nameof(Index));
//             }
//             return Results.Ok(student);
//         }

//         // GET: Student/Delete/5
//         [HttpDelete("{id}")]
//         public async Task<IResult> Delete(int? id)
//         {
//             if (id == null || _context.Student == null)
//             {
//                 return Results.NotFound();
//             }

//             var student = await _context.Student
//                 .FirstOrDefaultAsync(m => m.id == id);
//             if (student == null)
//             {
//                 return Results.NotFound();
//             }

//             return Results.Ok(student);
//         }

//         // POST: Student/Delete/5
//         [HttpDelete("{id}")]
//         public async Task<IResult> DeleteConfirmed(int id)
//         {
//             if (_context.Student == null)
//             {
//                 return Results.Problem("Entity set 'MvcStudentContext.Student'  is null.");

//             }
//             var student = await _context.Student.FindAsync(id);
//             if (student != null)
//             {
//                 _context.Student.Remove(student);
//             }

//             await _context.SaveChangesAsync();
//             return Results.Redirect(nameof(Index));
//         }

//         private bool StudentExists(int id)
//         {
//             return (_context.Student?.Any(e => e.id == id)).GetValueOrDefault();
//         }
//     }
// }
