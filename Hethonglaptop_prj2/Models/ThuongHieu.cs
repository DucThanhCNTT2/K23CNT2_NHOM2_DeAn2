using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class ThuongHieu
{
    public string MaTh { get; set; } = null!;

    public string TenTh { get; set; } = null!;

    public string? QuocGia { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
