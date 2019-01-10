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
        public int UpdateAccount(Account account) 
        {
            using(var db = new LedgerContext())
            {
                var _id = account.ID;
                var _accountNumber = account.AccountNumber;
                var _sortCode = account.SortCode;
                Account existingAccount = null;

                if (_id != null)
                {
                    existingAccount = GetAccountByID(_id);
                }
                else
                {
                    existingAccount = GetAccountByNumber(_accountNumber);
                }

                int count = -1;

                if (existingAccount != null) {
                    // Update 
                    var _toUpdate = db.Accounts.SingleOrDefault(a => a.ID == existingAccount.ID);
                    _toUpdate.AccountNumber = _accountNumber;
                    _toUpdate.SortCode = _sortCode;
                    count = db.SaveChanges();
                }
                else
                {
                    // Insert
                    db.Accounts.Add(new Account{
                        AccountNumber = _accountNumber,
                        SortCode = _sortCode
                    });
                    count = db.SaveChanges();
                }
                return count;
            }
        }

        // TODO: Define Read Account Methods
        // By Account #  
        private Account GetAccountByNumber(string accountNumber)
        {
            using(var db = new LedgerContext())
            {
                return db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            }
            
        }

        // By ID
        private Account GetAccountByID(Guid id)
        {
            using(var db = new LedgerContext())
            {
                return db.Accounts.Where(a => a.ID == id).FirstOrDefault();
            }
            throw new NotImplementedException();
        }
           
        // TODO: Define Get All Methods
        public ICollection<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (var db = new LedgerContext())
            {
                foreach (var account in db.Accounts)
                {
                    accounts.Add(account);
                }
            }
            return accounts;
        }
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