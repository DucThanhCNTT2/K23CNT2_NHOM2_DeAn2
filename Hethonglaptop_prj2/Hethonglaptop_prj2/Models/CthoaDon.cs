using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[PrimaryKey("MaHd", "MaSp")]
[Table("CTHoaDon")]
public partial class CthoaDon
{
    [Key]
    [Column("MaHD")]
    [StringLength(10)]
    public string MaHd { get; set; } = null!;

    [Key]
    [Column("MaSP")]
    [StringLength(10)]
    public string MaSp { get; set; } = null!;

    public int SoLuong { get; set; }

    [Column(TypeName = "decimal(15, 2)")]
    public decimal DonGia { get; set; }

    [ForeignKey("MaHd")]
    [InverseProperty("CthoaDons")]
    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    [ForeignKey("MaSp")]
    [InverseProperty("CthoaDons")]
    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
