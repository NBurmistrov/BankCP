using System;
using System.Collections.Generic;
using BankCP.Models.Cards;
using BankCP.Models.Users;

namespace BankCP.Models.Accounts
{
    public partial class CreditAccount
    {
        public CreditAccount()
        {
            CreditCards = new HashSet<CreditCard>();
        }

        public int CreditAccountId { get; set; }
        public int ClientId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Debt { get; set; }
        public decimal MeansAvailable { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}
