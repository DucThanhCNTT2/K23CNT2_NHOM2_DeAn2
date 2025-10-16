using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

public partial class Project2HthonglaptopvaphukienmaytinhContext : DbContext
{
    public Project2HthonglaptopvaphukienmaytinhContext()
    {
    }

    public Project2HthonglaptopvaphukienmaytinhContext(DbContextOptions<Project2HthonglaptopvaphukienmaytinhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Project2_hthonglaptopvaphukienmaytinh;User Id=sa;Password=1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5A66A495120");

            entity.HasIndex(e => e.UserName, "UQ__Accounts__C9F284560E4131CB").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp }).HasName("PK__CTHoaDon__F557F6615E895F33");

            entity.ToTable("CTHoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.DonGia).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__CTHoaDon__MaHD__47DBAE45");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTHoaDon__MaSP__48CFD27E");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0D46DCB2F");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("MaNV");
            entity.Property(e => e.TongTien).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__HoaDon__MaKH__440B1D61");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__HoaDon__MaNV__44FF419A");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E390684AD");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__Laptop__2725081C089C7E1A");

            entity.ToTable("Laptop");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.CardDoHoa).HasMaxLength(100);
            entity.Property(e => e.Cpu)
                .HasMaxLength(100)
                .HasColumnName("CPU");
            entity.Property(e => e.HeDieuHanh).HasMaxLength(100);
            entity.Property(e => e.ManHinh).HasMaxLength(50);
            entity.Property(e => e.Ocung)
                .HasMaxLength(100)
                .HasColumnName("OCung");
            entity.Property(e => e.Ram)
                .HasMaxLength(50)
                .HasColumnName("RAM");

            entity.HasOne(d => d.MaSpNavigation).WithOne(p => p.Laptop)
                .HasForeignKey<Laptop>(d => d.MaSp)
                .HasConstraintName("FK__Laptop__MaSP__3D5E1FD2");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A81434F61");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C5884B0E7");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .HasColumnName("MaSP");
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.Gia).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.MaTh)
                .HasMaxLength(10)
                .HasColumnName("MaTH");
            entity.Property(e => e.SoLuong).HasDefaultValue(0);
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaThNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaTh)
                .HasConstraintName("FK__SanPham__MaTH__3A81B327");
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaTh).HasName("PK__ThuongHi__272500750F3AB2AC");

            entity.ToTable("ThuongHieu");

            entity.Property(e => e.MaTh)
                .HasMaxLength(10)
                .HasColumnName("MaTH");
            entity.Property(e => e.QuocGia).HasMaxLength(50);
            entity.Property(e => e.TenTh)
                .HasMaxLength(100)
                .HasColumnName("TenTH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
