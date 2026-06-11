namespace Assignment_2B;
    /// <summary>
    /// A class to handle the rating of restaurants by customers
    /// </summary>
    public class Rating
    {
        // Declaring fields and properties
        public int Score { get; }
        public string Comment { get; }
        public Customer RatedBy { get; }
        /// <summary>
        /// A constructor for the rating.
        /// </summary>
        /// <param name="score">The score given for a restaurant by the customer.</param>
        /// <param name="comment">The comment given for a restaurant by the customer.</param>
        /// <param name="ratedBy">The rating placed by customer.</param>
        public Rating(int score, string comment, Customer ratedBy)
        {
            Score = score;
            Comment = comment;
            RatedBy = ratedBy;
        }
    }