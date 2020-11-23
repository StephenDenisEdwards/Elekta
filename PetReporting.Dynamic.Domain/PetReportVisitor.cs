using System;
using System.Diagnostics;
using System.IO;
using PetReporting.Dynamic.Lib;

namespace PetReporting.Dynamic.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PetReportVisitor : IPetVisitor
    {
        private readonly TextWriter _writer;

        public PetReportVisitor(TextWriter writer)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _writer.WriteLine("Owners name,Date Joined Practice,Number Of Visits,Number of Lives");
        }

        public void Visit(Dog element)
        {
            // TODO: Add string trimming
            // TODO: Add date formatting
            var line =
                $"{element.Owner.Firstname} {element.Owner.Lastname}, {element.Owner.JoinedPractice}, " +
                $"{element.NumberOfVisits}, ";
            _writer.WriteLine(line);
        }

        public void Visit(Cat element)
        {
            // TODO: Add string trimming
            // TODO: Add date formatting
            var line =
                $"{element.Owner.Firstname} {element.Owner.Lastname}, {element.Owner.JoinedPractice}, " +
                $"{element.NumberOfVisits}, {element.NumberOfLives}";

            _writer.WriteLine(line);
        }
    }
}