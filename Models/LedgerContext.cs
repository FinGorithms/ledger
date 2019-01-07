using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ledger.Models
{
    public class LedgerContext : DbContext
    {
        #region Initialization Code 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)    
        {
            // TODO: Parameterize Following Code
            optionsBuilder.UseSqlite("Data Source=ledger.db");
        }
        #endregion
        #region Models
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
        #endregion

        #region Account Methods
        // TODO: Define Insert Method 
        // TODO: Define Read Account Method     
        // TODO: Define Search Methods
        #endregion

        #region Transaction Methods
        // TODO: Define Insert Method 
        // TODO: Define Read Account Method     
        // TODO: Define Search Methods            
        #endregion

        #region Reference Methods
        // TODO: Define Insert Method 
        // TODO: Define Read Account Method     
        // TODO: Define Search Methods    
        #endregion
    
    }
}