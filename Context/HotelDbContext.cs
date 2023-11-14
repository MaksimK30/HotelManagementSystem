using System;
using System.Collections.Generic;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Context;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountsTransaction> AccountsTransactions { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankCard> BankCards { get; set; }

    public virtual DbSet<CashDesk> CashDesks { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Inn> Inns { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<PassportIssuer> PassportIssuers { get; set; }

    public virtual DbSet<PaymentSystem> PaymentSystems { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationsGuest> ReservationsGuests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<RoomsPhoto> RoomsPhotos { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Snilse> Snilses { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<Taxis> Taxes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Database=HotelDB;Password=8567");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");

            entity.ToTable("accounts", tb => tb.HasComment("Хранит данные о счетах полльзователей"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankCardId).HasColumnName("bank_card_id");
            entity.Property(e => e.BlockReason)
                .HasColumnType("character varying")
                .HasColumnName("block_reason");
            entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.BankCard).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.BankCardId)
                .HasConstraintName("accounts_bank_card_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("accounts_user_id_fkey");
        });

        modelBuilder.Entity<AccountsTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_transactions_pkey");

            entity.ToTable("accounts_transactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountsTransactions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("accounts_transactions_account_id_fkey");

            entity.HasOne(d => d.Transaction).WithMany(p => p.AccountsTransactions)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("accounts_transactions_transaction_id_fkey");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("banks_pkey");

            entity.ToTable("banks");

            entity.HasIndex(e => e.Bik, "banks_bik_key").IsUnique();

            entity.HasIndex(e => e.Ogrn, "banks_ogrn_key").IsUnique();

            entity.HasIndex(e => e.RegistrationNumber, "banks_registration_number_key").IsUnique();

            entity.HasIndex(e => e.Title, "banks_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bik)
                .HasColumnType("character varying")
                .HasColumnName("bik");
            entity.Property(e => e.Ogrn)
                .HasColumnType("character varying")
                .HasColumnName("ogrn");
            entity.Property(e => e.RegistrationNumber)
                .HasColumnType("character varying")
                .HasColumnName("registration_number");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<BankCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bank_cards_pkey");

            entity.ToTable("bank_cards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.ExpiredDate).HasColumnName("expired_date");
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .HasColumnName("number");
            entity.Property(e => e.Owner)
                .HasColumnType("character varying")
                .HasColumnName("owner");
            entity.Property(e => e.PaymentSystemId).HasColumnName("payment_system_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Bank).WithMany(p => p.BankCards)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("bank_cards_bank_id_fkey");

            entity.HasOne(d => d.PaymentSystem).WithMany(p => p.BankCards)
                .HasForeignKey(d => d.PaymentSystemId)
                .HasConstraintName("bank_cards_payment_system_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.BankCards)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("bank_cards_user_id_fkey");
        });

        modelBuilder.Entity<CashDesk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cash_desks_pkey");

            entity.ToTable("cash_desks");

            entity.HasIndex(e => e.Number, "cash_desks_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number)
                .HasColumnType("character varying")
                .HasColumnName("number");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.HasIndex(e => e.Title, "departments_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FireDate).HasColumnName("fire_date");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.IsFired).HasColumnName("is_fired");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.Salary)
                .HasPrecision(8, 2)
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("employees_position_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("employees_user_id_fkey");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.HasIndex(e => e.Title, "genders_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("guests_pkey");

            entity.ToTable("guests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Guests)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("guests_account_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Guests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("guests_user_id_fkey");
        });

        modelBuilder.Entity<Inn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inns_pkey");

            entity.ToTable("inns");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Birthlocation)
                .HasColumnType("character varying")
                .HasColumnName("birthlocation");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.GetDate).HasColumnName("get_date");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(14)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");

            entity.HasOne(d => d.Gender).WithMany(p => p.Inns)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("inns_gender_id_fkey");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.IsReaded).HasColumnName("is_readed");
            entity.Property(e => e.MessageText).HasColumnName("message_text");
            entity.Property(e => e.SendDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("send_date");
            entity.Property(e => e.Theme)
                .HasColumnType("character varying")
                .HasColumnName("theme");
            entity.Property(e => e.To).HasColumnName("to");

            entity.HasOne(d => d.FromNavigation).WithMany(p => p.MessageFromNavigations)
                .HasForeignKey(d => d.From)
                .HasConstraintName("messages_from_fkey");

            entity.HasOne(d => d.ToNavigation).WithMany(p => p.MessageToNavigations)
                .HasForeignKey(d => d.To)
                .HasConstraintName("messages_to_fkey");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passports_pkey");

            entity.ToTable("passports");

            entity.HasIndex(e => new { e.Series, e.Number }, "passports_series_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Birthlocation)
                .HasColumnType("character varying")
                .HasColumnName("birthlocation");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.IssuerId).HasColumnName("issuer_id");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(6)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.PreviousPassportId).HasColumnName("previous_passport_id");
            entity.Property(e => e.Series)
                .HasMaxLength(4)
                .HasColumnName("series");
            entity.Property(e => e.UnitCode)
                .HasMaxLength(7)
                .HasColumnName("unit_code");

            entity.HasOne(d => d.Gender).WithMany(p => p.Passports)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("passports_gender_id_fkey");

            entity.HasOne(d => d.Issuer).WithMany(p => p.Passports)
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("passports_issuer_id_fkey");

            entity.HasOne(d => d.PreviousPassport).WithMany(p => p.InversePreviousPassport)
                .HasForeignKey(d => d.PreviousPassportId)
                .HasConstraintName("passports_previous_passport_id_fkey");
        });

        modelBuilder.Entity<PassportIssuer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passport_issuers_pkey");

            entity.ToTable("passport_issuers");

            entity.HasIndex(e => e.Title, "passport_issuers_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<PaymentSystem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_systems_pkey");

            entity.ToTable("payment_systems");

            entity.HasIndex(e => e.Title, "payment_systems_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.HasIndex(e => e.Title, "positions_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.Department).WithMany(p => p.Positions)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("positions_department_id_fkey");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservations_pkey");

            entity.ToTable("reservations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Adults).HasColumnName("adults");
            entity.Property(e => e.Childrens).HasColumnName("childrens");
            entity.Property(e => e.ContactGenderId).HasColumnName("contact_gender_id");
            entity.Property(e => e.ContactName)
                .HasColumnType("character varying")
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .HasColumnName("contact_phone");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.MainGuestId).HasColumnName("main_guest_id");
            entity.Property(e => e.ServiceCount)
                .HasPrecision(3, 2)
                .HasColumnName("service_count");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TariffId).HasColumnName("tariff_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("reservations_account_id_fkey");

            entity.HasOne(d => d.ContactGender).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ContactGenderId)
                .HasConstraintName("reservations_contact_gender_id_fkey");

            entity.HasOne(d => d.MainGuest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.MainGuestId)
                .HasConstraintName("reservations_main_guest_id_fkey");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TariffId)
                .HasConstraintName("reservations_tariff_id_fkey");
        });

        modelBuilder.Entity<ReservationsGuest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservations_guests_pkey");

            entity.ToTable("reservations_guests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.IsChild).HasColumnName("is_child");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.ReservationsGuests)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("reservations_guests_guest_id_fkey");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationsGuests)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("reservations_guests_reservation_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Title, "roles_title_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.Number, "rooms_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasPrecision(8, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.Jacuzzi).HasColumnName("jacuzzi");
            entity.Property(e => e.Minibar).HasColumnName("minibar");
            entity.Property(e => e.Number)
                .HasColumnType("character varying")
                .HasColumnName("number");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Rooms).HasColumnName("rooms");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("rooms_room_type_id_fkey");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_types_pkey");

            entity.ToTable("room_types");

            entity.HasIndex(e => e.Title, "room_types_title_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('roomtypes_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<RoomsPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_photo_pkey");

            entity.ToTable("rooms_photo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('rooms_photos_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomsPhotos)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("rooms_photo_room_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasPrecision(8, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Snilse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("snilses_pkey");

            entity.ToTable("snilses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Birthlocation)
                .HasColumnType("character varying")
                .HasColumnName("birthlocation");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(14)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");

            entity.HasOne(d => d.Gender).WithMany(p => p.Snilses)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("snilses_gender_id_fkey");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tariffs_pkey");

            entity.ToTable("tariffs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Breakfast).HasColumnName("breakfast");
            entity.Property(e => e.Cost)
                .HasPrecision(8, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Dinner).HasColumnName("dinner");
            entity.Property(e => e.Lunch).HasColumnName("lunch");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Taxis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("taxes_pkey");

            entity.ToTable("taxes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Rate)
                .HasPrecision(8, 2)
                .HasColumnName("rate");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CashDeskId).HasColumnName("cash_desk_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.ServiceCount)
                .HasPrecision(3, 2)
                .HasColumnName("service_count");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TaxId).HasColumnName("tax_id");

            entity.HasOne(d => d.CashDesk).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CashDeskId)
                .HasConstraintName("transactions_cash_desk_id_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("transactions_service_id_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TaxId)
                .HasConstraintName("transactions_tax_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.InnId).HasColumnName("inn_id");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PassportId).HasColumnName("passport_id");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");
            entity.Property(e => e.SnilsId).HasColumnName("snils_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("users_gender_id_fkey");

            entity.HasOne(d => d.Inn).WithMany(p => p.Users)
                .HasForeignKey(d => d.InnId)
                .HasConstraintName("users_inn_id_fkey");

            entity.HasOne(d => d.Passport).WithMany(p => p.Users)
                .HasForeignKey(d => d.PassportId)
                .HasConstraintName("users_passport_id_fkey");

            entity.HasOne(d => d.Snils).WithMany(p => p.Users)
                .HasForeignKey(d => d.SnilsId)
                .HasConstraintName("users_snils_id_fkey");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_roles_pkey");

            entity.ToTable("users_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_roles_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("users_roles_user_id_fkey");
        });
        modelBuilder.HasSequence("accounts_id_seq");
        modelBuilder.HasSequence("accounts_transactions_id_seq");
        modelBuilder.HasSequence("bank_cards_id_seq");
        modelBuilder.HasSequence("banks_id_seq");
        modelBuilder.HasSequence("cash_desks_id_seq");
        modelBuilder.HasSequence("departments_id_seq");
        modelBuilder.HasSequence("employees_id_seq");
        modelBuilder.HasSequence("genders_id_seq");
        modelBuilder.HasSequence("guests_id_seq");
        modelBuilder.HasSequence("inns_id_seq");
        modelBuilder.HasSequence("messages_id_seq");
        modelBuilder.HasSequence("passport_issuers_id_seq");
        modelBuilder.HasSequence("passports_id_seq");
        modelBuilder.HasSequence("payment_systems_id_seq");
        modelBuilder.HasSequence("positions_id_seq");
        modelBuilder.HasSequence("reservations_guests_id_seq");
        modelBuilder.HasSequence("reservations_id_seq");
        modelBuilder.HasSequence("roles_id_seq");
        modelBuilder.HasSequence("rooms_id_seq");
        modelBuilder.HasSequence("rooms_photos_id_seq");
        modelBuilder.HasSequence("roomtypes_id_seq");
        modelBuilder.HasSequence("services_id_seq");
        modelBuilder.HasSequence("snilses_id_seq");
        modelBuilder.HasSequence("tariffs_id_seq");
        modelBuilder.HasSequence("taxes_id_seq");
        modelBuilder.HasSequence("transactions_id_seq");
        modelBuilder.HasSequence("users_id_seq");
        modelBuilder.HasSequence("users_roles_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
