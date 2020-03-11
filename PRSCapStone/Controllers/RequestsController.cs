using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRSCapStone.Data;
using PRSCapStone.Models;

namespace PRSCapStone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        public const string StatReview = "REVIEW";
        public const string StatApproved = "APPROVED";
        public const string StatRejected = "REJECTED";
        
        private readonly CsDb _context;

        public RequestsController(CsDb context)
        {
            _context = context;
        }
 
        // post get all the records whose id is review
        [HttpGet("returnstatreview")]
        public async Task<ActionResult<IEnumerable<Request>>> GetStatReview() {
            return await _context.Request.Where(x => x.Status == StatReview).ToListAsync();
        }
        //POST: set stat to review api/postreview/request
        [HttpPost("setstattoreview")]
        public Task<ActionResult<Request>> SetStatToReview(Request request) {
            if (request.Total <= 50) {
                request.Status = StatApproved;
            } else {
                request.Status = StatReview;
            }
            return PostRequest(request);
        }
        [HttpPost("setstattoapproved")]
        public Task<ActionResult<Request>> SetStatToApproved(Request request) {
            request.Status = StatApproved;
            return PostRequest(request);
        }
        [HttpPost("setstattoreject")]
        public Task<ActionResult<Request>> SetStatToReject(Request request) {
            request.Status = StatApproved;
            request.RejectionReason = "Because";
            return PostRequest(request);
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Request.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
