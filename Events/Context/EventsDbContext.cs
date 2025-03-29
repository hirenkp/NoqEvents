using System;
using System.Collections.Generic;
using Events.Models;
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

    public virtual DbSet<vwEvent> vwEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=noqevents.cufawi220717.us-east-1.rds.amazonaws.com;uid=noqoperator;pwd=N0q3v3nt5;database=noqevents;AllowZeroDateTime=True;ConvertZeroDateTime=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CountryCode).IsFixedLength();
        });

        modelBuilder.Entity<DealStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<NoqEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.IsArchived).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<OperatorType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<vwEvent>(entity =>
        {
            entity.ToView("vwEvents");

            entity.Property(e => e.Archived).HasDefaultValueSql("'0'");
            entity.Property(e => e.Country_Code).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
