using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int? TaxId { get; set; }

    public int? CashDeskId { get; set; }

    public int? ServiceId { get; set; }

    public decimal? ServiceCount { get; set; }

    public virtual ICollection<AccountsTransaction> AccountsTransactions { get; set; } = new List<AccountsTransaction>();

    public virtual CashDesk? CashDesk { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Taxis? Tax { get; set; }
}
