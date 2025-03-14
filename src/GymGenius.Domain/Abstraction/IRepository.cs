using System.Collections.Generic;

namespace GymGenius.Domain.Abstraction
{
    /// <summary>
    /// Defines a generic repository interface for managing entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity type for the repository.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity that matches the given identifier, or <c>null</c> if not found.</returns>
        T Get(string id);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns><c>true</c> if the entity was added successfully; otherwise, <c>false</c>.</returns>
        bool NewEntity(T entity);

        /// <summary>
        /// Removes an entity from the repository using the entity instance.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns><c>true</c> if the entity was removed successfully; otherwise, <c>false</c>.</returns>
        bool RemoveEntity(T entity);

        /// <summary>
        /// Removes an entity from the repository using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to remove.</param>
        /// <returns><c>true</c> if the entity was removed successfully; otherwise, <c>false</c>.</returns>
        bool RemoveEntity(string id);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns><c>true</c> if the entity was updated successfully; otherwise, <c>false</c>.</returns>
        bool UpdateEntity(T entity);
    }
}
