using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Lastname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? GenderId { get; set; }

    public int? PassportId { get; set; }

    public int? SnilsId { get; set; }

    public int? InnId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<BankCard> BankCards { get; set; } = new List<BankCard>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Guest> Guests { get; set; } = new List<Guest>();

    public virtual Inn? Inn { get; set; }

    public virtual ICollection<Message> MessageFromNavigations { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageToNavigations { get; set; } = new List<Message>();

    public virtual Passport? Passport { get; set; }

    public virtual Snilse? Snils { get; set; }

    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
