using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

public partial class Project2Context : DbContext
{
    public Project2Context()
    {
    }

    public Project2Context(DbContextOptions<Project2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-LG42FLRB\\SQLEXPRESS;Database=Project2_hthonglaptopvaphukienmaytinh;User Id=sa;Password=1234;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp }).HasName("PK__CTHoaDon__F557F661263F612E");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.CthoaDons).HasConstraintName("FK__CTHoaDon__MaHD__59FA5E80");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.CthoaDons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHoaDon__MaSP__5AEE82B9");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0E2DC4372");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK__HoaDon__MaKH__5629CD9C");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK__HoaDon__MaNV__571DF1D5");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E8AD78BFF");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__Laptop__2725081C25810126");

            entity.HasOne(d => d.MaSpNavigation).WithOne(p => p.Laptop).HasConstraintName("FK__Laptop__MaSP__4F7CD00D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AEA3A1CCA");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C3A0D52AE");

            entity.Property(e => e.SoLuong).HasDefaultValue(0);

            entity.HasOne(d => d.MaThNavigation).WithMany(p => p.SanPhams).HasConstraintName("FK__SanPham__MaTH__4CA06362");
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaTh).HasName("PK__ThuongHi__27250075ED76CAE7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
