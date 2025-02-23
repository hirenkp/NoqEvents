using System;
using System.Collections.Generic;
using Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Context;

public partial class EventsDbContext : DbContext
{
    public EventsDbContext()
    {
    }

    public EventsDbContext(DbContextOptions<EventsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DealStatus> DealStatuses { get; set; }

    public virtual DbSet<NoqEvent> NoqEvents { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<OperatorType> OperatorTypes { get; set; }

    public virtual DbSet<VwEvent> VwEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=hiren.serveirc.com;Initial Catalog=NoqEvents;Persist Security Info=True;User ID=sa;Password=Av10neoKp54pgv;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .HasColumnName("Country");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsFixedLength();
        });

        modelBuilder.Entity<DealStatus>(entity =>
        {
            entity.ToTable("DealStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<NoqEvent>(entity =>
        {
            entity.ToTable("Event");

            entity.Property(e => e.DealName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Deal Name");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Event1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Event");
            entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.ToTable("Operator");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OperatorType>(entity =>
        {
            entity.ToTable("OperatorType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<VwEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEvents");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DealName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Deal Name");
            entity.Property(e => e.DealStatus)
                .HasMaxLength(50)
                .HasColumnName("Deal Status");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Event)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");
            entity.Property(e => e.Month).HasMaxLength(30);
            entity.Property(e => e.OperatorName)
                .HasMaxLength(50)
                .HasColumnName("Operator Name");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Region)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TypeOfOperator)
                .HasMaxLength(50)
                .HasColumnName("Type of Operator");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
