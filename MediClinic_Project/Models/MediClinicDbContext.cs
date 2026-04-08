using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MediClinic_Project.Models;

public partial class MediClinicDbContext : DbContext
{
    public MediClinicDbContext()
    {
    }

    public MediClinicDbContext(DbContextOptions<MediClinicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Chemist> Chemists { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<DrugRequest> DrugRequests { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Physician> Physicians { get; set; }

    public virtual DbSet<PhysicianAdvice> PhysicianAdvices { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

    public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MediClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2019F2E4B");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
            entity.Property(e => e.Criticality).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PhysicianId).HasColumnName("PhysicianID");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.ScheduleStatus).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__5629CD9C");

            entity.HasOne(d => d.Physician).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("FK__Appointme__Physi__571DF1D5");
        });

        modelBuilder.Entity<Chemist>(entity =>
        {
            entity.HasKey(e => e.ChemistId).HasName("PK__Chemists__C0D5B7B4ED5E780D");

            entity.Property(e => e.ChemistId).HasColumnName("ChemistID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(500);
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.DrugId).HasName("PK__Drugs__908D66F62699B925");

            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Dosage).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<DrugRequest>(entity =>
        {
            entity.HasKey(e => e.DrugRequestId).HasName("PK__DrugRequ__AEE9D650F635DA5F");

            entity.Property(e => e.DrugRequestId).HasColumnName("DrugRequestID");
            entity.Property(e => e.DrugInfo).HasMaxLength(200);
            entity.Property(e => e.PhysicianId).HasColumnName("PhysicianID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestStatus).HasMaxLength(50);

            entity.HasOne(d => d.Physician).WithMany(p => p.DrugRequests)
                .HasForeignKey(d => d.PhysicianId)
                .HasConstraintName("FK__DrugReque__Physi__6383C8BA");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3463571FE2B");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(500);
        });

        modelBuilder.Entity<Physician>(entity =>
        {
            entity.HasKey(e => e.PhysicianId).HasName("PK__Physicia__DFF5ED73FF4BEF95");

            entity.Property(e => e.PhysicianId).HasColumnName("PhysicianID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.Summary).HasMaxLength(500);
        });

        modelBuilder.Entity<PhysicianAdvice>(entity =>
        {
            entity.HasKey(e => e.PhysicianAdviceId).HasName("PK__Physicia__82C626101F9C84C4");

            entity.ToTable("PhysicianAdvice");

            entity.Property(e => e.PhysicianAdviceId).HasColumnName("PhysicianAdviceID");
            entity.Property(e => e.Advice).HasMaxLength(500);
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.PhysicianAdvices)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK__Physician__Sched__5CD6CB2B");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130812BE20BCD0");

            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");
            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.PhysicianAdviceId).HasColumnName("PhysicianAdviceID");
            entity.Property(e => e.Prescription1)
                .HasMaxLength(500)
                .HasColumnName("Prescription");

            entity.HasOne(d => d.Drug).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DrugId)
                .HasConstraintName("FK__Prescript__DrugI__60A75C0F");

            entity.HasOne(d => d.PhysicianAdvice).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.PhysicianAdviceId)
                .HasConstraintName("FK__Prescript__Physi__5FB337D6");
        });

        modelBuilder.Entity<PurchaseOrderHeader>(entity =>
        {
            entity.HasKey(e => e.Poid).HasName("PK__Purchase__5F02A2F48BE7CCCB");

            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrderHeaders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__PurchaseO__Suppl__66603565");
        });

        modelBuilder.Entity<PurchaseOrderLine>(entity =>
        {
            entity.HasKey(e => e.PolineId).HasName("PK__Purchase__07B9D34285F72EEA");

            entity.Property(e => e.PolineId).HasColumnName("POLineID");
            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.Poid).HasColumnName("POID");

            entity.HasOne(d => d.Drug).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.DrugId)
                .HasConstraintName("FK__PurchaseO__DrugI__6A30C649");

            entity.HasOne(d => d.Po).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.Poid)
                .HasConstraintName("FK__PurchaseOr__POID__693CA210");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69BA389281");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.ScheduleStatus).HasMaxLength(50);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK__Schedules__Appoi__59FA5E80");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694FCDA5D13");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACB498E77A");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.ReferenceToId).HasColumnName("ReferenceToID");
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
