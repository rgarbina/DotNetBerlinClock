using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Model
{
    /// <summary>
    ///  Represents a clock in berlin with clock inheritance
    /// </summary>
    public class BerlinUhr : Clock
    {
        public BerlinUhr(string aTime = "00:00:00")
        {
            StringToClock(aTime);
        }

        /// <summary>
        /// Represents top of clock the first lamp yellow, blinks every two seconds
        /// </summary>
        public string YellowLed
        {
            get { return FirstSecondRow(Second); }
        }

        /// <summary>
        /// the top of clock represents the hours in the top row with 4 red lamps in every 5 hour
        /// </summary>
        public string FiveHourRow
        {
            get { return FirstHourRow(Hour); }
        }

        /// <summary>
        /// the top of clock represents the hours in the lower of row with 4 red lamps in every 1 hour
        /// </summary>
        public string OneHourRow
        {
            get { return SecondHourRow(Hour); }
        }

        /// <summary>
        /// the bottom of clock represents the minutes containing 11 lamps in yellow with each 5 minutes. 
        /// the 3rd, 6th and 9th lamp are red and indicate the first quarter, half and last quarter of an hour
        /// </summary>
        public string FiveMinuteRow
        {
            get { return FirstMinuteRow(Minute); }
        }

        /// <summary>
        /// In the last row with 4 lamps every lamp represents 1 minute in yellow
        /// </summary>
        public string OneMinuteRow
        {
            get { return SecondMinuteRow(Minute); }
        }

        /// <summary>
        /// method to return time formatted in correct order in string representating leds and colors 
        /// </summary>
        /// <returns></returns>
        public string BuildUpBerlinClock()
        {
            StringBuilder stringBerlinTimeString = new StringBuilder();

            stringBerlinTimeString.AppendLine(YellowLed);
            stringBerlinTimeString.AppendLine(FiveHourRow);
            stringBerlinTimeString.AppendLine(OneHourRow);
            stringBerlinTimeString.AppendLine(FiveMinuteRow);
            stringBerlinTimeString.Append(OneMinuteRow);

            return stringBerlinTimeString.ToString();
        }

        #region Private Methods

        /// <summary>
        /// return Yellow Lamp status in second
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        private string FirstSecondRow(int second)
        {
            string ledOn = "O";

            if (YellowOn(second))
            {
                ledOn = "Y";
            }

            return ledOn;
        }

        /// <summary>
        /// algorithm to return number of lamps
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        private string FirstHourRow(int hour)
        {
            double rowLamp = hour / 5;
            return HourRow(rowLamp);
        }

        /// <summary>
        /// algorithm to return number of lamps
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        private string SecondHourRow(int hour)
        {
            double minute = hour % 10;
            return HourRow(minute, 4, "R");
        }

        /// <summary>
        /// algorithm to return number of lamps
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        private string FirstMinuteRow(int minute)
        {
            double rowLamp = minute / 5;
            return HourRow(rowLamp, 11, "Y");
        }

        /// <summary>
        /// algorithm to return number of lamps
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        private string SecondMinuteRow(int minute)
        {
            double rowLamp1 = minute / 5;
            double timelamp = rowLamp1 * 5;
            double rowLamp = Math.Abs(timelamp - minute);
            return HourRow(rowLamp, 4, "Y");
        }

        /// <summary>
        /// Yellow lamp algorithm
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        private bool YellowOn(int second)
        {
            return (second % 2) == 0;
        }

        /// <summary>
        /// clock algorithm to return switched led 
        /// </summary>
        /// <param name="value">number of lamps</param>
        /// <param name="led">return of lamps</param>
        /// <param name="ledColor">color of lightned lamp</param>
        /// <returns></returns>
        private string HourRow(double value, int led = 4, string ledColor = "R")
        {
            StringBuilder stringRow = new StringBuilder();

            for (int i = 1; i <= led; i++)
            {
                string ledOn = "O";
                bool ledQuarter = (i % 3 == 0);

                if (value >= i)
                {
                    if (ledQuarter && ledColor != "R" && led > 4)
                    {
                        ledOn = "R";
                    }
                    else
                    {
                        ledOn = ledColor;
                    }
                }

                stringRow.Append(ledOn);
            }

            return stringRow.ToString();
        }
        #endregion
    }
}
