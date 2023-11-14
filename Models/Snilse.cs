using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Snilse
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public string? Lastname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? GenderId { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Birthlocation { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
