using System;
using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic.Domain
{
    public class Owner : Reportable
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime JoinedPractice { get; set; }
    }
}


