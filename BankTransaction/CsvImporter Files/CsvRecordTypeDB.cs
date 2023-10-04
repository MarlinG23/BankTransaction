using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankTransaction.Models;

namespace BankTransaction
{
    public class CsvRecordTypeDB
    {
        public string AccountHolder { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
    }
}