using System;
using System.Collections.Generic;
using BankCP.Models.Accounts;
using BankCP.Models.Cards;
using BankCP.Models.Data;

namespace BankCP.Models.Users
{
    public partial class Client
    {
        public Client()
        {
            CreditAccounts = new HashSet<CreditAccount>();
            CreditCards = new HashSet<CreditCard>();
            DebitAccounts = new HashSet<DebitAccount>();
            DebitCards = new HashSet<DebitCard>();
            FixedDeposits = new HashSet<FixedDeposit>();
            Logs = new HashSet<Logs>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PassportNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CreditAccount> CreditAccounts { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<DebitAccount> DebitAccounts { get; set; }
        public virtual ICollection<DebitCard> DebitCards { get; set; }
        public virtual ICollection<FixedDeposit> FixedDeposits { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }
    }
}
