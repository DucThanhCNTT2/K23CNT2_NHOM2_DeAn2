using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    [Column("MaNV")]
    [StringLength(10)]
    public string MaNv { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(50)]
    public string? ChucVu { get; set; }

    [Column("SDT")]
    [StringLength(20)]
    public string? Sdt { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
