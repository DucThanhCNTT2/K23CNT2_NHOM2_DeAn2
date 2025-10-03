using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class CthoaDon
{
    public string MaHd { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
