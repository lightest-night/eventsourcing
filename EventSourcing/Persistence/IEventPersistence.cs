using System.Threading;
using System.Threading.Tasks;
using LightestNight.EventSourcing.Domain;

namespace LightestNight.EventSourcing.Persistence
{
    public interface IEventPersistence
    {
        /// <summary>
        /// Gets an <see cref="IEventSourceAggregate" /> object from the persistence store by it's identifier
        /// </summary>
        /// <param name="id">The Globally Unique Identifier of the <see cref="IEventSourceAggregate" /> object</param>
        /// <param name="cancellationToken">Any <see cref="CancellationToken" /> needed to marshal the operation</param>
        /// <typeparam name="TAggregate">The type of the <see cref="IEventSourceAggregate" /> to retrieve</typeparam>
        /// <typeparam name="TId">The type of the Aggregate identifier</typeparam>
        /// <returns>A populated instance of <see cref="IEventSourceAggregate" /></returns>
        Task<TAggregate> GetById<TAggregate, TId>(TId id, CancellationToken cancellationToken = default)
            where TAggregate : class, IEventSourceAggregate;

        /// <summary>
        /// Writes the given <see cref="IEventSourceAggregate" /> object to the persistence store
        /// </summary>
        /// <param name="aggregate">The <see cref="IEventSourceAggregate" /> to write</param>
        /// <param name="cancellationToken">Any <see cref="CancellationToken" /> needed to marshal the operation</param>
        Task Save(IEventSourceAggregate aggregate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Parses the <see cref="IEventSourceAggregate" /> instance to determine what the Stream Id should be
        /// </summary>
        /// <param name="aggregate">The <see cref="IEventSourceAggregate" /> to parse</param>
        /// <returns>The Stream Id</returns>
        string GetStreamId(IEventSourceAggregate aggregate);
    }
}