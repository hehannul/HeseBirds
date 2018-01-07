using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hehannul.BirdWatch.Services
{
    public interface IBirdWatchService
    {
        /// <summary>
        /// Gets the amount of birds asunc.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        /// <returns></returns>
        Task<int> GetAmountOfBirdsAsunc(string birdType);

        /// <summary>
        /// Adds the bird asunc.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        /// <returns></returns>
        Task AddBirdAsunc(string birdType);
    }
}
