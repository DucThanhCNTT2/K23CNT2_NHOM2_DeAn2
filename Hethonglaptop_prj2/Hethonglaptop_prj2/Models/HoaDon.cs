using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    [Column("MaHD")]
    [StringLength(10)]
    public string MaHd { get; set; } = null!;

    public DateOnly NgayLap { get; set; }

    [Column("MaKH")]
    [StringLength(10)]
    public string? MaKh { get; set; }

    [Column("MaNV")]
    [StringLength(10)]
    public string? MaNv { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal? TongTien { get; set; }

    [InverseProperty("MaHdNavigation")]
    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    [ForeignKey("MaKh")]
    [InverseProperty("HoaDons")]
    public virtual KhachHang? MaKhNavigation { get; set; }

    [ForeignKey("MaNv")]
    [InverseProperty("HoaDons")]
    public virtual NhanVien? MaNvNavigation { get; set; }
}
