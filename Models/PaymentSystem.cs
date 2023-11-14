using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class PaymentSystem
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<BankCard> BankCards { get; set; } = new List<BankCard>();
}
