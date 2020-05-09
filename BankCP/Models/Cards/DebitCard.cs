using System;
using BankCP.Models.Accounts;
using BankCP.Models.Users;

namespace BankCP.Models.Cards
{
    public partial class DebitCard
    {
        public int DebitCardId { get; set; }
        public int DebitAccountId { get; set; }
        public int ClientId { get; set; }
        public string CardNumber { get; set; }
        public string CardVerification { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual DebitAccount DebitAccount { get; set; }
    }
}
