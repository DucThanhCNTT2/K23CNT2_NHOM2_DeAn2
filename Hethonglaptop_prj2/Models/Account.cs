using System;
using System.Collections.Generic;

namespace Hethonglaptop_prj2.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public string? Role { get; set; }
}
