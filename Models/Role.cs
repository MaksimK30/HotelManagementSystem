using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
