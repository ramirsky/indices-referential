using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndicesReferentialApi.Models;

namespace IndicesReferentialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialIndicesController : ControllerBase
    {
        private readonly FinancialIndexContext _context;

        public FinancialIndicesController(FinancialIndexContext context)
        {
            _context = context;
        }

        // GET: api/FinancialIndices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialIndex>>> GetFinancialIndices()
        {
          if (_context.FinancialIndices == null)
          {
              return NotFound();
          }
            return await _context.FinancialIndices.ToListAsync();
        }

        // GET: api/FinancialIndices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialIndex>> GetFinancialIndex(long id)
        {
          if (_context.FinancialIndices == null)
          {
              return NotFound();
          }
            var financialIndex = await _context.FinancialIndices.FindAsync(id);

            if (financialIndex == null)
            {
                return NotFound();
            }

            return financialIndex;
        }

        // PUT: api/FinancialIndices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialIndex(long id, FinancialIndex financialIndex)
        {
            if (id != financialIndex.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialIndexExists(id))
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

        // POST: api/FinancialIndices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialIndex>> PostFinancialIndex(FinancialIndex financialIndex)
        {
          if (_context.FinancialIndices == null)
          {
              return Problem("Entity set 'FinancialIndexContext.FinancialIndices'  is null.");
          }
            _context.FinancialIndices.Add(financialIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFinancialIndex), new { id = financialIndex.Id }, financialIndex);
        }

        // DELETE: api/FinancialIndices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialIndex(long id)
        {
            if (_context.FinancialIndices == null)
            {
                return NotFound();
            }
            var financialIndex = await _context.FinancialIndices.FindAsync(id);
            if (financialIndex == null)
            {
                return NotFound();
            }

            _context.FinancialIndices.Remove(financialIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialIndexExists(long id)
        {
            return (_context.FinancialIndices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
