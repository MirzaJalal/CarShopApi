using CarShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/vehicles")]
    //[Route("v{v:apiVersion}/vehicles")]
    [Route("vehicles")]
    [ApiController]
    public class VehiclesV1Controller : ControllerBase
    {
        private readonly CarContext _context;
        public VehiclesV1Controller(CarContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles([FromQuery]VehicleQueryParameters queryParameters)
        {
            IQueryable<Vehicle> vehicles = _context.Vehicles;

            if(queryParameters.Min_Price != null)
            {
                vehicles = vehicles.Where(
                    p => p.Price >= queryParameters.Min_Price.Value);
            }
            if (queryParameters.Max_Price != null)
            {
                vehicles = vehicles.Where(
                    p => p.Price <= queryParameters.Max_Price.Value);
            }
            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                vehicles = vehicles.Where (
                    v=>v.ModelSku.ToLower().Contains(queryParameters.SearchTerm.ToLower()) ||
                    v.Name.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(queryParameters.ModelSku))
            {
                vehicles = vehicles.Where(v => v.ModelSku == queryParameters.ModelSku);
            }
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                vehicles = vehicles.Where(v => v.Name == queryParameters.Name);
            }


            vehicles = vehicles
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await vehicles.ToListAsync());
        }

        //GET: api/vehicles/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);

        }

        //POST: api/vechicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var addVehicle = _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetVehicle),
                    new { id = vehicle.Id },
                    vehicle
                    );
            }
            else
                return BadRequest();

        }

        //PUT: api/vehicles/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> PutVehicle(int id, Vehicle vehicle)
        {
            if(id != vehicle.Id)
            {
                return BadRequest();
            }
            _context.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        private bool VehicleExists(int id)
        {
            return (_context.Vehicles.Any(v => v.Id == id));
        }

        //DELETE: api/vehicles/delete/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            _context.SaveChangesAsync();
            return vehicle;
        } 
    }

    [ApiVersion("2.0")]
    //[Route("api/vehicles")]
    //[Route("v{v:apiVersion}/vehicles")]
    [Route("vehicles")]
    [ApiController]
    public class VehiclesV2Controller : ControllerBase
    {
        private readonly CarContext _context;
        public VehiclesV2Controller(CarContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles([FromQuery] VehicleQueryParameters queryParameters)
        {
            IQueryable<Vehicle> vehicles = 
                _context.Vehicles.Where(v=>v.IsAvailable==true);

            if (queryParameters.Min_Price != null)
            {
                vehicles = vehicles.Where(
                    p => p.Price >= queryParameters.Min_Price.Value);
            }
            if (queryParameters.Max_Price != null)
            {
                vehicles = vehicles.Where(
                    p => p.Price <= queryParameters.Max_Price.Value);
            }
            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                vehicles = vehicles.Where(
                    v => v.ModelSku.ToLower().Contains(queryParameters.SearchTerm.ToLower()) ||
                    v.Name.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
            }
            if (!string.IsNullOrEmpty(queryParameters.ModelSku))
            {
                vehicles = vehicles.Where(v => v.ModelSku == queryParameters.ModelSku);
            }
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                vehicles = vehicles.Where(v => v.Name == queryParameters.Name);
            }


            vehicles = vehicles
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);

            return Ok(await vehicles.ToListAsync());
        }

        //GET: api/vehicles/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);

        }

        //POST: api/vechicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var addVehicle = _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetVehicle),
                    new { id = vehicle.Id },
                    vehicle
                    );
            }
            else
                return BadRequest();

        }

        //PUT: api/vehicles/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            _context.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        private bool VehicleExists(int id)
        {
            return (_context.Vehicles.Any(v => v.Id == id));
        }

        //DELETE: api/vehicles/delete/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            _context.SaveChangesAsync();
            return vehicle;
        }
    }

}
