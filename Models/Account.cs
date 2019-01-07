using System;
using System.Collections.Generic;

namespace ledger.Models
{
    public class Account
    {
        /// <summary>
        /// Account ID
        /// </summary>
        /// <returns></returns>
        private Guid _id = Guid.NewGuid();
        public Guid ID
        {
            get { return _id;}
            set { _id = value;}
        }
        
        /// <summary>
        /// Account Number
        /// </summary>
        /// <value></value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Sort Code
        /// </summary>
        /// <value></value>
        public string SortCode { get; set; }
    }
}