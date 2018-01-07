using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var crows = await _birdWatchService.GetAmountOfBirdsAsunc("Varis");
            var picas = await _birdWatchService.GetAmountOfBirdsAsunc("Harakka");
            var viewModel = new IndexViewModel()
            {
                NumberOfHoodedCrows = crows,
                NumberOfPicaPicas = picas
            };
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
    }
}