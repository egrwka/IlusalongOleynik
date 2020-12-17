using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OleynikProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime StartTime { get; set; }
        public string StartTime2 { get; set; }
        public Services Services { get; set; }
    }
}