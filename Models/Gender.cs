using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Inn> Inns { get; set; } = new List<Inn>();

    public virtual ICollection<Passport> Passports { get; set; } = new List<Passport>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Snilse> Snilses { get; set; } = new List<Snilse>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
