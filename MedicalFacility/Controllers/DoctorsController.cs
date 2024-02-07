using AutoMapper;
using MedicalFacility.DTOs;
using MedicalFacility.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalFacility.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly MainDbContext _context;
        private readonly IMapper _mapper;
        public DoctorsController(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            var doctorsDTO = _mapper.Map<List<DoctorDTO>>(doctors);
            return Ok(doctorsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctorDTO)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDTO doctorDTO)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctor == null)
                return BadRequest("Doctor does not exist in the database.");

            _mapper.Map(doctorDTO, doctor);
            await _context.SaveChangesAsync();  
            return Ok(doctor);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor([FromQuery] int id)
        {
            var doctor = await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(doctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
