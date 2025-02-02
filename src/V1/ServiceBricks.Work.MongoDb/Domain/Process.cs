using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ServiceBricks.Storage.MongoDb;
using System.Linq.Expressions;

namespace ServiceBricks.Work.MongoDb
{
    /// <summary>
    /// The Process domain object.
    /// </summary>
    public partial class Process : MongoDbDomainObject<Process> , IDpCreateDate, IDpUpdateDate
    {
        /// <summary>
        /// Internal Primary Key.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Key { get; set; }

        
        /// <summary>
        /// This is the create date.
        /// </summary>
        public DateTimeOffset CreateDate { get; set; }

        /// <summary>
        /// This is the update date.
        /// </summary>
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// The queue name.
        /// </summary>
        public string ProcessQueue { get; set; }

        /// <summary>
        /// The work type.
        /// </summary>
        public string ProcessType { get; set; }

        /// <summary>
        /// The work details.
        /// </summary>
        public string ProcessData { get; set; }

        /// <summary>
        /// Determine if completed processing.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Determine if an error occured.
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Determine if currently processing.
        /// </summary>
        public bool IsProcessing { get; set; }

        /// <summary>
        /// The retry count.
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// The processing date.
        /// </summary>
        public DateTimeOffset ProcessDate { get; set; }

        /// <summary>
        /// The future processing date.
        /// </summary>
        public DateTimeOffset FutureProcessDate { get; set; }

        /// <summary>
        /// The process response.
        /// </summary>
        public string ProcessResponse { get; set; }


        /// <summary>
        /// Provide an expression that will filter an object based on its primary key.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Expression<Func<Process, bool>> DomainGetItemFilter(Process obj)
        {
            return x => x.Key == obj.Key;
        }
    }
}
