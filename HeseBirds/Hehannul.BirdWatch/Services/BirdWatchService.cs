using Hehannul.BirdWatch.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hehannul.BirdWatch.Services
{
    public class BirdWatchService : IBirdWatchService
    {
        private static Dictionary<string, int> _birdsDictionary =
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
        /// Creates the bird asynchronous.
        /// </summary>
        /// <param name="birdName">Name of the bird.</param>
        /// <returns></returns>
        public async Task CreateBirdAsync(string birdName)
        {
            var date = DateTime.Now;
            if (_birdsDictionary.ContainsKey(birdName) == false)
            {
                await Task.Run(() => _birdsDictionary.Add(birdName, 0));
                _logger.LogInformation($"{date} 5 – lajin lisäys: {birdName}");
            }
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
        /// Lists all birds asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Bird>> ListAllBirdsAsync()
        {
            List<Bird> birds = new List<Bird>();
            foreach (var bird in _birdsDictionary)
            {
                birds.Add(new Bird()
                {
                    Name = bird.Key,
                    WatchCount = bird.Value
                });
            }
            _logger.LogInformation($"Kaikki linnut");
            return await Task.Run(() => birds);
        }

        /// <summary>
        /// Initializes the birds.
        /// </summary>
        private void InitBirds()
        {
            if (_birdsDictionary.ContainsKey("Varis") == false)
            {
                _birdsDictionary.Add("Varis", 0);
            }
            if (_birdsDictionary.ContainsKey("Harakka") == false)
            {
                _birdsDictionary.Add("Harakka", 0);
            }
        }

        /// <summary>
        /// News the watch to log.
        /// </summary>
        /// <param name="birdType">Type of the bird.</param>
        private void NewWatchToLog(string birdType)
        {
            var birdsText = string.Empty;
            foreach (var item in _birdsDictionary)
            {
                birdsText += item.Key;
                birdsText += " ";
                birdsText += item.Value;
                birdsText += " kpl ";
            }
            var date = DateTime.Now;
            _logger.LogInformation($"{date} 5 – uusi havainto: {birdType}" +
                $"– kaikki havainnot: {birdsText}");
        }
    }
}
