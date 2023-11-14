using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Message
{
    public int Id { get; set; }

    public DateTime? SendDate { get; set; }

    public int? From { get; set; }

    public int? To { get; set; }

    public bool? IsReaded { get; set; }

    public string? Theme { get; set; }

    public string? MessageText { get; set; }

    public virtual User? FromNavigation { get; set; }

    public virtual User? ToNavigation { get; set; }
}
