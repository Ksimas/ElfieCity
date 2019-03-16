using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class ElvishMaster : ElvishUnit
    {
        // lista zawierajaca obiekty klasy ElvishMaster
        public static List<ElvishMaster> ElvishList = new List<ElvishMaster>();

        // czas szkolenia jednostki elficki mistrz, gdy budynek odpowiedzialny za szybkosc skzolenia jest na poziomie 1
        public static int StandardTimeTraining = 50000;

        // statyczna zmienna przechowujaca obrazenia elfickiego wojownika
        public new static int  Damage = 10;
        // statyczna zmienna przechowujaca punkty zycia elfickiego wojownika
        public new static int HealthPoints = 100;


        public ElvishMaster()
        {
            // dodanie utworzonego obiektu do listy
            ElvishList.Add(this);
        }

        /// <summary>
        /// Statyczna funkcja zwracajaca koszty szkolenia jednostki elficki mistrz
        /// </summary>
        /// <returns></returns>
        public static int[] TrainingCost()
        {
            // zywnosc, drewno, kamien, zelazo, krysztaly, populacja
            int[] cost = { 50, 250, 50, 250, 5, 5 };
            return cost;
        }

        /// <summary>
        /// Statyczna funkcja zwracajaca czas szkolenia jednostki elficki lucznik
        /// </summary>
        /// <returns></returns>
        public static int TrainingTime()
        {
            return Convert.ToInt32(StandardTimeTraining - (ElvishBuildings.LevelOfMartialArtsSchool * 5.0) / 100.0 * StandardTimeTraining + 1.0);
        }

    }
}