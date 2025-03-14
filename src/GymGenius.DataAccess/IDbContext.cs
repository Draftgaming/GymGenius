using System.Collections.Generic;
using System.Data;

namespace GymGenius.DataAccess
{
    /// <summary>
    /// Defines the operations for a database context, providing methods for connection management,
    /// data manipulation, and transaction control.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Executes a SQL insert statement.
        /// </summary>
        /// <param name="sql">The SQL insert statement to execute.</param>
        /// <returns><c>true</c> if the insert was successful; otherwise, <c>false</c>.</returns>
        bool AddSqlData(string sql);

        /// <summary>
        /// Executes a SQL insert statement.
        /// </summary>
        /// <param name="sql">The SQL insert statement to execute.</param>
        /// <param name="parameters">
        /// An array of tuples, where each tuple contains a parameter name and its corresponding value.
        /// These parameters will be applied to the SQL statement.
        /// </param>
        /// <returns><c>true</c> if the insert was successful; otherwise, <c>false</c>.</returns>
        bool AddSqlData(string sql, params (string Name, object Value)[] parameters);

        /// <summary>
        /// Closes the current connection to the database.
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Executes a SQL query and returns an <see cref="IDataReader"/> for reading the results.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>An <see cref="IDataReader"/> instance for iterating through the result set.</returns>
        IDataReader ReadSqlData(string sql);

        /// <summary>
        /// Executes a SQL query statement and returns an <see cref="IDataReader"/> for reading the results.
        /// </summary>
        /// <param name="sql">The SQL query statement to execute.</param>
        /// <param name="parameters">
        /// An array of tuples, where each tuple contains a parameter name and its corresponding value.
        /// These parameters will be applied to the SQL query.
        /// </param>
        /// <returns>An <see cref="IDataReader"/> instance for iterating through the result set.</returns>
        IDataReader ReadSqlData(string sql, params (string Name, object Value)[] parameters);

        /// <summary>
        /// Executes a SQL query and returns the value of the first column of the first row in the result set.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <returns>An object representing the value retrieved from the query.</returns>
        object ReadValue(string sql);

        /// <summary>
        /// Executes a SQL query statement and returns the value of the first column of the first row in the result set.
        /// </summary>
        /// <param name="sql">The SQL query statement to execute.</param>
        /// <param name="parameters">
        /// An array of tuples, where each tuple contains a parameter name and its corresponding value.
        /// These parameters will be applied to the SQL query.
        /// </param>
        /// <returns>An object representing the value of the first column of the first row in the result set.</returns>
        object ReadValue(string sql, params (string Name, object Value)[] parameters);

        /// <summary>
        /// Executes a SQL delete statement.
        /// </summary>
        /// <param name="sql">The SQL delete statement to execute.</param>
        /// <returns><c>true</c> if the delete was successful; otherwise, <c>false</c>.</returns>
        bool RemoveSqlData(string sql);

        /// <summary>
        /// Rolls back the current database transaction.
        /// </summary>
        void RestoreTransaction();

        /// <summary>
        /// Commits the current database transaction.
        /// </summary>
        void SaveSqlData();

        /// <summary>
        /// Executes a SQL update statement.
        /// </summary>
        /// <param name="sql">The SQL update statement to execute.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        bool UpdateSqlData(string sql);

        /// <summary>
        /// Executes a SQL update statement.
        /// </summary>
        /// <param name="sql">The SQL update statement to execute.</param>
        /// <param name="parameters">
        /// An array of tuples, where each tuple contains a parameter name and its corresponding value.
        /// These parameters will be applied to the SQL statement.
        /// </param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        bool UpdateSqlData(string sql, params (string Name, object Value)[] parameters);
    }
}
