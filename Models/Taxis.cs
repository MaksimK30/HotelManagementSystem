﻿using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Taxis
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal? Rate { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
