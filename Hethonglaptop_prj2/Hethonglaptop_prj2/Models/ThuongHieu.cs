using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("ThuongHieu")]
public partial class ThuongHieu
{
    [Key]
    [Column("MaTH")]
    [StringLength(10)]
    public string MaTh { get; set; } = null!;

    [Column("TenTH")]
    [StringLength(100)]
    public string TenTh { get; set; } = null!;

    [StringLength(50)]
    public string? QuocGia { get; set; }

    [InverseProperty("MaThNavigation")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
