using System;
using System.Collections.Generic;
using BankCP.Models.Users;

namespace BankCP.Models.Accounts
{
    public partial class FixedDeposit
    {
        public int TermDepositId { get; set; }
        public int ClientId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }
        public decimal? MinDeposit { get; set; }
        public decimal? MaxDeposit { get; set; }
        public decimal? MinWithdrawal { get; set; }
        public decimal? MaxWithdrawal { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public virtual Client Client { get; set; }
    }
}
