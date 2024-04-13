using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTLwebNC.Models;

public partial class RentalDbContext : DbContext
{
    public RentalDbContext()
    {
    }

    public RentalDbContext(DbContextOptions<RentalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblNews> TblNews { get; set; }

    public virtual DbSet<TblThuexe> TblThuexes { get; set; }

    public virtual DbSet<TblTtxe> TblTtxes { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AEQCG9Q\\SQLEXPRESS;Initial Catalog=RentalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_cont__3213E83FBFA096A8");

            entity.ToTable("tbl_contact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblContacts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_id_contact_user");
        });

        modelBuilder.Entity<TblNews>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_news__3213E83F1C4EDA21");

            entity.ToTable("tbl_news");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblNews)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_id_new_user");
        });

        modelBuilder.Entity<TblThuexe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_thue__3213E83F8D018816");

            entity.ToTable("tbl_thuexe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.IdTtxe).HasColumnName("id_ttxe");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.IdTtxeNavigation).WithMany(p => p.TblThuexes)
                .HasForeignKey(d => d.IdTtxe)
                .HasConstraintName("fk_id_ttxe_thuexe");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblThuexes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_id_thuexe");
        });

        modelBuilder.Entity<TblTtxe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_ttxe__3213E83FA3040979");

            entity.ToTable("tbl_ttxe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Namsanxuat).HasColumnName("namsanxuat");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Tenxe)
                .HasMaxLength(255)
                .HasColumnName("tenxe");
            entity.Property(e => e.Tien)
                .HasMaxLength(255)
                .HasColumnName("tien");
            entity.Property(e => e.IsCheck)
                .HasMaxLength(255)
                .HasColumnName("ischeck");
            entity.Property(e => e.Publish).HasColumnName("publish");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblTtxes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_id_ttxe");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_user__3213E83F173E1B08");

            entity.ToTable("tbl_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
