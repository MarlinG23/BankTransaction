using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankTransaction.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public int MasterId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
    }
}
