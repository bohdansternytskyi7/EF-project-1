using Microsoft.EntityFrameworkCore;

namespace MedicalFacility.Models
{
    public class MainDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public MainDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MainDbContext(DbContextOptions<MainDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasData(
                    new Patient() { Id = 1, FirstName = "John", LastName = "Doe", Birthdate = new DateTime(1980, 1, 1) },
                    new Patient() { Id = 2, FirstName = "Jane", LastName = "Smith", Birthdate = new DateTime(1985, 5, 15) },
                    new Patient() { Id = 3, FirstName = "Matt", LastName = "Hofman", Birthdate = new DateTime(2000, 12, 6) }
                    );
            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasData(
                    new Doctor() { Id = 1, FirstName = "Charlie", LastName = "Davis", Email = "charlie@gmail.com" },
                    new Doctor() { Id = 2, FirstName = "Bob", LastName = "Johnson", Email = "bob@gmail.com" },
                    new Doctor() { Id = 3, FirstName = "Grace", LastName = "Miller", Email = "grace@gmail.com" }
                    );
            });

            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasData(
                    new Medicament()
                    {
                        Id = 1,
                        Name = "Aspirin",
                        Description = "Aspirin is a common over-the-counter medication that is used to reduce pain, fever.",
                        Type = "Analgesic"
                    },
                    new Medicament()
                    {
                        Id = 2,
                        Name = "Ibuprofen",
                        Description = "Ibuprofen is a nonsteroidal anti-inflammatory drug (NSAID) commonly used to relieve pain.",
                        Type = "NSAID"
                    },
                    new Medicament()
                    {
                        Id = 3,
                        Name = "Simvastatin",
                        Description = "Simvastatin is a statin medication used to lower cholesterol levels in the blood.",
                        Type = "Statin"
                    }
                    );
            });

            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasOne(x => x.Patient)
                    .WithMany(y => y.Prescriptions)
                    .HasForeignKey(x => x.IdPatient);
                e.HasOne(x => x.Doctor)
                    .WithMany(y => y.Prescriptions)
                    .HasForeignKey(x => x.IdDoctor);
                e.HasData(
                    new Prescription()
                    {
                        Id = 1,
                        IdPatient = 2,
                        IdDoctor = 1,
                        Date = DateTime.Now.AddDays(2),
                        DueDate = DateTime.Now.AddDays(5)
                    },
                    new Prescription()
                    {
                        Id = 2,
                        IdPatient = 3,
                        IdDoctor = 1,
                        Date = new DateTime(2023, 11, 5),
                        DueDate = new DateTime(2023, 12, 30)
                    },
                    new Prescription()
                    {
                        Id = 3,
                        IdPatient = 1,
                        IdDoctor = 2,
                        Date = DateTime.Now.AddDays(6),
                        DueDate = DateTime.Now.AddDays(15)
                    },
                    new Prescription()
                    {
                        Id = 4,
                        IdPatient = 2,
                        IdDoctor = 3,
                        Date = new DateTime(2023, 12, 2),
                        DueDate = new DateTime(2023, 2, 15)
                    }
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>(e =>
            {
                e.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
                e.HasData(
                    new Prescription_Medicament() { IdMedicament = 1, IdPrescription = 2, Description = "Description", Dose = 5 },
                    new Prescription_Medicament() { IdMedicament = 2, IdPrescription = 4, Description = "Description", Dose = 15 },
                    new Prescription_Medicament() { IdMedicament = 3, IdPrescription = 1, Description = "Description", Dose = 12 },
                    new Prescription_Medicament() { IdMedicament = 3, IdPrescription = 3, Description = "Description", Dose = 10 }
                    );
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
