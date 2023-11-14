using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class AccountsTransaction
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public int? TransactionId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
