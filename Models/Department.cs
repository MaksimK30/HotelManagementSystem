using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
