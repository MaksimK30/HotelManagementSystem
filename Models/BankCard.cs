using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class BankCard
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Number { get; set; }

    public string? Owner { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public int? PaymentSystemId { get; set; }

    public int? BankId { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Bank? Bank { get; set; }

    public virtual PaymentSystem? PaymentSystem { get; set; }

    public virtual User? User { get; set; }
}
