using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ledger.Models
{
    public class LedgerContext : DbContext
    {
        /// <summary>
        /// Account Objects
        /// </summary>
        /// <value></value>
        public DbSet<Account> Accounts { get; set;}

        /// <summary>
        /// Transaction Objects
        /// </summary>
        /// <value></value>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Reference Objects
        /// </summary>
        /// <value></value>

        public DbSet<Reference> References { get; set; }
    }
}