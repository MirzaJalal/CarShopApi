﻿using CarShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShopApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly CarContext _context;
        public VehiclesController(CarContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();

            return Ok(vehicles);
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
}
