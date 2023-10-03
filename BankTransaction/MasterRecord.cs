// MasterRecord.cs
using System;
using BankTransaction.Models;

namespace BankTransaction.Models
{
    public class MasterRecord
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}