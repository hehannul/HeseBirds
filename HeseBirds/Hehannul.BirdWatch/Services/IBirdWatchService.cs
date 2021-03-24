using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hehannul.BirdWatch.Services
{
    public interface IBirdWatchService
    {
        /// <summary>
        /// Lists all birds asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Domain.Bird>> ListAllBirdsAsync();

        /// <summary>
        /// Creates the bird asynchronous.
        /// </summary>
        /// <param name="birdName">Name of the bird.</param>
        /// <returns></returns>
        Task CreateBirdAsync(string birdName);

      
        /// <summary>
        /// Adds the bird asunc.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        /// <returns></returns>
        Task AddBirdAsunc(string birdType);
    }
}
