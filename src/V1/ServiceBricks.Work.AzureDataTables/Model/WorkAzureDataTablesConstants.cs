namespace ServiceBricks.Work.AzureDataTables
{
    /// <summary>
    /// Constants for the WorkAzureDataTables module.
    /// </summary>
    public static partial class WorkAzureDataTablesConstants
    {
        /// <summary>
        /// AppSetting key for the connection string.
        /// </summary>
        public const string APPSETTING_CONNECTION_STRING = "ServiceBricks:Work:Storage:AzureDataTables:ConnectionString";

        /// <summary>
        /// Table name prefix for the module.
        /// </summary>
        public const string TABLENAME_PREFIX = "Work";

        /// <summary>
        /// Get a table name for the module.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetTableName(string tableName)
        {
            return TABLENAME_PREFIX + tableName;
        }
    }
}
