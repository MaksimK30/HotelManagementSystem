using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class PassportIssuer
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Passport> Passports { get; set; } = new List<Passport>();
}
