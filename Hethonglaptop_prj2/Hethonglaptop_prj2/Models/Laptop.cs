using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Table("Laptop")]
public partial class Laptop
{
    [Key]
    [Column("MaSP")]
    [StringLength(10)]
    public string MaSp { get; set; } = null!;

    [Column("CPU")]
    [StringLength(100)]
    public string? Cpu { get; set; }

    [Column("RAM")]
    [StringLength(50)]
    public string? Ram { get; set; }

    [Column("OCung")]
    [StringLength(100)]
    public string? Ocung { get; set; }

    [StringLength(100)]
    public string? CardDoHoa { get; set; }

    [StringLength(100)]
    public string? HeDieuHanh { get; set; }

    [StringLength(50)]
    public string? ManHinh { get; set; }

    [ForeignKey("MaSp")]
    [InverseProperty("Laptop")]
    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
