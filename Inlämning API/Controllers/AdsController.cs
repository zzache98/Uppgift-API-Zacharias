using Inlämning_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inlämning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly AdsContext _context;

        public AdsController(AdsContext context) => _context = context;

        //<-------Uppdatera------->

        [HttpGet]
        [ProducesResponseType(typeof(Ads), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Ads>> Get()
            => await _context.Adverts.ToListAsync();

        //<-------Lista en------->


        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var ads = await _context.Adverts.FindAsync(id);
            return ads == null ? NotFound() : Ok(ads);
        }

        //<-------Skapa------->

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Ads ads)
        {
            await _context.Adverts.AddAsync(ads);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ads.Id }, ads);
        }

        //<-------Uppdatera------->

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Ads ads)
        {
            if (id != ads.Id)
                return BadRequest();

            _context.Entry(ads).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //<-------Ta bort------->

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var adsToDelete = await _context.Adverts.FindAsync(id);
            if (adsToDelete == null)
                return NotFound();

            _context.Adverts.Remove(adsToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
