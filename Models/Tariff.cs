using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Tariff
{
    public int Id { get; set; }

    public decimal? Cost { get; set; }

    public bool? Breakfast { get; set; }

    public bool? Lunch { get; set; }

    public bool? Dinner { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
