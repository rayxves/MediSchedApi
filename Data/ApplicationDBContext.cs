using System.Data;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Data
{
        public class ApplicationDBContext : IdentityDbContext<User, Role, string>
        {
                public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
                : base(dbContextOptions)
                {
                }

                public DbSet<Specialty> Specialties { get; set; }
                public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
                public DbSet<Consultation> Consultations { get; set; }
                public DbSet<ConsultationReport> ConsultationReports { get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {

                        base.OnModelCreating(modelBuilder);

                        modelBuilder.Entity<User>()
                            .HasOne(u => u.Role)
                            .WithMany(r => r.Users)
                            .HasForeignKey("RoleId")
                            .IsRequired();


                        modelBuilder.Entity<DoctorSpecialty>()
                                .HasOne(ds => ds.User)
                                .WithMany(u => u.DoctorSpecialties)
                                .HasForeignKey(ds => ds.UserId);

                        modelBuilder.Entity<DoctorSpecialty>()
                                .HasOne(ds => ds.Speciality)
                                .WithMany(s => s.DoctorSpecialties)
                                .HasForeignKey(ds => ds.SpecialityId);

                        modelBuilder.Entity<Consultation>()
                                .HasOne(c => c.Medico)
                                .WithMany()
                                .HasForeignKey(c => c.MedicoId)
                                .OnDelete(DeleteBehavior.Restrict);

                        modelBuilder.Entity<Consultation>()
                                .HasOne(c => c.Paciente)
                                .WithMany()
                                .HasForeignKey(c => c.PacienteId)
                                .OnDelete(DeleteBehavior.Restrict);

                        modelBuilder.Entity<ConsultationReport>()
                                .HasOne(c => c.Medico)
                                .WithMany()
                                .HasForeignKey(c => c.MedicoId)
                                .OnDelete(DeleteBehavior.Cascade);

                        modelBuilder.Entity<Specialty>().HasData(
                                new Specialty
                                {
                                        Id = 1,
                                        Name = "Cardiologia",
                                        Keywords = new List<string> { "pressão alta", "dor no peito", "coração", "infarto", "cardíaco" }
                                },
                                new Specialty { Id = 2, Name = "Pediatria", Keywords = new List<string> { "criança", "vacinas", "crescimento", "doenças infantis", "pediátrico" } },
                                new Specialty { Id = 3, Name = "Dermatologia", Keywords = new List<string> { "pele", "acne", "erupções cutâneas", "cabelos", "unhas" } },
                                new Specialty { Id = 4, Name = "Neurologia", Keywords = new List<string> { "dor de cabeça", "nervos", "convulsão", "neurológico", "esclerose múltipla" } },
                                new Specialty { Id = 5, Name = "Ginecologia", Keywords = new List<string> { "saúde da mulher", "gestação", "ciclo menstrual", "anticoncepcional", "exames ginecológicos" } },
                                new Specialty { Id = 6, Name = "Oftalmologia", Keywords = new List<string> { "olhos", "vista", "lentes", "miopia", "astigmatismo", "cirurgia ocular" } },
                                new Specialty { Id = 7, Name = "Ortopedia", Keywords = new List<string> { "ossos", "fraturas", "coluna", "artrose", "músculos", "cirurgia ortopédica" } },
                                new Specialty { Id = 8, Name = "Psiquiatria", Keywords = new List<string> { "saúde mental", "depressão", "ansiedade", "transtornos mentais", "psicoterapia" } },
                                new Specialty { Id = 9, Name = "Geriatria", Keywords = new List<string> { "idoso", "envelhecimento", "demência", "Alzheimer", "saúde do idoso" } },
                                new Specialty { Id = 10, Name = "Otolaringologia", Keywords = new List<string> { "ouvido", "nariz", "garganta", "sinusite", "amigdalite", "cirurgia otorrinolaringológica" } },
                                new Specialty { Id = 11, Name = "Geral", Keywords = new List<string> { } });

                        modelBuilder.Entity<Role>().HasData(
                            new Role { Name = "Adm", NormalizedName = "ADM" },
                            new Role { Name = "Medico", NormalizedName = "MEDICO" },
                            new Role { Name = "Paciente", NormalizedName = "PACIENTE" }
                        );

                }


        }
}


