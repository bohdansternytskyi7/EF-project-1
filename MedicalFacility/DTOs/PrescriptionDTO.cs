﻿namespace MedicalFacility.DTOs
{
    public class PrescriptionDTO
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; } = new List<MedicamentDTO>();
    }
}
