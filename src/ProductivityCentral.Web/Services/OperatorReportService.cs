using ProductivityCentral.Environment.Configuration;
using ProductivityCentral.Logging;
using ProductivityCentral.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCentral.Web.Services
{
    public interface IOperatorReportService
    {
        OperatorReportItems GetOperatorReportItems(OperatorReportSearchCriteria searchCriteria);
        string[] GetPredefinedFilters();
        IEnumerable<SelectListItem> GetPredefinedFiltersListItems(string preDefinedFilter);
        IEnumerable<SelectListItem> GetWebsitesListItems(string selectedWebsites);
        IEnumerable<SelectListItem> GetDevicesListItems(string selectedWebsites);
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
        public OperatorReportItems GetOperatorReportItems(OperatorReportSearchCriteria searchCriteria)
        {
            OperatorReportItems productivityReport = new OperatorReportItems();
            productivityReport.OperatorProductivity = new List<OperatorReportViewModel>();

            using (SqlConnection conn = new SqlConnection(_configurationAccessor.GetConfiguration("Default")))
            {
                using (SqlCommand sqlcomm = new SqlCommand("dbo.OperatorProductivity", conn))
                {
                    sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcomm.Parameters.AddWithValue("@dateFilterType", searchCriteria.DateFilter.ToString());
                    sqlcomm.Parameters.AddWithValue("@dateFilter", searchCriteria.PreDefinedFilter);
                    sqlcomm.Parameters.AddWithValue("@fromDate", searchCriteria.FromDate);
                    sqlcomm.Parameters.AddWithValue("@toDate", searchCriteria.ToDate);
                    sqlcomm.Parameters.AddWithValue("@websites", searchCriteria.SelectedWebsites);
                    sqlcomm.Parameters.AddWithValue("@devices", searchCriteria.SelectedDevices);
                    conn.Open();
                    SqlDataReader dr = sqlcomm.ExecuteReader();
                    while (dr.Read())
                    {
                        OperatorReportViewModel opVM = new Models.OperatorReportViewModel();
                        opVM.ID = Convert.ToInt32(dr[0]);
                        opVM.Name = Convert.ToString(dr[1]);
                        opVM.ProactiveSent = Convert.ToInt32(dr[2]);
                        opVM.ProactiveAnswered = Convert.ToInt32(dr[3]);
                        opVM.ProactiveResponseRate = Convert.ToInt32(dr[4]);
                        opVM.ReactiveReceived = Convert.ToInt32(dr[5]);
                        opVM.ReactiveAnswered = Convert.ToInt32(dr[6]);
                        opVM.ReactiveResponseRate = Convert.ToInt32(dr[7]);
                        opVM.TotalChatLength = Convert.ToString(dr[8]);
                        opVM.AverageChatLength = Convert.ToString(dr[9]);
                        productivityReport.OperatorProductivity.Add(opVM);
                    }
                }
            }
            return productivityReport;
        }
        public string[] GetPredefinedFilters()
        {
            string[] predefinedFilters = _configurationAccessor.GetConfiguration("PredefinedFilters").Split(',');
            return predefinedFilters;
        }


        public string[] GetWebsites()
        {
            List<string> websites = new List<string>();
            using (SqlConnection conn = new SqlConnection(_configurationAccessor.GetConfiguration("Default")))
            {
                using (SqlCommand sqlcomm = new SqlCommand("SELECT DISTINCT Website FROM Conversation WHERE Website IS NOT NULL AND Website <>''", conn))
                {
                    conn.Open();
                    SqlDataReader dr = sqlcomm.ExecuteReader();
                    while (dr.Read())
                    {
                        websites.Add(Convert.ToString(dr[0]));
                    }
                }
            }
            return websites.ToArray();
        }


        public string[] GetUsedDevices()
        {
            List<string> devices = new List<string>();
            using (SqlConnection conn = new SqlConnection(_configurationAccessor.GetConfiguration("Default")))
            {
                using (SqlCommand sqlcomm = new SqlCommand("SELECT DISTINCT Device FROM Visitor WHERE Device IS NOT NULL AND Device <>''", conn))
                {
                    conn.Open();
                    SqlDataReader dr = sqlcomm.ExecuteReader();
                    while (dr.Read())
                    {
                        devices.Add(Convert.ToString(dr[0]));
                    }
                }
            }
            return devices.ToArray();
        }


        public IEnumerable<SelectListItem> GetPredefinedFiltersListItems(string searchPreDefinedFilter)
        {
            string[] predefinedFilters = GetPredefinedFilters();
            var predefinedFiltersList = predefinedFilters.Select(p => new SelectListItem() { Text = p, Value = p, Selected = searchPreDefinedFilter == p }).ToList();
            predefinedFiltersList.Insert(0, new SelectListItem() { Text = "--Select--", Value = null, Selected = string.IsNullOrEmpty(searchPreDefinedFilter) });

            return predefinedFiltersList;
        }
        public IEnumerable<SelectListItem> GetWebsitesListItems(string selectedWebsites)
        {
            string[] websites = GetWebsites();
            List<SelectListItem> websitesList = websites.Select(p => new SelectListItem() { Text = p, Value = p, Selected = selectedWebsites == p }).ToList();
            websitesList.Insert(0, new SelectListItem() { Text = "ALL WEBSITES", Value = null, Selected = string.IsNullOrEmpty(selectedWebsites) });
            return websitesList;
        }
        public IEnumerable<SelectListItem> GetDevicesListItems(string selectedDevices)
        {
            string[] usedDevices = GetUsedDevices();
            List<SelectListItem> devicesList = usedDevices.Select(p => new SelectListItem() { Text = p, Value = p, Selected = selectedDevices == p }).ToList();
            devicesList.Insert(0, new SelectListItem() { Text = "ALL DEVICES", Value = null, Selected = string.IsNullOrEmpty(selectedDevices) });
            return devicesList;
        }
    }
}