using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankTransaction.Models
{
    public class Master
    {
        public int MasterId { get; set; }
        public string AccountHolder { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}
