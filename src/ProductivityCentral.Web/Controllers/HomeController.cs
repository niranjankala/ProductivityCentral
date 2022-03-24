using ProductivityCentral.Logging;
using ProductivityCentral.Web.Models;
using ProductivityCentral.Web.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCentral.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IOperatorReportService _operatorReportService;
        public ILogger Logger { get; set; }
        public HomeController(IOperatorReportService operatorReportService)
        {
            _operatorReportService = operatorReportService;
            Logger = NullLogger.Instance;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OperatorReport()
        {
            ViewBag.Message = "Operator Productivity Report";
            OperatorReportItems ProductivityReport = _operatorReportService.GetOperatorReportItems();
            return View(ProductivityReport);
        }

        public ActionResult OperatorProductivityData()
        {
            return View();
        }
    }
}