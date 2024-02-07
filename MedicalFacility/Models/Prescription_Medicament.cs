using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacility.Models
{
    public class Prescription_Medicament
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Medicament")]
        public int IdMedicament {  get; set; }
        public Medicament Medicament { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }
        public Prescription Prescription { get; set; }  
        public int Dose { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
