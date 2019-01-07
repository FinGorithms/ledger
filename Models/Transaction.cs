using System;
using System.Collections.Generic;

namespace ledger.Models
{
    public class Transaction
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        /// <returns></returns>
        private Guid _id = Guid.NewGuid();
        public Guid ID
        {
            get { return _id;}
            set { _id = value;}
        }

        /// <summary>
        /// Transaction timestamp
        /// </summary>
        /// <value></value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Account ID which this transaction blongs
        /// </summary>
        /// <value></value>
        public Guid AccountID { get; set; }

        /// <summary>
        /// is Debit? if true then debit, else a credit transaction
        /// </summary>
        /// <value></value>
        public Boolean Debit { get; set; }
        
        /// <summary>
        /// Transaction amount in minor currency, no fractions 
        /// </summary>
        /// <value></value>
        public int Amount { get; set; }

        /// <summary>
        /// Transaction Description
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        /// <summary>
        /// Transaction Reference, used to link transactions 
        /// </summary>
        /// <value></value>
        public Guid Reference { get; set; }
    }
}