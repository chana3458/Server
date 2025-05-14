using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<InvestmentProvider> InvestmentProviders { get; set; }

    public virtual DbSet<RequestDetail> RequestDetails { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\השקעות\\DataBase.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0775BFD823");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Address)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B9A068BD");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.ExpectedCompletion)
                .HasColumnType("datetime")
                .HasColumnName("expectedCompletion");
            entity.Property(e => e.Features)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("features");
            entity.Property(e => e.Images)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("images");
            entity.Property(e => e.InvestmentProgress).HasColumnName("investmentProgress");
            entity.Property(e => e.InvestorCount).HasColumnName("investorCount");
            entity.Property(e => e.Ipid)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("IPId");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("location");
            entity.Property(e => e.MinInvestment).HasColumnName("minInvestment");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RiskLevel).HasColumnName("Risk_level");
            entity.Property(e => e.Roi).HasColumnName("roi");
            entity.Property(e => e.Term).HasColumnName("term");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("type");

            entity.HasOne(d => d.Ip).WithMany(p => p.Investments)
                .HasForeignKey(d => d.Ipid)
                .HasConstraintName("FK_Investments_ToTable");
        });

        modelBuilder.Entity<InvestmentProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0748AF91C4");

            entity.Property(e => e.Id)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Address)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__tmp_ms_x__33A8517ACB9E2597");

            entity.Property(e => e.GotOffer).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RiskLevel).HasColumnName("Risk Level");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestDetails_ToTable");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07AE495A2D");

            entity.ToTable("Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
