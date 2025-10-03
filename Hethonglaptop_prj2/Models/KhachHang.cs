using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
