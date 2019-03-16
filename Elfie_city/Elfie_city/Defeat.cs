using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    static class Defeat
    {
        /// <summary>
        /// Funkcja sprawdzajaca czy populacja miasta jest wystarczajaco duza by symulacja mogla trwac dalej
        /// </summary>
        /// <returns></returns>
        public static bool EndBceauseOfLowPopulation()
        {
            if (Resources.Population < 10)
            {
                return true;
            }
            else return false;
        }

    }
}
