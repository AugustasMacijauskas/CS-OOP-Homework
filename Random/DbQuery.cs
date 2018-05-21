using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EasyReviews.Database.Data
{
    /// <summary>
    /// Represents database actions
    /// </summary>
    public sealed class DbQuery
    {
        /// <summary>
        /// Formated query
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        /// Query parameters
        /// </summary>
        public Dictionary<string, object> Parameters { get; private set; }

        /// <summary>
        /// Database connection
        /// </summary>
        private readonly DbContext dbContext;

        public DbQuery()
        {
            this.dbContext = DbContext.Instance;
            this.Parameters = new Dictionary<string, object>();
            this.Query = "";
        }

        /// <summary>
        /// Forms select statement
        /// </summary>
        public DbQuery Select()
        {
            this.Query = "SELECT * ";
            return this;
        }

        /// <summary>
        /// Forms select statement with specified columns
        /// </summary>
        /// <param name="selections">Columns</param>
        public DbQuery Select(string selections)
        {
            this.Query = $"SELECT {selections} ";
            return this;
        }

        /// <summary>
        /// Forms select statement with rows to fetch count
        /// </summary>
        /// <param name="count">Count</param>
        public DbQuery Select(int count)
        {
            this.Query = $"SELECT TOP {count} * ";
            return this;
        }

        /// <summary>
        /// Forms select statement with rows to fetch count and specified columns
        /// </summary>
        /// <param name="count">Count</param>
        /// <param name="selections">Columns</param>
        public DbQuery Select(int count, string selections)
        {
            this.Query = $"SELECT TOP {count} {selections} ";
            return this;
        }

        /// <summary>
        /// Forms select distinct statement
        /// </summary>
        public DbQuery SelectDistinct()
        {
            this.Query = "SELECT DISTINCT * ";
            return this;
        }

        /// <summary>
        /// Forms select distinct statement with specified columns
        /// </summary>
        /// <param name="selections">Columns</param>
        public DbQuery SelectDistinct(string selections)
        {
            this.Query = $"SELECT DISTINCT {selections} ";
            return this;
        }

        /// <summary>
        /// Forms select distinct statement with specified columns and rows to fetch count
        /// </summary>
        /// <param name="selections">Columns</param>
        /// <param name="count">Count</param>
        /// <returns></returns>
        public DbQuery SelectDistinct(string selections, int count)
        {
            this.Query = $"SELECT DISTINCT TOP {count} {selections} ";
            return this;
        }

        /// <summary>
        /// Forms from statement
        /// </summary>
        /// <param name="table">Table name</param>
        public DbQuery From(string table)
        {
            this.Query += $"FROM {table} ";
            return this;
        }

        /// <summary>
        /// Forms where statement
        /// </summary>
        /// <param name="clause">Condition</param>
        /// <returns></returns>
        public DbQuery Where(string clause)
        {
            this.Query += $"WHERE {clause} ";
            return this;
        }

        /// <summary>
        /// Forms insert statement
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="columns">Insert columns</param>
        /// <returns></returns>
        public DbQuery Insert(string table, string columns)
        {
            string values = String.Join(", ", columns.Replace(" ", "").Split(',').Select(x => "@" + x));
            this.Query += $"INSERT INTO {table} ({columns}) VALUES ({values}) ";
            return this;
        }

        /// <summary>
        /// Forms update statement
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="clause">Clause</param>
        /// <returns></returns>
        public DbQuery Update(string table, string clause)
        {
            clause = String.Join(", ", clause.Replace(" ", "").Split(',').Select(x => x + "  = @" + x));
            this.Query += $"UPDATE {table} SET {clause} ";
            return this;
        }

        /// <summary>
        /// Forms order by statement
        /// </summary>
        /// <param name="column">Column</param>
        /// <param name="descending">Descending</param>
        public DbQuery OrderBy(string column, bool descending = false)
        {
            string order = descending ? "DESC " : "";
            this.Query += $"ORDER BY {column} {order}";
            return this;
        }

        /// <summary>
        /// Forms order by statement
        /// </summary>
        /// <param name="query">Order query</param>
        public DbQuery OrderBy(string query)
        {
            this.Query += $"ORDER BY {query} ";
            return this;
        }

        /// <summary>
        /// Forms join statement
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="clause">Clause</param>
        public DbQuery Join(string table, string clause)
        {
            this.Query += $"JOIN {table} ON {clause} ";
            return this;
        }

        /// <summary>
        /// Forms offset statement
        /// </summary>
        /// <param name="count">Rows count</param>
        public DbQuery Offset(int count)
        {
            this.Query += $"OFFSET {count} ROWS ";
            return this;
        }

        /// <summary>
        /// Forms fetch next statement
        /// </summary>
        /// <param name="count">Rows count</param>
        public DbQuery FetchNext(int count)
        {
            this.Query += $"FETCH NEXT {count} ROWS ONLY ";
            return this;
        }

        /// <summary>
        /// Adds query parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbQuery AddParameter(string name, object value)
        {
            this.Parameters.Add(name, value);
            return this;
        }

        /// <summary>
        /// Executes query
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="selector">Return type selector</param>
        public IEnumerable<T> Execute<T>(Func<IDataReader, T> selector)
        {
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                
                this.Parameters.Clear();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return selector(reader);
                }
            }
            this.Query = "";
        }

        /// <summary>
        /// Executes query async
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="selector">Return type selector</param>
        public async Task<IEnumerable<T>> ExecuteAsync<T>(Func<IDataReader, T> selector)
        {
            List<T> collection = new List<T>();
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);

                this.Parameters.Clear();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                        collection.Add(selector(reader));
                }
            }
            this.Query = "";
            return collection;
        }

        /// <summary>
        /// Executes single row query
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="selector">Return type selector</param>
        public T ExecuteSingle<T>(Func<IDataReader, T> selector)
        {
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                this.Parameters.Clear();

                this.Query = "";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return selector(reader);
                    }
                    else return default(T);
                }
            }
        }

        /// <summary>
        /// Executes single row query async
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="selector">Return type selector</param>
        public async Task<T> ExecuteSingleAsync<T>(Func<IDataReader, T> selector)
        {
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                this.Parameters.Clear();

                this.Query = "";
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return selector(reader);
                    }
                    else return default(T);
                }
            }
        }

        /// <summary>
        /// Executes non query
        /// </summary>
        public void ExecuteNonQuery()
        {
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                this.Parameters.Clear();

                this.Query = "";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes non query async
        /// </summary>
        public async Task ExecuteNonQueryAsync()
        {
            using (SqlCommand command = new SqlCommand(this.Query, this.dbContext.DbConnection))
            {
                foreach (var pair in this.Parameters)
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                this.Parameters.Clear();

                this.Query = "";
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
