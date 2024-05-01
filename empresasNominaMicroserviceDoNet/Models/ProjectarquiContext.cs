using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace empresasNominaMicroserviceDoNet.Models;

public partial class ProjectarquiContext : DbContext
{
    public ProjectarquiContext()
    {
    }

    public ProjectarquiContext(DbContextOptions<ProjectarquiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=projectarqui;user=root;password=root1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");


        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("candidate")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Curriculum_id, "fk_candidate_curriculum1_idx");

            entity.HasIndex(e => e.TalentSoftUser_id, "fk_candidate_talentSoftUser1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Curriculum_id).HasColumnName("curriculum_id");
            entity.Property(e => e.EmploymentExchange)
                .HasMaxLength(45)
                .HasColumnName("employmentExchange");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.TalentSoftUser_id).HasColumnName("talentSoftUser_id");

        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("employee")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Curriculum_id, "fk_employee_curriculum1_idx");

            entity.HasIndex(e => e.TalentSoftUser_id, "fk_employee_talentSoftUser1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Curriculum_id).HasColumnName("curriculum_id");
            entity.Property(e => e.EmergencyContact).HasColumnName("emergencyContact");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NameEmergencyContact)
                .HasMaxLength(45)
                .HasColumnName("nameEmergencyContact");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.TalentSoftUser_id).HasColumnName("talentSoftUser_id");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
