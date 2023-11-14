using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
