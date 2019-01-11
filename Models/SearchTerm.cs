namespace ledger.Models
{
    public class SearchTerm
    {
        // HINT: a search term should contain field names

        /// <summary>
        /// Search clause used in query as a string
        /// </summary>
        /// <value></value>
        public string Clause { get; set; }

        /// <summary>
        /// Selection modifier as AND or OR 
        /// </summary>
        /// <value></value>
        public string SelectionModifier { get; set; }

        /// <summary>
        /// Order of clause 
        /// </summary>
        /// <value></value>
        public int Order { get; set; }
    }
}