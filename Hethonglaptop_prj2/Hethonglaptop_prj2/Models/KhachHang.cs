using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    [Column("MaKH")]
    [StringLength(10)]
    public string MaKh { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [Column("SDT")]
    [StringLength(20)]
    public string? Sdt { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? DiaChi { get; set; }

    [InverseProperty("MaKhNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
