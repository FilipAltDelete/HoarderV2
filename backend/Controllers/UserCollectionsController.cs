using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCollectionsController : ControllerBase
    {
        private readonly Context _context;

        public UserCollectionsController(Context context)
        {
            _context = context;
        }

        // GET: api/UserCollections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCollections>>> GetUserCollections()
        {
            return await _context.UserCollections.ToListAsync();
        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCollections>> GetUserCollections(int id)
        {
            var userCollections = await _context.UserCollections.FindAsync(id);

            if (userCollections == null)
            {
                return NotFound();
            }

            return userCollections;
        }
        */

        // GET: api/UserCollections/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserCollections>>> GetCollectionsOnUserId(int userId)
        {
            //var userCollections = await _context.UserCollections.FindAsync(userId);
            var userCollections = await _context.UserCollections.Where(a => a.UserProfileId == userId).ToListAsync();

            if (userCollections == null)
            {
                return NotFound();
            }

            return userCollections;
        }

        // PUT: api/UserCollections/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCollections(int id, UserCollections userCollections)
        {
            if (id != userCollections.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCollections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCollectionsExists(id))
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

        // POST: api/UserCollections
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserCollections>> PostUserCollections(UserCollections userCollections)
        {
            _context.UserCollections.Add(userCollections);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCollections", new { id = userCollections.Id }, userCollections);
        }

        // DELETE: api/UserCollections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCollections>> DeleteUserCollections(int id)
        {
            var userCollections = await _context.UserCollections.FindAsync(id);
            if (userCollections == null)
            {
                return NotFound();
            }

            _context.UserCollections.Remove(userCollections);
            await _context.SaveChangesAsync();

            return userCollections;
        }

        private bool UserCollectionsExists(int id)
        {
            return _context.UserCollections.Any(e => e.Id == id);
        }
    }
}
