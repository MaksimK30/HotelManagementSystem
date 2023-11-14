using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class RoomsPhoto
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Room? Room { get; set; }
}
