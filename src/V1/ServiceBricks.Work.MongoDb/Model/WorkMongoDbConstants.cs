namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// Constants for the WorkMongoDb module.
    /// </summary>
    public static partial class WorkMongoDbConstants
    {
        /// <summary>
        /// Application setting for the connection string.
        /// </summary>
        public const string APPSETTING_CONNECTION_STRING = "ServiceBricks:Work:Storage:MongoDb:ConnectionString";

        /// <summary>
        /// Application setting for the database name.
        /// </summary>
        public const string APPSETTING_DATABASE = "ServiceBricks:Work:Storage:MongoDb:Database";

        /// <summary>
        /// The prefix for the collection name.
        /// </summary>
        public const string COLLECTIONNAME_PREFIX = "Work";

        /// <summary>
        /// Get the collection name for the given table name.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetCollectionName(string tableName)
        {
            return COLLECTIONNAME_PREFIX + tableName;
        }
    }
}
