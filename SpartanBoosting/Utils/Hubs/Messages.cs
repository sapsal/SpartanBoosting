namespace SpartanBoosting.Utils.Hubs
{
	    /// <summary>
    /// Stores shared names used in both client and hub
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Event name when a message is received
        /// </summary>
        public const string RECEIVE = "ReceiveMessage";

        /// <summary>
        /// Name of the Hub method to register a new user
        /// </summary>
        public const string REGISTER = "Register";

        /// <summary>
        /// Name of the Hub method to send a message
        /// </summary>
        public const string SEND = "SendMessage";


		/// <summary>
		/// Name of the Hub method to send a refresh message
		/// </summary>
		public const string SENDREFRESHMESSAGE = "SendRefreshMessage";

		/// <summary>
		/// Name of the Hub method to send a refresh message
		/// </summary>
		public const string SENDREFRESHTOKENMESSAGE = "SendRefreshTokenMessage";

	}

}
