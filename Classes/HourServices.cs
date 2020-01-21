using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// responsabilities of hour in clock
    /// </summary>
    public static class HourServices
    {
        /// <summary>
        /// Simple validation of hour range returning a bool
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static bool IsValid(int hour)
        {
            bool valid = false;

            if ((hour >= 0) && (hour < 25))
            {
                valid = true;
            }

            return valid;
        }
    }
}
