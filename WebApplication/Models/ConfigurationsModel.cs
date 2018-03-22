using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication.Models
{
    public class ConfigurationsModel
    {
        private static ConfigurationsModel _instance;

        public static ConfigurationsModel Instance => _instance ?? (_instance = new ConfigurationsModel());

        public int ResponseDuration { get; set; } = 10;
    }
}