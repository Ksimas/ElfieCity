using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    static class ElvishBuildings
    {
        // Zmienne wskazujace na poziom posiadanych budynkow
        // poziom budynku chata myśliwska
        public static int LevelOfHuntingBuilding = 1;
        // poziom budynku tartak
        public static int LevelOfWoodshet = 1;
        // poziom budynku kamieniołom
        public static int LevelOfQuarry = 1;
        // poziom budynku huta zelaza
        public static int LevelOfIronWorks = 1;
        // poziom budynku kopalnia krysztalow
        public static int LevelOfCrystalMine = 0;
        // poziom budynku domy
        public static int LevelOfHouses = 1;
        // poziom budynku swiatynia
        public static int LevelOfTemple = 0;
        // poziom budynku fikusne budynki
        public static int LevelOfElvishBuilding = 0;
        // poziom budynku szkola sztuk walki
        public static int LevelOfMartialArtsSchool = 0;
        // poziom infrastruktury
        public static int LevelOfInfrastructure = 1;

        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy chaty mysliwskiej w zaleznosci od poziomu budynku
        /// </summary>
        /// <returns></returns>
        public static int[] HuntingBuildingCost()
        {
            int wood = LevelOfHuntingBuilding * 20;
            int stone = (LevelOfHuntingBuilding + 1) * 15;
            int iron = LevelOfHuntingBuilding*10;
            int crystals = 0;
            if (LevelOfHuntingBuilding >= 20)
            {
                wood = LevelOfHuntingBuilding * 30;
                stone = (LevelOfHuntingBuilding + 1) * 20;
                iron = LevelOfHuntingBuilding*40;
                crystals = LevelOfHuntingBuilding - LevelOfTemple*2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }

        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy/ulepszenia tartaku
        /// </summary>
        /// <returns></returns>
        public static int[] WoodshetCost()
        {
            int wood = LevelOfWoodshet * 25;
            int stone = (LevelOfWoodshet + 1) * 10;
            int iron = 0;
            int crystals = 0;
            if (LevelOfWoodshet >= 3)
                iron = LevelOfWoodshet * 15;
            if (LevelOfWoodshet >= 20 && LevelOfWoodshet < 30 )
            {
                wood = LevelOfWoodshet * 40;
                stone = (LevelOfWoodshet + 1) * 20;
                iron = LevelOfWoodshet*30;
                crystals = LevelOfWoodshet - LevelOfTemple * 2;
            }
            if (LevelOfWoodshet >= 30 )
            {
                wood = LevelOfWoodshet * 50;
                stone = (LevelOfWoodshet + 1) * 30;
                iron = LevelOfWoodshet * 45;
                crystals = LevelOfWoodshet*2 - LevelOfTemple * 2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }
        /// <summary>
        /// Funckja zwracajaca tablice kosztow budowy/ulepszenia kamieniolomu
        /// </summary>
        /// <returns></returns>
        public static int[] QuarryCost()
        {
            int wood = LevelOfQuarry * 25;
            int stone = (LevelOfQuarry + 1) * 15;
            int iron = 0;
            int crystals = 0;
            if (LevelOfQuarry >= 3 && LevelOfQuarry < 20)
                iron = LevelOfQuarry * 10;
            if (LevelOfQuarry >= 20 && LevelOfQuarry < 30)
            {
                wood = LevelOfQuarry * 45;
                stone = (LevelOfQuarry + 1) * 35;
                iron = LevelOfQuarry*30;
                crystals = LevelOfQuarry - LevelOfTemple*2;
            }
            if (LevelOfQuarry >= 30 )
            {
                wood = LevelOfQuarry * 60;
                stone = (LevelOfQuarry + 1) * 50;
                iron = LevelOfQuarry * 50;
                crystals = LevelOfQuarry*2 - LevelOfTemple * 2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }
        /// <summary>
        /// Funckja zwracajaca tablice kosztow budowy/ulepszenia huty
        /// </summary>
        /// <returns></returns>
        public static int[] IronWorksCost()
        {
            int wood = LevelOfIronWorks * 25;
            int stone = (LevelOfIronWorks + 1) * 35;
            int iron = LevelOfIronWorks * 30;
            int crystals = 0;

            if (LevelOfIronWorks >= 20 && LevelOfIronWorks < 30)
            {
                wood = LevelOfIronWorks * 40;
                stone = (LevelOfIronWorks + 1) * 60;
                iron = LevelOfIronWorks * 50;
                crystals = LevelOfIronWorks - LevelOfTemple*2;
            }
            if (LevelOfIronWorks >= 30)
            {
                wood = LevelOfIronWorks * 50;
                stone = (LevelOfIronWorks + 1) * 70;
                iron = LevelOfIronWorks * 60;
                crystals = LevelOfIronWorks*2 - LevelOfTemple * 2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }


        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy/ulepszenia kopalni kryształów
        /// </summary>
        /// <returns></returns>
        public static int[] CrystalMineCost()
        {
            int wood = (LevelOfCrystalMine + 1) * 250;
            int stone = (LevelOfCrystalMine + 1) * 250;
            int iron = LevelOfCrystalMine * 300;
            int crystals = 0;
            if (LevelOfCrystalMine >= 10)
            {
                wood = (LevelOfCrystalMine + 1) * 350;
                stone = (LevelOfCrystalMine + 1) * 350;
                iron = LevelOfCrystalMine * 400;
                crystals = LevelOfCrystalMine * 4 - LevelOfTemple*2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }
        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy/ulepszenia elfickich domow
        /// </summary>
        /// <returns></returns>
        public static int[] HousesCost()
        {
            int wood = LevelOfHouses * 30;
            int stone = LevelOfHouses * 20;
            int iron = LevelOfHouses * 10;
            int crystals = 0;
            if (LevelOfHouses >= 10)
            {
                wood = LevelOfHouses * 60;
                stone = (LevelOfHouses + 5) * 40;
                iron = LevelOfHouses * 20;
            }
            if (LevelOfHouses >= 20)
            {
                wood = LevelOfHouses * 80;
                stone = (LevelOfHouses + 5) * 100;
                iron = LevelOfHouses * 50;
                crystals = LevelOfHouses - LevelOfTemple*2;

            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }

        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy/ulepszenia swiatyni
        /// </summary>
        /// <returns></returns>
        public static int[] TempleCost()
        {
            int wood = (LevelOfTemple + 1) * 500;
            int stone = (LevelOfTemple + 2) * 500;
            int iron = (LevelOfTemple + 1) * 500;
            int crystals = 0;
            if (LevelOfTemple >= 5)
                crystals = LevelOfTemple * 4;
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }

        /// <summary>
        /// Funkcja zwracajaca tablice kosztow budowy/ulepszenia fikuśnych budynków
        /// </summary>
        /// <returns></returns>
        public static int[] ElvishBuildingCost()
        {
            int wood = (LevelOfElvishBuilding + 2) * 30;
            int stone = (LevelOfElvishBuilding + 2) * 30;
            int iron = (LevelOfElvishBuilding + 2 ) * 10;
            int crystals = 0;
            if (LevelOfElvishBuilding >= 10)
            {
                wood = (LevelOfElvishBuilding + 2) * 50;
                stone = (LevelOfElvishBuilding + 2) * 50;
                iron = (LevelOfElvishBuilding + 2) * 20;

                crystals = LevelOfElvishBuilding - LevelOfTemple * 2;
            }

            if (LevelOfElvishBuilding >= 20)
            {
                wood = (LevelOfElvishBuilding + 4) * 70;
                stone = (LevelOfElvishBuilding + 4) * 70;
                iron = (LevelOfElvishBuilding + 4) * 50;

                crystals = LevelOfElvishBuilding * 2 - LevelOfTemple * 2;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }
        /// <summary>
        /// Funckja zwracajaca tablice kosztow budowy/ulepszenia fukuśnych budynkow
        /// </summary>
        /// <returns></returns>
        public static int[] MartialArtsSchoolCost()
        {
            int wood = (LevelOfMartialArtsSchool + 5) * 15;
            int stone = (LevelOfMartialArtsSchool + 10) * 15;
            int iron = LevelOfMartialArtsSchool * 25;
            int crystals = 0;


            // jezeli budynek ma 10lv  to koszty surowców wzrastają
            if (LevelOfMartialArtsSchool >= 10)
            {
                wood = (LevelOfMartialArtsSchool + 10) * 25;
                stone = (LevelOfMartialArtsSchool + 20) * 30;
                iron = (LevelOfMartialArtsSchool + 10) * 35;

                crystals = LevelOfMartialArtsSchool * 2 - LevelOfTemple * 2;
            }

            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }

        public static int[] InfrastructureCost()
        {
            int wood = (LevelOfInfrastructure + 40) * 10;
            int stone = (LevelOfInfrastructure + 30) * 10;
            int iron = (LevelOfInfrastructure) * 100;
            int crystals = 0;


            // jezeli budynek ma 10lv  to koszty surowców wzrastają
            if (LevelOfInfrastructure >= 10)
            {
                wood = LevelOfInfrastructure * 100;
                stone = LevelOfInfrastructure * 120;
                iron = LevelOfInfrastructure * 150;

                crystals = LevelOfInfrastructure * 2 - LevelOfTemple * 2 ;
            }
            int[] cost = { wood, stone, iron, crystals };
            return cost;
        }
    }


}
