using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateOnly? HireDate { get; set; }

    public DateOnly? FireDate { get; set; }

    public bool? IsFired { get; set; }

    public int? PositionId { get; set; }

    public decimal? Salary { get; set; }

    public virtual Position? Position { get; set; }

    public virtual User? User { get; set; }
}
