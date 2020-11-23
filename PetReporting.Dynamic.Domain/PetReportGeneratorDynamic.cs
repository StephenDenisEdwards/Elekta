using PetReporting.Dynamic.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace PetReporting.Dynamic.Domain
{
    public class PetReportGeneratorDynamic
    {
        private readonly TextWriter _writer;

        public PetReportGeneratorDynamic(TextWriter writer)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void GenerateReport(List<IReportable> pets)
        {
            _writer.WriteLine("Owners name,Date Joined Practice,Number Of Visits,Number of Lives");

            foreach (dynamic pet in pets)
            {
                var line = 
                    $"{pet.Owner.Firstname} {pet.Owner.Lastname}, {pet.Owner.JoinedPractice}, " +
                    $"{pet.NumberOfVisits}, {pet.NumberOfLives}";
                
                _writer.WriteLine(line);
            }
        }
    }
}