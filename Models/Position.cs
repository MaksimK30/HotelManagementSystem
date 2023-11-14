using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Position
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
