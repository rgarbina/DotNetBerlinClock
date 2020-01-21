using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Model
{
    /// <summary>
    /// class with integer properties Hour, Minute and Second
    /// </summary>
    public class Clock
    {
        private int _hour;
        private int _minute;
        private int _second;

        /// <summary>
        /// Represent hour from 0 to 24 
        /// </summary>
        public int Hour
        {
            get => _hour;
            set
            {
                if ((value >= 0) && (value < 25))
                {
                    _hour = value;
                }
            }
        }

        /// <summary>
        /// Represent minute from 0 to 59
        /// </summary>
        public int Minute
        {
            get => _minute;
            set
            {
                if ((value >= 0) && (value < 60))
                {
                    _minute = value;
                }
            }
        }

        /// <summary>
        /// Represent second from 0 to 59
        /// </summary>
        public int Second
        {
            get => _second;
            set
            {
                if ((value >= 0) && (value < 60))
                {
                    _second = value;
                }
            }
        }

        public bool IsValid()
        {
            return HourServices.IsValid(Hour) && SecondServices.IsValid(Minute) && SecondServices.IsValid(Second);
        }

        /// <summary>
        /// convert time 00:00:00 in string to model object Clock{Hour, Minute, Second} 
        /// </summary>
        /// <param name="aTime"></param>
        public void StringToClock(string aTime)
        {
            var separator = ':';

            List<int> listNumber = new List<int>();
            foreach (var interString in aTime.Split(separator))
            {
                int number;
                if (Int32.TryParse(interString, out number))
                    listNumber.Add(number);
            }

            Hour = listNumber[0];
            Minute = listNumber[1];
            Second = listNumber[2];
        }
    }
}
