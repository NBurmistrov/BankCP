using BankCP.Models.Accounts;
using BankCP.Models.Cards;
using BankCP.Models.Data;
using BankCP.Models.Users;
using BankCP.Modules.Implementation;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankCP.Models.DBContext
{
    [Authorized]
    public partial class BankContext : DbContext
    {
        private readonly IConfiguration configuration;
        public BankContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public BankContext(DbContextOptions<BankContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }


        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CreditAccount> CreditAccounts { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<DebitAccount> DebitAccounts { get; set; }
        public virtual DbSet<DebitCard> DebitCards { get; set; }
        public virtual DbSet<FixedDeposit> FixedDeposits { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Bank"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__Clients__E67E1A04401537D3");

                entity.HasIndex(e => e.PassportNumber)
                    .HasName("UQ__Clients__45809E71F12B05D1")
                    .IsUnique();

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreditAccount>(entity =>
            {
                entity.HasKey(e => e.CreditAccountId)
                    .HasName("PK__CreditAc__3DF1E9E501651807");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("UQ__CreditAc__BE2ACD6FA230735C")
                    .IsUnique();

                entity.Property(e => e.CreditAccountId)
                    .HasColumnName("CreditAccountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Debt).HasColumnType("money");

                entity.Property(e => e.MeansAvailable).HasColumnType("money");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CreditAccounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditAccounts_Clients");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.CreditCardId)
                    .HasName("PK__CreditCa__6EB1F5109AB3A52D");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__CreditCa__A4E9FFE9B53D2D00")
                    .IsUnique();

                entity.Property(e => e.CreditCardId)
                    .HasColumnName("CreditCardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CardVerification)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreditAccountId).HasColumnName("CreditAccountID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCards_Clients");

                entity.HasOne(d => d.CreditAccount)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.CreditAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCards_CreditAccounts");
            });

            modelBuilder.Entity<DebitAccount>(entity =>
            {
                entity.HasKey(e => e.DebitAccountId)
                    .HasName("PK__DebitAcc__25A4E8650D07E8F9");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("UQ__DebitAcc__BE2ACD6FCBC76D58")
                    .IsUnique();

                entity.Property(e => e.DebitAccountId)
                    .HasColumnName("DebitAccountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.СurrencyСode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DebitAccounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitAccounts_Clients");
            });

            modelBuilder.Entity<DebitCard>(entity =>
            {
                entity.HasKey(e => e.DebitCardId)
                    .HasName("PK__DebitCar__E5250EA7682BF53D");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__DebitCar__A4E9FFE9330C56DD")
                    .IsUnique();

                entity.Property(e => e.DebitCardId)
                    .HasColumnName("DebitCardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CardVerification)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DebitAccountId).HasColumnName("DebitAccountID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DebitCards)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitCards_Clients");

                entity.HasOne(d => d.DebitAccount)
                    .WithMany(p => p.DebitCards)
                    .HasForeignKey(d => d.DebitAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitCards_DebitAccounts");
            });

            modelBuilder.Entity<FixedDeposit>(entity =>
            {
                entity.HasKey(e => e.TermDepositId)
                    .HasName("PK__FidexDep__2D45198441BACFE3");

                entity.Property(e => e.TermDepositId)
                    .HasColumnName("TermDepositID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaxDeposit)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxWithdrawal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinDeposit)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinWithdrawal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FixedDeposits)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FidexDeposits_Clients");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Logs__5E5499A8A078EE41");

                entity.Property(e => e.LogId)
                    .HasColumnName("LogID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateLog).HasColumnType("datetime");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Logs_Clients");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
