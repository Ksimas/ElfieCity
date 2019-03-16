using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    static class Resources
    {
        // Zmienne wyznaczajace liczbe posiadanych zasobow

        public static int ResourcesFood = 100;
        public static int ResourcesWood = 100;
        public static int ResoucresStone = 100;
        public static int ResoucresCrystals = 0;
        public static int ResoucresIron = 100;
        public static int Population = 10;

        /// <summary>
        /// Funkcja zwracajaca szybkosc zmiany zasobow zywnosci
        /// </summary>
        /// <returns></returns>
        public static int FoodGrowth()
        {
            double TotalFoodGrowth = ElvishBuildings.LevelOfHuntingBuilding * 8 +
                ElvishBuildings.LevelOfHuntingBuilding * 8 * ElvishBuildings.LevelOfInfrastructure / 10 - Population;

            return Convert.ToInt32(Math.Round(TotalFoodGrowth));
        }
        /// <summary>
        /// Funckja zwracająca szybkość zmiany zasobów drewna
        /// </summary>
        /// <returns></returns>
        public static int WoodGrowth()
        {
            double TotalWoodGrowth = ElvishBuildings.LevelOfWoodshet * 3 +
                ElvishBuildings.LevelOfWoodshet * 3 * ElvishBuildings.LevelOfInfrastructure / 10;
            if (ElvishBuildings.LevelOfWoodshet >= 15)
            {
                TotalWoodGrowth = ElvishBuildings.LevelOfWoodshet * 4 +
                ElvishBuildings.LevelOfWoodshet * 4 * ElvishBuildings.LevelOfInfrastructure / 10;
            }
            return Convert.ToInt32(Math.Round(TotalWoodGrowth));

        }
        /// <summary>
        /// Funckja zwracająca szybkość zmiany zasobów kamieni
        /// </summary>
        /// <returns></returns>      
        public static int StoneGrowth()
        {
            double TotalStoneGrowth = ElvishBuildings.LevelOfQuarry * 2 +
                ElvishBuildings.LevelOfQuarry * 2 * ElvishBuildings.LevelOfInfrastructure / 10;
            if (ElvishBuildings.LevelOfQuarry >= 15)
            {
                TotalStoneGrowth = ElvishBuildings.LevelOfQuarry * 3 +
                ElvishBuildings.LevelOfQuarry * 3 * ElvishBuildings.LevelOfInfrastructure / 10;
            }
            return Convert.ToInt32(Math.Round(TotalStoneGrowth));
        }
        /// <summary>
        /// Funckja zwracająca szybkość zmiany zasobów żelaza
        /// </summary>
        /// <returns></returns>
        public static int IronGrowth()
        {
            double TotalIronGrowth = ElvishBuildings.LevelOfIronWorks * 2 +
                ElvishBuildings.LevelOfIronWorks * 2 * ElvishBuildings.LevelOfInfrastructure / 10;
            if (ElvishBuildings.LevelOfIronWorks >= 15)
            {
                TotalIronGrowth = ElvishBuildings.LevelOfIronWorks * 3 +
                ElvishBuildings.LevelOfIronWorks * 3 * ElvishBuildings.LevelOfInfrastructure / 10;
            }
            return Convert.ToInt32(Math.Round(TotalIronGrowth));
        }
        /// <summary>
        /// Funckja zwracająca szybkość zmiany zasobów kryształów
        /// </summary>
        /// <returns></returns>
        /// 
        public static int CrystalsGrowth()
        {
            double TotalCrystalsGrowth = ElvishBuildings.LevelOfCrystalMine * 1 +
                ElvishBuildings.LevelOfCrystalMine * 1 * ElvishBuildings.LevelOfInfrastructure / 10;

            return Convert.ToInt32(Math.Round(TotalCrystalsGrowth));
        }

        /// <summary>
        /// Funckja zwracająca szybkość zmiany populacji
        /// </summary>
        /// <returns></returns>
        public static int PopulationGrowth()
        {
            if (ElvishBuildings.LevelOfHouses * 10 > Population && ResourcesFood > 0)
            {
                // na wskaznik wzorstu populacji sklada sie poziom budynkow domy,poziom budynku infrastruktura, poziom budynku świątynia oraz poziom budynku elfickie fikuśne budynki
                double populationGrowthRate = (ElvishBuildings.LevelOfHouses + ElvishBuildings.LevelOfInfrastructure + ElvishBuildings.LevelOfTemple + ElvishBuildings.LevelOfElvishBuilding) / 4;
                if (Convert.ToInt32(Math.Round(populationGrowthRate, 0)) + Population > ElvishBuildings.LevelOfHouses * 10)
                {
                    return ElvishBuildings.LevelOfHouses * 10 - Population;
                }
                else
                    return Convert.ToInt32(Math.Round(populationGrowthRate, 0));
            }
            if (ResourcesFood <= 0 && Population >= 50)
                return -(Convert.ToInt32(Math.Round(Population * 0.1)));
            if (ResourcesFood <= 0 && Population < 50)
            {
                return -1;
            }
            else
                return 0;
        }

    }
}
