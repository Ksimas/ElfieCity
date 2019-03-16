using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class ElvishArcher : ElvishUnit
    {
        // lista zawierajaca obiekty klasy ElvishArcher
        public static List<ElvishArcher> ElvishList = new List<ElvishArcher>();

        // czas szkolenia elfickiego lucznika, gdy budynek odpowiedzialny za szybkosc szkolenia jest na poziomie 1
        public static int TrainingTimeStandart = 10000;

        // statyczna zmienna przechowujaca obrazenia elfickiego lucznika
        public new static int Damage = 4;
        // statyczna zmienna przechowujaca punkty zycia elfickiego lucznika
        public new static int HealthPoints = 12;

        /// <summary>
        /// Konstruktor 
        /// </summary>
        public ElvishArcher()
        {
            // dodanie utworzonego obiektu do listy
            ElvishList.Add(this);
        }


        /// <summary>
        /// Statyczna funkcja zwracajaca koszty szkolenia jednostki elficki lucznik
        /// </summary>
        /// <returns></returns>
        public static int[] TrainingCost()
        {
            // (1) żywność, (2) drewno, (3) kamień, (4) żelazo, (5) kryształy, (6) populacja
            int[] cost = { 20, 50, 20, 30, 0, 1 };
            return cost;
        }

        /// <summary>
        /// Statyczna funkcja zwracajaca czas szkolenia jednostki elficki lucznik
        /// </summary>
        /// <returns></returns>
        public static int TrainingTime()
        {
            return Convert.ToInt32(TrainingTimeStandart- (ElvishBuildings.LevelOfMartialArtsSchool * 5.0) / 100.0 * TrainingTimeStandart + 1.0);
        }

    }
}