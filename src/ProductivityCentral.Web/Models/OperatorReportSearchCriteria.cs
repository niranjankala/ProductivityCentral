using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductivityCentral.Web.Models
{
    public class OperatorReportSearchCriteria
    {
        public OperatorReportSearchCriteria()
        {
           
        }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SelectedWebsites { get; set; }
        public string SelectedDevices { get; set; }
       public DateFilterType DateFilter { get; set; }
        public string PreDefinedFilter { get; set; }

        public IEnumerable<SelectListItem> PreDefinedFilters { get; set; }
        public IEnumerable<SelectListItem> WebsitesList { get; set; }
        public IEnumerable<SelectListItem> DevicesList { get; set; }
    }
    public enum DateFilterType
    {
        PreDefined,
        Custom
    }
}