using BerlinClock.Classes;
using System;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var separator = ':';
            StringBuilder stringBerlinTimeString = new StringBuilder();

            int second = 0;
            int minute = 0;
            int hour = 0;

            var numbers = aTime.Split(separator).Select(Int32.Parse).ToList();
            hour = numbers[0];
            minute = numbers[1];
            second = numbers[2];

            stringBerlinTimeString.AppendLine(FirstSecondRow(second));
            stringBerlinTimeString.AppendLine(FirstHourRow(hour));
            stringBerlinTimeString.AppendLine(SecondHourRow(hour));
            stringBerlinTimeString.AppendLine(FirstMinuteRow(minute));
            stringBerlinTimeString.Append(SecondMinuteRow(minute));

            return stringBerlinTimeString.ToString();
        }

        private bool YellowOn(int second)
        {
            return (second % 2) == 0;
        }

        private string FirstSecondRow(int second)
        {
            string ledOn = "O";

            if (YellowOn(second))
            {
                ledOn = "Y";
            }

            return ledOn;
        }

        private string FirstHourRow(int hour)
        {
            double rowLamp = hour / 5;
            return HourRow(rowLamp);
        }

        private string SecondHourRow(int hour)
        {
            double minute = hour % 10;
            return HourRow(minute, 4, "R");
        }

        private string FirstMinuteRow(int minute)
        {
            double rowLamp = minute / 5;
            return HourRow(rowLamp, 11, "Y");
        }

        private string SecondMinuteRow(int minute)
        {
            double rowLamp1 = minute / 5;
            double timelamp = rowLamp1 * 5;
            double rowLamp = (timelamp - minute)*-1;
            return HourRow(rowLamp, 4, "Y");
        }

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
    }
}
