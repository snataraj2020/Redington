using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedingtonCalculator.Domain;
using RedingtonCalculator.Web.Models;

namespace RedingtonCalculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculationModel calculationModel)
        {
            ViewData["Message"] = "Select your calculation type and provide two probabilities...";

            // Ensure that subsequent don't mislead by showing old results.
            calculationModel.Output = null;

            if (ModelState.IsValid)
            {
                var result = _calculatorService.PerformCalculation(calculationModel.Type, calculationModel.Probability1, calculationModel.Probability2);

                if (result.Success)
                {
                    calculationModel.Output = result.Output;
                    return View(calculationModel);
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("CalculationFailure", error);
                    }
                }
            }

            return View(calculationModel);
        }

        [HttpGet]
        public IActionResult History()
        {
            ViewData["Message"] = "The history of the calculations performed";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
