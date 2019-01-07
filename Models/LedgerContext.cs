using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ledger.Models
{
    public class LedgerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set;}
        public DbSet<Transaction> Transactions { get; set; }
    }
}