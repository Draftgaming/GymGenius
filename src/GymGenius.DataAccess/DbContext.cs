using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.Versioning;

namespace GymGenius.DataAccess
{
    /// <summary>
    /// Provides database operations using OleDb for accessing an Access database.
    /// This class implements the <see cref="IDbContext"/> interface and is supported only on Windows.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class DbContext : IDbContext
    {
        #region *** Fields       ***
        // The underlying OleDbConnection used for database operations.
        private readonly OleDbConnection _connection;
        #endregion

        #region *** Constructors ***
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext"/> class.
        /// Configures the database connection using the Access database file located in the AppData directory.
        /// </summary>
        public DbContext()
        {
            // Construct the full path to the Access database file.
            var source = Path.Combine(Environment.CurrentDirectory, "AppData", "DataBase.accdb");

            // Initialize the OleDbConnection with the appropriate connection string.
            _connection = new OleDbConnection
            {
                ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={source}"
            };

            // Open the database connection.
            _connection.Open();
        }
        #endregion

        #region *** Properties   ***
        /// <summary>
        /// Gets the singleton instance of the <see cref="DbContext"/>.
        /// </summary>
        public static IDbContext Instance => new DbContext();
        #endregion

        #region *** Methods      ***
        /// <inheritdoc />
        public bool AddSqlData(string sql)
        {
            // Execute an INSERT SQL command using the helper method.
            return InvokeNonQuery(_connection, commandType: "INSERT", sql);
        }

        /// <inheritdoc />
        public bool AddSqlData(string sql, params (string Name, object Value)[] parameters)
        {
            // Execute an INSERT SQL command using the helper method.
            return InvokeNonQuery(_connection, commandType: "INSERT", sql, parameters);
        }

        /// <inheritdoc />
        public void CloseConnection()
        {
            // Close the database connection.
            _connection.Close();
        }

        /// <inheritdoc />
        public void OpenConnection()
        {
            // Open the database connection.
            _connection.Open();
        }

        /// <inheritdoc />
        public IDataReader ReadSqlData(string sql)
        {
            // Create a new OleDbCommand with the provided SQL query and assign the connection.
            using var command = new OleDbCommand(sql, _connection);

            // Execute the query and return the data reader.
            return command.ExecuteReader();
        }

        /// <inheritdoc />
        public IDataReader ReadSqlData(string sql, params (string Name, object Value)[] parameters)
        {
            // Create a new OleDbCommand with the provided SQL query and assign the connection.
            using var command = new OleDbCommand(sql, _connection);

            // Add any parameters to the command object.
            foreach (var (name, value) in parameters)
            {
                command.Parameters.AddWithValue(name, value);
            }

            // Execute the query and return the data reader.
            return command.ExecuteReader();
        }

        /// <inheritdoc />
        public object ReadValue(string sql)
        {
            // Create a new OleDbCommand with the provided SQL query and assign the connection.
            using var command = new OleDbCommand(sql, _connection);

            // Execute the query and return the value of the first column in the first row.
            return command.ExecuteScalar();
        }

        public object ReadValue(string sql, params (string Name, object Value)[] parameters)
        {
            // Create a new OleDbCommand with the provided SQL query and assign the connection.
            using var command = new OleDbCommand(sql, _connection);

            // Add any parameters to the command object.
            foreach (var (name, value) in parameters)
            {
                command.Parameters.AddWithValue(name, value);
            }

            // Execute the query and return the value of the first column in the first row.
            return command.ExecuteScalar();
        }

        /// <inheritdoc />
        public bool RemoveSqlData(string sql)
        {
            // Execute a DELETE SQL command using the helper method.
            return InvokeNonQuery(_connection, commandType: "DELETE", sql);
        }

        /// <inheritdoc />
        public void RestoreTransaction()
        {
            // Transaction restore functionality is not implemented.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void SaveSqlData()
        {
            // Transaction commit functionality is not implemented.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool UpdateSqlData(string sql)
        {
            // Execute an UPDATE SQL command using the helper method.
            return InvokeNonQuery(_connection, commandType: "UPDATE", sql);
        }

        /// <inheritdoc />
        public bool UpdateSqlData(string sql, params (string Name, object Value)[] parameters)
        {
            // Execute an UPDATE SQL command using the helper method.
            return InvokeNonQuery(_connection, commandType: "UPDATE", sql, parameters);
        }

        // Executes a non-query SQL command (such as INSERT, UPDATE, or DELETE) on the given connection.
        private static bool InvokeNonQuery(
            OleDbConnection connection, string commandType, string sql, params (string Name, object Value)[] parameters)
        {
            // Verify that the SQL command begins with the specified command type (case-insensitive).
            if (!sql.StartsWith(commandType, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            // Create a command object using the provided connection.
            // The 'using' statement ensures that the command is disposed after execution.
            using var command = connection.CreateCommand();

            // Add any parameters to the command object.
            foreach (var (name, value) in parameters)
            {
                command.Parameters.AddWithValue(name, value);
            }

            // Set the command text to the provided SQL statement.
            command.CommandText = sql;

            // Execute the command and return true if one or more rows are affected.
            return command.ExecuteNonQuery() > 0;
        }
        #endregion
    }
}
