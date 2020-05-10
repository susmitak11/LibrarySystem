﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]


    public class LibrariesController : ControllerBase
    {
        private readonly LibrarySystemContext _context;

        public LibrariesController(LibrarySystemContext context)
        {
            _context = context;
        }

        // GET: api/Libraries
        [Route("/api/GetLib")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibrary()
        {
            return await _context.Library.ToListAsync();
        }

        // GET: api/Libraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            var library = await _context.Library.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        // PUT: api/Libraries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, Library library)
        {
            if (id != library.Id)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
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
        [Route("/api/UpdateLib")]
        [HttpPut]
        public async Task<ActionResult<Library>> UpdateLib([FromBody]Library library)
        {
            _context.Update(library);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLibrary", new { id = library.Id }, library);
        }

        // POST: api/Libraries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [Route("/api/AddLib")]
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            _context.Library.Add(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.Id }, library);
        }

        // DELETE: api/Libraries/5
        [Route("~/api/DeleteLib/{id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Library>> DeleteLibrary(int id)
        {
            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Library.Remove(library);
            await _context.SaveChangesAsync();

            return library;
        }

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.Id == id);
        }
    }
}
