namespace ServiceBricks.Work.Postgres
{
    /// <summary>
    /// Constants for the WorkPostgres module.
    /// </summary>
    public static partial class WorkPostgresConstants
    {
        /// <summary>
        /// Application setting for the connection string.
        /// </summary>
        public const string APPSETTING_CONNECTION_STRING = "ServiceBricks:Work:Storage:Postgres:ConnectionString";

        /// <summary>
        /// The name of the database schema.
        /// </summary>
        public const string DATABASE_SCHEMA_NAME = "Work";
    }
}
