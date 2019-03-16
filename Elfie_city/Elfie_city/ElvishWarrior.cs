using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class ElvishWarrior : ElvishUnit
    {
        // statyczna lista zawierajaca obiekty klasy ElvishWarrior
        public static List<ElvishWarrior> ElvishList = new List<ElvishWarrior>();
        // statyczna zmienna zawierajaca podstawowy czas szkolenia jednostki,
        // podstawowy czyli ten, gdy szkola sztuk walki jest na poziomie 1
        public static int TrainingTimeStandard = 10000;
        // statyczna zmienna przechowujaca obrazenia elfickiego wojownika
        public new static int Damage = 2;
        // statyczna zmienna przechowujaca punkty zycia elfickiego wojownika
        public new static int HealthPoints = 25;

        public ElvishWarrior()
        {
            // dodanie utworzonego obiektu do listy
            ElvishList.Add(this);
        }

        
        /// <summary>
        /// Statyczna funkcja zwracajaca koszty szkolenia jednostki elficki wojownik
        /// </summary>
        /// <returns></returns>
        public static int[] TrainingCost()
        {
            // (1) żywność, (2) drewno, (3) kamień, (4) żelazo, (5) kryształy, (6) populacja
            int[] cost = { 20, 20, 20, 50, 0, 1 };
            return cost;
        }

        /// <summary>
        /// Statyczna funkcja zwracajaca czas szkolenia jednostki elficki lucznik
        /// </summary>
        /// <returns></returns>
        public static int TrainingTime()
        {
            return Convert.ToInt32(TrainingTimeStandard - (ElvishBuildings.LevelOfMartialArtsSchool * 5.0) / 100.0 * TrainingTimeStandard + 1.0);
        }
        
    }
}