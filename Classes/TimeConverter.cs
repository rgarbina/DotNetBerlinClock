using BerlinClock.Classes;
using BerlinClock.Interfaces;
using BerlinClock.Model;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            if (!string.IsNullOrEmpty(ValidateInput(aTime)))
            {
                return "Problem with input! pattern example 00:00:00";
            }

            BerlinUhr oClock = new BerlinUhr(aTime);

            return oClock.BuildUpBerlinClock();
        }

        /// <summary>
        /// method to validate input before procede to Clock
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns></returns>
        private string ValidateInput(string aTime)
        {
            StringBuilder valid = new StringBuilder("Invalid Input:");
            bool validReturn = true;
            int expectedLength = 8;
            var numberSeparators = Regex.Matches(aTime, ":").Count;

            try
            {
                if (aTime.Length != expectedLength)
                {
                    validReturn = false;
                    valid.AppendLine(string.Format("different string length than expected: Expected = {0}, Length{1}", expectedLength, aTime.Length));
                }
                else if (numberSeparators != 2)
                {
                    validReturn = false;
                    valid.AppendLine(string.Format("separator are different of two, input: {0}", aTime));
                }
            }
            catch (Exception e)
            {
                validReturn = false;
                valid.AppendLine("Exception Problem !");
            }

            if (validReturn)
            {
                return "";
            }

            return valid.ToString();
        }
    }
}
