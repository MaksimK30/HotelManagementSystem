using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class ReservationsGuest
{
    public int Id { get; set; }

    public int? GuestId { get; set; }

    public int? ReservationId { get; set; }

    public bool? IsChild { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
