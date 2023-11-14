using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class CashDesk
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
