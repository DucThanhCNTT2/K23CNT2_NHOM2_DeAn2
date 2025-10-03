using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public decimal Gia { get; set; }

    public int? SoLuong { get; set; }

    public string? MoTa { get; set; }

    public string? MaTh { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual Laptop? Laptop { get; set; }

    public virtual ThuongHieu? MaThNavigation { get; set; }
}
