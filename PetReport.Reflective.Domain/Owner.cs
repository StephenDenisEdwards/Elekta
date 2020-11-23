using System;
using PetReport.Reflective.Lib;

namespace PetReport.Reflective.Domain
{
    public class Owner : ReportableReflective
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime JoinedPractice { get; set; }
    }
}