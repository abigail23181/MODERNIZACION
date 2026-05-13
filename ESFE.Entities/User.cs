using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int? RolId { get; set; }

    public string UserName { get; set; } = null!;

    public string? UserNickname { get; set; }

    public string UserPassword { get; set; } = null!;

    public byte? UserStatus { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual Role? Rol { get; set; }
}
