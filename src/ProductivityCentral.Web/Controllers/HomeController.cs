using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCentral.Web.Controllers
{
    public class HomeController : Controller
    {
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
            OperatorReportItems ProductivityReport = new OperatorReportItems();
            ProductivityReport.OperatorProductivity = new OperatorReportViewModel();

            ViewBag.Message = "Operator Productivity Report";
            SqlConnection conn = SqlConnection("Data Source=FAISALHABIB\\SQLEXPRESS;Initial Catalog=chat;User id=chat;Password=chat;");
            SqlCommand sqlcomm = SqlCommand("exec dbo.OperatorProductivity ", conn);
            conn.Open();
            SqlDataReader dr = sqlcomm.ExecuteReader();
            if (dr.Read())
            {
                OperatorReportViewModel opVM = new Models.OperatorReportViewModel();
                opVM.ID = Convert.ToInt32(dr[1]);
                opVM.Name = Convert.ToString(dr[0]);
                opVM.ProactiveAnswered = Convert.ToInt32(dr[2]);
                opVM.ProactiveSent = Convert.ToInt32(dr[3]);
                opVM.ProactiveResponseRate = Convert.ToInt32(dr[4]);
                opVM.ReactiveAnswered = Convert.ToInt32(dr[5]);
                opVM.ReactiveReceived = Convert.ToInt32(dr[6]);
                opVM.ReactiveResponseRate = Convert.ToInt32(dr[7]);
                opVM.AverageChatLength = Convert.ToString(dr[8]);
                opVM.TotalChatLength = Convert.ToString(dr[9]);
                ProductivityReport.OperatorProductivity.Add(opVM);
            }

            return View(ProductivityReport.OperatorProductivity);
        }

        public ActionResult OperatorProductivityData()
        {
            return View();
        }
    }
}