using System.Data.SqlClient;

namespace EasyReviews.Database.Data
{
    /// <summary>
    /// Singleton database connection instance
    /// </summary>
    public sealed class DbContext
    {
        /// <summary>
        /// Database connection
        /// </summary>
        public SqlConnection DbConnection { get; private set; }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static DbContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new DbContext();
                return instance;
            }
        }

        private static DbContext instance;
        
        private DbContext()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location + @"\..\EasyReviewsDatabase.mdf";
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;Database=EasyReviewsDatabase;AttachDbFilename={path};Integrated Security=True;";
            DbConnection = new SqlConnection(connectionString);
            DbConnection.Open();
        }
    }
}