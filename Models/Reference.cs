using System;
using System.Collections.Generic;

namespace ledger.Models
{
    /// <summary>
    /// Reference object, used to link one or more transactions, accounts, etc.
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// Reference ID
        /// </summary>
        /// <returns></returns>
        private Guid _id = Guid.NewGuid();
        public Guid ID
        {
            get { return _id;}
            set { _id = value;}
        }
        
        /// <summary>
        /// Entities subscribed to this reference
        /// </summary>
        /// <value></value>
        public ICollection<Guid> Entities { get; set; }

        /// <summary>
        /// Reference Description
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
    }
}