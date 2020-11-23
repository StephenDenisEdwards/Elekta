using System;
using System.Collections.Generic;
using System.IO;
using PetReport.Reflective.Lib;

namespace PetReport.Reflective.Domain
{
    public class PetReportGenerator
    {
        private TextWriter _writer;

        public PetReportGenerator(TextWriter writer)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void GenerateReport(List<IReportable> pets)
        {
            _writer.WriteLine("Owners name,Date Joined Practice,Number Of Visits,Number of Lives");

            foreach (var pet in pets)
            {
                object firstName = pet["Owner.Firstname"];
                object lastName = pet["Owner.Lastname"];
                object dateJoined = pet["Owner.JoinedPractice"];
                object numberOfVisits = pet["NumberOfVisits"];
                object numberOfLives = pet["NumberOfLives"];

                var line = $"{firstName} {lastName}, {dateJoined}, {numberOfVisits}, {numberOfLives}";

                _writer.WriteLine(line);
            }
        }
    }
}