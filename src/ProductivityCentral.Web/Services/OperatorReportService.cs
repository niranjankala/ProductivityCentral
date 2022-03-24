using ProductivityCentral.Environment.Configuration;
using ProductivityCentral.Logging;
using ProductivityCentral.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductivityCentral.Web.Services
{
    public interface IOperatorReportService
    {
        OperatorReportItems GetOperatorReportItems();
    }
    public class OperatorReportService : IOperatorReportService
    {
        readonly IAppConfigurationAccessor _configurationAccessor;
        public ILogger Logger { get; set; }

        public OperatorReportService(IAppConfigurationAccessor configurationAccessor)
        {
            _configurationAccessor = configurationAccessor;
            Logger = NullLogger.Instance;
        }
        public OperatorReportItems GetOperatorReportItems()
        {
            OperatorReportItems productivityReport = new OperatorReportItems();
            productivityReport.OperatorProductivity = new List<OperatorReportViewModel>();

            using (SqlConnection conn = new SqlConnection(_configurationAccessor.GetConfiguration("Default")))
            {
                using (SqlCommand sqlcomm = new SqlCommand("exec dbo.OperatorProductivity ", conn))
                {
                    conn.Open();
                    SqlDataReader dr = sqlcomm.ExecuteReader();
                    while (dr.Read())
                    {
                        OperatorReportViewModel opVM = new Models.OperatorReportViewModel();
                        opVM.ID = Convert.ToInt32(dr[0]);
                        opVM.Name = Convert.ToString(dr[1]);
                        opVM.ProactiveAnswered = Convert.ToInt32(dr[2]);
                        opVM.ProactiveSent = Convert.ToInt32(dr[3]);
                        opVM.ProactiveResponseRate = Convert.ToInt32(dr[4]);
                        opVM.ReactiveAnswered = Convert.ToInt32(dr[5]);
                        opVM.ReactiveReceived = Convert.ToInt32(dr[6]);
                        opVM.ReactiveResponseRate = Convert.ToInt32(dr[7]);
                        opVM.AverageChatLength = Convert.ToString(dr[8]);
                        opVM.TotalChatLength = Convert.ToString(dr[9]);
                        productivityReport.OperatorProductivity.Add(opVM);
                    }
                }
            }
            return productivityReport;
        }
    }
}