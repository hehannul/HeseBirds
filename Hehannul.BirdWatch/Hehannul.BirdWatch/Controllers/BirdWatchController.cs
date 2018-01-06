using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hehannul.BirdWatch.Models.BirWatchViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hehannul.BirdWatch.Controllers
{
    public class BirdWatchController : Controller
    {
        private readonly ILogger _logger;

        public BirdWatchController(
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BirdWatchController>();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation($"Listing all birds watched.");
            var viewModel = new IndexViewModel()
            {
                NumberOfHoodedCrows = 0,
                NumberOfPicaPicas = 0
            };
            return View(viewModel);
        }
    }
}