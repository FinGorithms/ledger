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
        /// <summary>
        /// Insert/Update Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns>-1 if anything went wrong, and a positive number otherwise</returns>
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


        /// <summary>
        /// Searches for an account given its number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>account object found</returns>
        private Account GetAccountByNumber(string accountNumber)
        {
            using(var db = new LedgerContext())
            {
                return db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            }
            
        }

        /// <summary>
        /// Searches for an account given its GUID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>account object found</returns>
        private Account GetAccountByID(Guid id)
        {
            using(var db = new LedgerContext())
            {
                return db.Accounts.Where(a => a.ID == id).FirstOrDefault();
            }
            throw new NotImplementedException();
        }
           
        /// <summary>
        /// Gets all accounts defined
        /// </summary>
        /// <returns>All accounts defined</returns>
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
        
        /// <summary>
        /// Create New Transaction, This object is immutable; should never be updated or deleted
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>-1 if any exception, and a postive number otherwise</returns>
        public int CreateTransaction(Transaction transaction)
        {
            using (var db = new LedgerContext())
            {
                var _id = transaction.ID;
                var _accountId = transaction.AccountID;
                var _amount = transaction.Amount;
                var _debit = transaction.Debit;
                var _description = transaction.Description;
                var _reference = transaction.Reference;
                var _timestamp = transaction.Timestamp;

                if (_timestamp  == null) {
                    _timestamp = DateTime.Now;
                }

                int count = -1;

                // Always insert, never update a transaction 
                db.Transactions.Add(new Transaction{
                    AccountID = _accountId,
                    Amount = _amount,
                    Debit = _debit,
                    Description = _description,
                    Reference = _reference,
                    Timestamp = _timestamp
                });

                count = db.SaveChanges();
                return count;
            }
            
        }


        /// <summary>
        /// Gets all transactions in collection 
        /// </summary>
        /// <returns>All transactions stored</returns>         
        public ICollection<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var db = new LedgerContext())
            {
                foreach (var transaction in db.Transactions)
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        // TODO: an overload method for get all transactions, by passing filter criteria, this may require a new search object
        // TODO: Define Read Transaction Method     
        // TODO: Define Search Methods   
        #endregion

        #region Reference Methods
        // TODO: Define Insert Method 
        // TODO: Define Read Reference Method     
        // TODO: Define Search Methods    
        #endregion

    }
}