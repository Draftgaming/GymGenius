using System.Collections.Generic;
using System.Data;
using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Text.Json;

namespace GymGenius.Domain.Extensions
{
    /// <summary>
    /// Provides extension methods for various operations.
    /// </summary>
    public static class PublicExtension
    {
        private static readonly JsonSerializerOptions s_jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static List<T> GetEntities<T>(this IDataReader reader)
        {
            // Create a list to store the entities.
            var entities = new List<T>();

            // Iterate through each row in the result set.
            while (reader.Read())
            {
                // Create a dictionary to store the column data.
                var rowData = new Dictionary<string, object>();

                // Read each column in the current row into the dictionary.
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string key = reader.GetName(i);
                    rowData[key] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                }

                // Serialize the dictionary to JSON using System.Text.Json.
                string json = JsonSerializer.Serialize(rowData);

                // Deserialize the JSON string to the specified entity type.
                T entity = JsonSerializer.Deserialize<T>(json, s_jsonOptions);

                // Add the entity to the list.
                entities.Add(entity);
            }

            // Return the list of entities.
            return entities;
        }
    }
}
