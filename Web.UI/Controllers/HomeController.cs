using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NumberConverter.Service;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INumberToWordsConverter _numberConverterService;

        public HomeController(INumberToWordsConverter numberConverterService)
        {
            _numberConverterService = numberConverterService;
        }

        public ActionResult Index()
        {
            return View(new ConvertNumberViewModel());
        }

        [HttpPost]
        public ActionResult Index(ConvertNumberViewModel model)
        {
            try
            {
                var amount = _numberConverterService.ConvertToWords(model.Amount);
                model.Output = model.Name.ToUpper() + ": " + amount;
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Amount", ex.Message);
                return View(model);
            }
            
        }

       
    }
}