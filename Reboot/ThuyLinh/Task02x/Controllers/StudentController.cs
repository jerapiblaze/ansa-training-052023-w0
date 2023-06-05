using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentItemsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentItemsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentItem>>> GetStudentItems()
        {
          if (_context.StudentItems == null)
          {
              return NotFound();
          }
            return await _context.StudentItems.ToListAsync();
        }

        // GET: api/StudentItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentItem>> GetStudentItem(long id)
        {
          if (_context.StudentItems == null)
          {
              return NotFound();
          }
            var StudentItem = await _context.StudentItems.FindAsync(id);

            if (StudentItem == null)
            {
                return NotFound();
            }

            return StudentItem;
        }

        // PUT: api/StudentItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentItem(long id, StudentItem StudentItem)
        {
            if (id != StudentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(StudentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentItem>> PostStudentItem(StudentItem StudentItem)
        {
           _context.StudentItems.Add(StudentItem);
           await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStudentItem", new { id = StudentItem.Id }, StudentItem);
        return CreatedAtAction(nameof(GetStudentItem), new { id = StudentItem.Id }, StudentItem);
         }

        // DELETE: api/StudentItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentItem(long id)
        {
            if (_context.StudentItems == null)
            {
                return NotFound();
            }
            var StudentItem = await _context.StudentItems.FindAsync(id);
            if (StudentItem == null)
            {
                return NotFound();
            }

            _context.StudentItems.Remove(StudentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentItemExists(long id)
        {
            return (_context.StudentItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
