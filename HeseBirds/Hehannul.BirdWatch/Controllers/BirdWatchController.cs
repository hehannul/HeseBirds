using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hehannul.BirdWatch.Domain;
using Hehannul.BirdWatch.Models.BirWatchViewModels;
using Hehannul.BirdWatch.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hehannul.BirdWatch.Controllers
{
    public class BirdWatchController : Controller
    {
        private readonly IBirdWatchService _birdWatchService;
        private readonly ILogger _logger;

        public BirdWatchController(
            IBirdWatchService birdWatchService,
            ILoggerFactory loggerFactory)
        {
            _birdWatchService = birdWatchService;
            _logger = loggerFactory.CreateLogger<BirdWatchController>();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation($"Listing all birds watched.");
            var birds = await _birdWatchService.ListAllBirdsAsync();
            var viewModel = new IndexViewModel();
            var birdList = new List<Bird>();
            foreach (var item in birds)
            {
                birdList.Add(item);
            }
            viewModel.Birds = birdList;
            return View(viewModel);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWatch(string birdType)
        {
            _logger.LogInformation($"Uuden havainnon lisäys");
            try
            {
                await _birdWatchService.AddBirdAsunc(birdType);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError($"Havainnoin lisäys epäonnistui: Exception: {e}");
                return RedirectToAction("Index");
            }
        }
            
        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation($"Lisää uusi laji.");
            return View(new CreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            _logger.LogInformation($"Lisää uusi lintulaji");
            if (ModelState.IsValid)
            {
                try
                {
                    await _birdWatchService.CreateBirdAsync(model.BirdName);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogError($"Uuden lajin liäsys epäonnistui: Exception: {e}");
                    return RedirectToAction("Index");
                }

            }

            _logger.LogWarning($"ModelState is not valid.");
            return View(model);
        }
    }
}