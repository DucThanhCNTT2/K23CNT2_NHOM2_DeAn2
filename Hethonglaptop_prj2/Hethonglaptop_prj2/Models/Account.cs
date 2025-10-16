using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hethonglaptop_prj2.Models;

[Index("UserName", Name = "UQ__Accounts__C9F284565D2D6158", IsUnique = true)]
public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Role { get; set; }
}
