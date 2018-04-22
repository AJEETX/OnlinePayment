using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stripe.Domain;
using stripe.Models;
using Stripe;

namespace stripe.Controllers
{
    public class HomeController : Controller
    {
        IPaymentService _IPaymentService;
        public HomeController(IPaymentService IPaymentService)
        {
            _IPaymentService = IPaymentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Transact(string stripeEmail, string stripeToken)
        {
            _IPaymentService.Pay(stripeEmail, stripeToken);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
