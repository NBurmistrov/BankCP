using System;
using System.Collections.Generic;
using BankCP.Models.Cards;
using BankCP.Models.Users;

namespace BankCP.Models.Accounts
{
    public partial class DebitAccount
    {
        public DebitAccount()
        {
            DebitCards = new HashSet<DebitCard>();
        }

        public int DebitAccountId { get; set; }
        public int ClientId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string СurrencyСode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<DebitCard> DebitCards { get; set; }
    }
}
