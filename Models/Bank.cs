using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Bank
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? Bik { get; set; }

    public string? Ogrn { get; set; }

    public virtual ICollection<BankCard> BankCards { get; set; } = new List<BankCard>();
}
