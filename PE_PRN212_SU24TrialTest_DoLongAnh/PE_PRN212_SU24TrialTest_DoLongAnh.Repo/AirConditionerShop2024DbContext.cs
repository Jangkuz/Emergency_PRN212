﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PE_PRN212_SU24TrialTest_DoLongAnh.Repo.Entities;

namespace PE_PRN212_SU24TrialTest_DoLongAnh.Repo;

public partial class AirConditionerShop2024DbContext : DbContext
{
    public AirConditionerShop2024DbContext()
    {
    }

    public AirConditionerShop2024DbContext(DbContextOptions<AirConditionerShop2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AirConditioner> AirConditioners { get; set; }

    public virtual DbSet<StaffMember> StaffMembers { get; set; }

    public virtual DbSet<SupplierCompany> SupplierCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirConditioner>(entity =>
        {
            entity.HasKey(e => e.AirConditionerId).HasName("PK__AirCondi__EE2EB739AE2CD3D8");

            entity.ToTable("AirConditioner");

            entity.Property(e => e.AirConditionerId).ValueGeneratedNever();
            entity.Property(e => e.AirConditionerName).HasMaxLength(200);
            entity.Property(e => e.FeatureFunction).HasMaxLength(250);
            entity.Property(e => e.SoundPressureLevel).HasMaxLength(80);
            entity.Property(e => e.SupplierId).HasMaxLength(20);
            entity.Property(e => e.Warranty).HasMaxLength(60);

            entity.HasOne(d => d.Supplier).WithMany(p => p.AirConditioners)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__AirCondit__Suppl__29572725");
        });

        modelBuilder.Entity<StaffMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__StaffMem__0CF04B38EB46F86C");

            entity.ToTable("StaffMember");

            entity.HasIndex(e => e.EmailAddress, "UQ__StaffMem__49A1474029963875").IsUnique();

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.EmailAddress).HasMaxLength(60);
            entity.Property(e => e.FullName).HasMaxLength(60);
            entity.Property(e => e.Password).HasMaxLength(40);
        });

        modelBuilder.Entity<SupplierCompany>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4E431133E");

            entity.ToTable("SupplierCompany");

            entity.Property(e => e.SupplierId).HasMaxLength(20);
            entity.Property(e => e.PlaceOfOrigin).HasMaxLength(60);
            entity.Property(e => e.SupplierDescription).HasMaxLength(250);
            entity.Property(e => e.SupplierName).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
