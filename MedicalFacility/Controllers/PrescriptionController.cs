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
    public class PrescriptionController : ControllerBase
    {
        private readonly MainDbContext _context;
        private readonly IMapper _mapper;
        public PrescriptionController(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (prescription == null)
                return NotFound();

            var prescriptionDTO = _mapper.Map<PrescriptionDTO>(prescription);
            var prescriptionMedicaments = await _context.Prescription_Medicaments
                .Include(x => x.Medicament)
                .Where(x => x.IdPrescription == id)
                .ToListAsync();
            prescriptionDTO.Medicaments = _mapper.Map<List<MedicamentDTO>>(prescriptionMedicaments);

            return Ok(prescriptionDTO);
        }
    }
}
