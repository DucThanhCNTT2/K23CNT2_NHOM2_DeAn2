using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateOnly NgayLap { get; set; }

    public string? MaKh { get; set; }

    public string? MaNv { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
