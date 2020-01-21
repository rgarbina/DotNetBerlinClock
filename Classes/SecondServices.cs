using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Responsabilities of abstract time
    /// </summary>
    public static class SecondServices
    {
        /// <summary>
        /// Simple validation of second/minute range returning a bool
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsValid(int second)
        {
            bool valid = false;

            if ((second >= 0) && (second < 60))
            {
                valid = true;
            }

            return valid;
        }
    }
}
