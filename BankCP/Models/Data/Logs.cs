using System;
using System.Collections.Generic;
using BankCP.Models.Users;

namespace BankCP.Models.Data
{
    public partial class Logs
    {
        public int LogId { get; set; }
        public int? ClientId { get; set; }
        public string Operation { get; set; }
        public string OperationType { get; set; }
        public DateTime DateLog { get; set; }

        public virtual Client Client { get; set; }
    }
}
