using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Passport
{
    public int Id { get; set; }

    public DateOnly? IssueDate { get; set; }

    public int? IssuerId { get; set; }

    public string? UnitCode { get; set; }

    public string? Series { get; set; }

    public string? Number { get; set; }

    public string? Lastname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public int? GenderId { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Birthlocation { get; set; }

    public byte[]? Photo { get; set; }

    public int? PreviousPassportId { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<Passport> InversePreviousPassport { get; set; } = new List<Passport>();

    public virtual PassportIssuer? Issuer { get; set; }

    public virtual Passport? PreviousPassport { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
