using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatureApi.Models.DTOs;
using StoreApi.Models.Entities;

namespace NatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlaceController : ControllerBase
    {
        private readonly NatureDbContext _context;

        public PlaceController(NatureDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces(
            [FromQuery] string? category,
            [FromQuery] string? difficulty)
        {
            var query = _context.Place
                .Include(p => p.Trails)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (!string.IsNullOrEmpty(difficulty))
                query = query.Where(p => p.Trails.Any(t => t.Difficulty == difficulty));

            var places = await query.ToListAsync();
            return Ok(places);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
            var place = await _context.Place.FindAsync(id);

            if (place == null) return NotFound();

            return Ok(place);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePlace([FromBody] PlaceDto dto)
        {
            try
            {
                var newPlace = new Place
                {
                    Name = dto.Name,
                    Category = dto.Category,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                    Description = dto.Description, 
                    ElevationMeters = dto.ElevationMeters,    
                    Accessible = dto.Accessible,
                    EntryFee = dto.EntryFee,
                    OpeningHours = dto.OpeningHours,
                    CreatedAt = DateTime.Now
                };

                _context.Place.Add(newPlace);
                await _context.SaveChangesAsync();


                if (!string.IsNullOrEmpty(dto.Difficulty))
                {
                    var trail = new Trail
                    {
                        PlaceId = newPlace.Id,
                        Name = "Sendero principal",
                        DistanceKm = 1.0,
                        EstimatedTimeMinutes = 30,
                        Difficulty = dto.Difficulty,
                        Path = "",
                        IsLoop = false
                    };
                    _context.Trail.Add(trail);
                    await _context.SaveChangesAsync();
                }

                return Ok(newPlace);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
