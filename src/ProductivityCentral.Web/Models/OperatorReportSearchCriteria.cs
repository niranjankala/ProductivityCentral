using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name ="From date:")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [Display(Name = "To date:")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime? ToDate { get; set; }
        [Display(Name = "Websites:")]
        public string SelectedWebsites { get; set; }
        [Display(Name = "Devices:")]

        public string SelectedDevices { get; set; }
        [Display(Name = "Date Filter:")]
        public DateFilterType DateFilter { get; set; }
        [Display(Name = "Filter By:")]
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