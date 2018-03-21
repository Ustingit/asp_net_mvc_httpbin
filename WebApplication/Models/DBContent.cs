using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DBContent
    {
        public int Id { get; set; }

        public int CommonResponseTime { get; set; }

        public int DelayedResponseTime { get; set; }
    }
}