// DetailRecord.cs
using System;
using BankTransaction.Models;


namespace BankTransaction.Models
{
    public class DetailRecord
    {
        public int Id { get; set; }
        public int MasterRecordId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
    }
}