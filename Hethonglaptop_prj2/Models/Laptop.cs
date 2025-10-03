using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class Laptop
{
    public string MaSp { get; set; } = null!;

    public string? Cpu { get; set; }

    public string? Ram { get; set; }

    public string? Ocung { get; set; }

    public string? CardDoHoa { get; set; }

    public string? HeDieuHanh { get; set; }

    public string? ManHinh { get; set; }

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
