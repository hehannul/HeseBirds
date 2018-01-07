using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hehannul.BirdWatch.Services
{
    public class BirdWatchService : IBirdWatchService
    {
        private Dictionary<string, int> _birdsDictionary =
            new Dictionary<string, int>();

        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdWatchService"/> class.
        /// </summary>
        public BirdWatchService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BirdWatchService>();
            InitBirds();
        }

        /// <summary>
        /// Gets the amount of birds asunc.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        /// <returns></returns>
        public async Task<int> GetAmountOfBirdsAsunc(string birdType)
        {
            _logger.LogInformation($"{birdType} havainnot");
            return await Task.Run(() => _birdsDictionary.ContainsKey(birdType) ? _birdsDictionary[birdType] : 0);
        }

        /// <summary>
        /// Adds the bird asunc.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        /// <returns></returns>
        public async Task AddBirdAsunc(string birdType)
        {
            _logger.LogInformation($"{birdType} havaittu");
            var birdCount = _birdsDictionary.ContainsKey(birdType) ? _birdsDictionary[birdType] : 0;
            await Task.Run(() => _birdsDictionary[birdType] = birdCount + 1);
            NewWatchToLog(birdType);
        }

        /// <summary>
        /// Initializes the birds.
        /// </summary>
        private void InitBirds()
        {
            _birdsDictionary.Add("Varis", 0);
            _birdsDictionary.Add("Harakka", 0);
        }

        /// <summary>
        /// News the watch to log.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        private void NewWatchToLog(string birdType)
        {
            var crows = _birdsDictionary.ContainsKey("Varis") ? _birdsDictionary["Varis"] : 0;
            var picas = _birdsDictionary.ContainsKey("Harakka") ? _birdsDictionary["Harakka"] : 0;
            var date = DateTime.Now;
            _logger.LogInformation($"{date} 5 – uusi havainto: {birdType}" +
                $"– kaikki havainnot: varis {crows} kpl, harakka {picas} kpl");
        }
    }
}
