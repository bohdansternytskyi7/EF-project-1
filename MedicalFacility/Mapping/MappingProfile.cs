using AutoMapper;
using MedicalFacility.DTOs;
using MedicalFacility.Models;

namespace MedicalFacility.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Medicament, MedicamentDTO>();
            CreateMap<MedicamentDTO, Medicament>();
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<PrescriptionDTO, Prescription>();
            CreateMap<Prescription_Medicament, MedicamentDTO>()
                .ForMember(x => x.DoctorsDescription, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Dose, y => y.MapFrom(z => z.Dose))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Medicament.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Medicament.Description))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Medicament.Type));
        }
    }
}
