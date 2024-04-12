using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace agenda.agendaDB;

public partial class AgendaContextDB : DbContext
{
    public AgendaContextDB()
    {
    }

    public AgendaContextDB(DbContextOptions<AgendaContextDB> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactDB> Contacts { get; set; }

    public virtual DbSet<ProfilDesRéseauxDB> ProfilDesRéseauxe { get; set; }

    public virtual DbSet<ReseauxSociauxDB> ReseauxSociauxes { get; set; }

    public virtual DbSet<StatusDB> Statuses { get; set; }

    public virtual DbSet<TaskDB> Tasks { get; set; }

    public virtual DbSet<ToDoListDB> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ContactDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adresse).HasMaxLength(45);
            entity.Property(e => e.Genre).HasColumnType("enum('Homme','Femme')");
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Prenom).HasMaxLength(45);
            entity.Property(e => e.Telephone).HasMaxLength(45);
        });

        modelBuilder.Entity<ProfilDesRéseauxDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("profil des réseaux");

            entity.HasIndex(e => e.ContactId, "fk_Profil des réseaux_contact_idx");

            entity.HasIndex(e => e.ReseauxSociauxId, "fk_Profil des réseaux_reseaux sociaux1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ReseauxSociauxId).HasColumnName("reseaux sociaux_id");

            entity.HasOne(d => d.Contact).WithMany(p => p.ProfilDesRéseauxes)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil des réseaux_contact");

            entity.HasOne(d => d.ReseauxSociaux).WithMany(p => p.ProfilDesRéseauxes)
                .HasForeignKey(d => d.ReseauxSociauxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil des réseaux_reseaux sociaux1");
        });

        modelBuilder.Entity<ReseauxSociauxDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reseaux sociaux");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Url).HasMaxLength(45);
        });

        modelBuilder.Entity<StatusDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<TaskDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.ToDoListId, "fk_Task_To do list1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Check)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.ToDoListId).HasColumnName("To do list_id");

            entity.HasOne(d => d.ToDoList).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ToDoListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Task_To do list1");
        });

        modelBuilder.Entity<ToDoListDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("to do list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateFin).HasColumnName("date fin");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Mask)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("mask");
            entity.Property(e => e.Titre).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
