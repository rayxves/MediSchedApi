﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MediSchedApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MediSchedApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MediSchedApi.Models.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MedicoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PacienteId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("MediSchedApi.Models.ConsultationReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsultationCount")
                        .HasColumnType("integer");

                    b.Property<int>("DoctorSpecialtyId")
                        .HasColumnType("integer");

                    b.Property<string>("MedicoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorSpecialtyId");

                    b.HasIndex("MedicoId");

                    b.ToTable("ConsultationReports");
                });

            modelBuilder.Entity("MediSchedApi.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SpecialityId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("UserId");

                    b.ToTable("DoctorSpecialties");
                });

            modelBuilder.Entity("MediSchedApi.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e9465ae7-3750-4d2b-a860-33a889c7640c",
                            Name = "Adm",
                            NormalizedName = "ADM"
                        },
                        new
                        {
                            Id = "4d456802-edab-4a3b-8b26-c4e6a4f78cee",
                            Name = "Medico",
                            NormalizedName = "MEDICO"
                        },
                        new
                        {
                            Id = "c840853c-c690-4488-9b8a-9c46c29ad71e",
                            Name = "Paciente",
                            NormalizedName = "PACIENTE"
                        });
                });

            modelBuilder.Entity("MediSchedApi.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<string>>("Keywords")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Keywords = new List<string> { "pressão alta", "dor no peito", "coração", "infarto", "cardíaco" },
                            Name = "Cardiologia"
                        },
                        new
                        {
                            Id = 2,
                            Keywords = new List<string> { "criança", "vacinas", "crescimento", "doenças infantis", "pediátrico" },
                            Name = "Pediatria"
                        },
                        new
                        {
                            Id = 3,
                            Keywords = new List<string> { "pele", "acne", "erupções cutâneas", "cabelos", "unhas" },
                            Name = "Dermatologia"
                        },
                        new
                        {
                            Id = 4,
                            Keywords = new List<string> { "dor de cabeça", "nervos", "convulsão", "neurológico", "esclerose múltipla" },
                            Name = "Neurologia"
                        },
                        new
                        {
                            Id = 5,
                            Keywords = new List<string> { "saúde da mulher", "gestação", "ciclo menstrual", "anticoncepcional", "exames ginecológicos" },
                            Name = "Ginecologia"
                        },
                        new
                        {
                            Id = 6,
                            Keywords = new List<string> { "olhos", "vista", "lentes", "miopia", "astigmatismo", "cirurgia ocular" },
                            Name = "Oftalmologia"
                        },
                        new
                        {
                            Id = 7,
                            Keywords = new List<string> { "ossos", "fraturas", "coluna", "artrose", "músculos", "cirurgia ortopédica" },
                            Name = "Ortopedia"
                        },
                        new
                        {
                            Id = 8,
                            Keywords = new List<string> { "saúde mental", "depressão", "ansiedade", "transtornos mentais", "psicoterapia" },
                            Name = "Psiquiatria"
                        },
                        new
                        {
                            Id = 9,
                            Keywords = new List<string> { "idoso", "envelhecimento", "demência", "Alzheimer", "saúde do idoso" },
                            Name = "Geriatria"
                        },
                        new
                        {
                            Id = 10,
                            Keywords = new List<string> { "ouvido", "nariz", "garganta", "sinusite", "amigdalite", "cirurgia otorrinolaringológica" },
                            Name = "Otolaringologia"
                        },
                        new
                        {
                            Id = 11,
                            Keywords = new List<string>(),
                            Name = "Geral"
                        });
                });

            modelBuilder.Entity("MediSchedApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MediSchedApi.Models.Consultation", b =>
                {
                    b.HasOne("MediSchedApi.Models.User", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MediSchedApi.Models.User", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("MediSchedApi.Models.ConsultationReport", b =>
                {
                    b.HasOne("MediSchedApi.Models.DoctorSpecialty", "DoctorSpecialty")
                        .WithMany()
                        .HasForeignKey("DoctorSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediSchedApi.Models.User", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorSpecialty");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("MediSchedApi.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("MediSchedApi.Models.Specialty", "Speciality")
                        .WithMany("DoctorSpecialties")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediSchedApi.Models.User", "User")
                        .WithMany("DoctorSpecialties")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediSchedApi.Models.User", b =>
                {
                    b.HasOne("MediSchedApi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MediSchedApi.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MediSchedApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MediSchedApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MediSchedApi.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediSchedApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MediSchedApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediSchedApi.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MediSchedApi.Models.Specialty", b =>
                {
                    b.Navigation("DoctorSpecialties");
                });

            modelBuilder.Entity("MediSchedApi.Models.User", b =>
                {
                    b.Navigation("DoctorSpecialties");
                });
#pragma warning restore 612, 618
        }
    }
}
