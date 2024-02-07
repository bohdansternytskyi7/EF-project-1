using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacility.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPatient { get; set; }
        [ForeignKey(nameof(IdPatient))]
        public Patient Patient { get; set; }
        public int IdDoctor { get; set; }
        [ForeignKey(nameof(IdDoctor))]
        public Doctor Doctor { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
    }
}
