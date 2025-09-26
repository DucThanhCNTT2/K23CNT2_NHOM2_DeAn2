using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    [Column("MaSP")]
    [StringLength(10)]
    public string MaSp { get; set; } = null!;

    [Column("TenSP")]
    [StringLength(150)]
    public string TenSp { get; set; } = null!;

    [Column(TypeName = "decimal(15, 2)")]
    public decimal Gia { get; set; }

    public int? SoLuong { get; set; }

    public string? MoTa { get; set; }

    [Column("MaTH")]
    [StringLength(10)]
    public string? MaTh { get; set; }

    [StringLength(255)]
    public string? Anh { get; set; }

    [InverseProperty("MaSpNavigation")]
    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    [InverseProperty("MaSpNavigation")]
    public virtual Laptop? Laptop { get; set; }

    [ForeignKey("MaTh")]
    [InverseProperty("SanPhams")]
    public virtual ThuongHieu? MaThNavigation { get; set; }
}
