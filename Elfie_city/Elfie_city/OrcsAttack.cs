using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    static class OrcsAttack
    {

        public static int battleCounter = 0;

        /// <summary>
        /// przebieg bitwy z orkami, zwraca tablice
        /// pierwszym elementem jest wynik bitwy  1-miasto obronione  2-miasto nieobronione
        /// kolejnymi trzema elementami jest liczba atakujacych orkow
        /// trzema ostatnimi elementami jest liczba poleglych elfow
        /// </summary>
        /// <returns></returns>
        public static int[] BattleVsOrcs()
        {

            // suma punktow zycia elfow
            int elvishHealthPoints = ElvishArcher.ElvishList.Count * ElvishArcher.HealthPoints + ElvishWarrior.ElvishList.Count * ElvishWarrior.HealthPoints + ElvishMaster.ElvishList.Count * ElvishMaster.HealthPoints;
            // suma obrazen elfow
            int elvishDamage = Convert.ToInt32(Math.Round((ElvishArcher.ElvishList.Count * ElvishArcher.Damage + ElvishWarrior.ElvishList.Count * ElvishWarrior.Damage + ElvishMaster.ElvishList.Count * ElvishMaster.Damage)
            +(ElvishArcher.ElvishList.Count * ElvishArcher.Damage + ElvishWarrior.ElvishList.Count * ElvishWarrior.Damage + ElvishMaster.ElvishList.Count * ElvishMaster.Damage) * ElvishBuildings.LevelOfTemple * 0.10, 0));
            // suma punktow zycia orkow
            int orcishHealthPoints = OrcishCrossbowman.OrcishList.Count * OrcishCrossbowman.HealthPoints + OrcishWarrior.OrcishList.Count * OrcishWarrior.HealthPoints + OrcishCommander.OrcishList.Count * OrcishCommander.HealthPoints;
            // suma obrazen orkow
            int orcishDamage = OrcishCrossbowman.OrcishList.Count * OrcishCrossbowman.Damage + OrcishWarrior.OrcishList.Count * OrcishWarrior.Damage + OrcishCommander.OrcishList.Count * OrcishCommander.Damage;


            // elfy biorace udzial w bitwie
            int elfArcher = ElvishArcher.ElvishList.Count;
            int elfWarrior = ElvishWarrior.ElvishList.Count;
            int elfMaster = ElvishMaster.ElvishList.Count;


            // ronizca miedzy poczatkowa calkowita liczba punktow zycia, a koncowa
            int loss = 0;

            // obiekt ranomNumber klasy Random bedzie losowal liczby w celu prowadzenia roznych losow potyczek
            Random randomNumber = new Random();


            // walka elfów z orkami, wygrywa ten, ktoremu zostanie wiecej punktow zycia
            while (elvishHealthPoints >= 0 && orcishHealthPoints >= 0)
            {
                elvishHealthPoints -= orcishDamage;
                orcishHealthPoints -= elvishDamage;
            }

            // elfy wygraly lub zremisowały
            if (elvishHealthPoints >= orcishHealthPoints)
            {
                // jezeli ktoś przeżył = wygrały
                if (elvishHealthPoints >= ElvishArcher.HealthPoints || elvishHealthPoints >= ElvishWarrior.HealthPoints || elvishHealthPoints >= ElvishMaster.HealthPoints)
                {
                    loss = ElvishArcher.ElvishList.Count * ElvishArcher.HealthPoints + ElvishWarrior.ElvishList.Count * ElvishWarrior.HealthPoints + ElvishMaster.ElvishList.Count * ElvishMaster.HealthPoints - elvishHealthPoints;
                    // pseudoloswanie strat  
                    int randomNumberOfWarriors = 0;
                    int randomNumberOfArchers = 0;
                    int randomNumberOfMasters = 0;
                    if (ElvishWarrior.ElvishList.Count > 0)
                    {
                        // losowanie strat z zakresu 0 - max stracone punkty zycia
                        randomNumberOfWarriors = randomNumber.Next(0, loss + 1);
                        // wyliczanie strat w jednostach na podstawie ich bazowych punktow zycia
                        randomNumberOfWarriors = randomNumberOfWarriors / ElvishWarrior.HealthPoints;

                        if (randomNumberOfWarriors > ElvishWarrior.ElvishList.Count)
                        {
                            randomNumberOfWarriors = ElvishWarrior.ElvishList.Count;
                        }
                    }
                    if (ElvishArcher.ElvishList.Count > 0)
                    {
                        // losowanie strat z zakresu [0 , max stracone punkty zycia - straty w elfickich wojownikach]
                        randomNumberOfArchers = randomNumber.Next(0, loss + 1 - randomNumberOfWarriors + 1);
                        // wyliczanie strat w jednostach na podstawie ich bazowych punktow zycia
                        randomNumberOfArchers = randomNumberOfArchers / ElvishArcher.HealthPoints;
                        if (randomNumberOfArchers > ElvishArcher.ElvishList.Count)
                        {
                            randomNumberOfArchers = ElvishArcher.ElvishList.Count;
                        }
                    }
                    if (ElvishMaster.ElvishList.Count > 0)
                    {
                        // losowanie strat z zakresu [0 , max stracone punkty zycia - straty w elfickich wojownikach - straty w elfickich lucznikach]
                        randomNumberOfMasters = randomNumber.Next(0, loss + 1 - randomNumberOfWarriors - randomNumberOfArchers + 1);
                        // wyliczanie strat w jednostach na podstawie ich bazowych punktow zycia
                        randomNumberOfMasters = randomNumberOfMasters / ElvishMaster.HealthPoints;
                        if (randomNumberOfMasters > ElvishMaster.ElvishList.Count)
                        {
                            randomNumberOfMasters = ElvishMaster.ElvishList.Count;
                        }
                    }


                    for (int i = randomNumberOfArchers; i > 0; i--)
                    {
                        ElvishArcher.ElvishList.RemoveAt(ElvishArcher.ElvishList.Count - i);
                    }
                    //for (int i = 1; i < randomNumberOfWarriors; i++) 
                    for (int i = randomNumberOfWarriors; i > 0; i--)
                    {
                        ElvishWarrior.ElvishList.RemoveAt(ElvishWarrior.ElvishList.Count - i);
                    }
                    for (int i = randomNumberOfMasters; i > 0; i--)
                    {
                        ElvishMaster.ElvishList.RemoveAt(ElvishMaster.ElvishList.Count - i);
                    }
                    // tablica strat   pierwszy element 1- oznacza obronienie miasta
                    int[] resultOfBattle = { 1, OrcishCrossbowman.OrcishList.Count, OrcishWarrior.OrcishList.Count, OrcishCommander.OrcishList.Count, elfArcher - ElvishArcher.ElvishList.Count, elfWarrior - ElvishWarrior.ElvishList.Count, elfMaster - ElvishMaster.ElvishList.Count };
                    // wywolanie funkcji, ktora zwiekszy liczbe orkow w nastepnej fali
                    NextWave();
                    return resultOfBattle;
                }
                // remis w bitwie
                else
                {
                    // wszystkei jednostki giną,
                    // czyszczenie wszystkich list
                    ElvishArcher.ElvishList.Clear();
                    ElvishWarrior.ElvishList.Clear();
                    ElvishMaster.ElvishList.Clear();
                    // tablica strat   pierwszy element 2- oznacza remis
                    int[] resultOfBattle = { 2, OrcishCrossbowman.OrcishList.Count, OrcishWarrior.OrcishList.Count, OrcishCommander.OrcishList.Count, elfArcher, elfWarrior, elfMaster };

                    NextWave();
                    return resultOfBattle;
                }

            }
            // elfy przegraly bitwe
            else
            {
                loss = ElvishArcher.ElvishList.Count * ElvishArcher.HealthPoints + ElvishWarrior.ElvishList.Count * ElvishWarrior.HealthPoints + ElvishMaster.ElvishList.Count * ElvishMaster.HealthPoints - elvishHealthPoints;
                // wszystkei jednostki giną,
                // czyszczenie wszystkich list
                ElvishArcher.ElvishList.Clear();
                ElvishWarrior.ElvishList.Clear();
                ElvishMaster.ElvishList.Clear();

                // tablica strat   pierwszy element 0- oznacza niepomyślność
                //int[] resultOfBattle = { 0, OrcishCrossbowman.OrcishList.Count(), OrcishWarrior.OrcishList.Count(), OrcishCommander.OrcishList.Count(), elfArcher, elfWarrior, elfMaster };
                int[] resultOfBattle = { 0, OrcishCrossbowman.OrcishList.Count, OrcishWarrior.OrcishList.Count, OrcishCommander.OrcishList.Count, elfArcher, elfWarrior, elfMaster };

                // wywolanie funkcji odpowiedzialenj za pladrowania miasta
                plunder();
                // w przypadku nieobronienia miasta liczba orkow atakujaca miasto w nastpenej fali nie zwiekszy sie
                return resultOfBattle;

            }
        }

        /// <summary>
        /// Funkcja zwieksza ilosc orkow bioracych udzial w nastepnym ataku
        /// </summary>
        public static void NextWave()
        {
            // obiekt ranomNumber klasy Random bedzie losowal liczby w celu prowadzenia roznych losow potyczek
            Random randomNumber = new Random();

            // inkrementacja licznika potyczek
            battleCounter++;

            if (battleCounter == 1)
            {
                // zwiekszenie liczby przeciwnikow
                OrcishWarrior newWarrior = new OrcishWarrior();
                OrcishCrossbowman newCrossbowman = new OrcishCrossbowman();
            }
            // jezeli licznik bitew wskazuje 3 
            if (battleCounter == 2)
            {
                // dodanie do grupy orkow silnego dowodcy
                OrcishCommander newCommander = new OrcishCommander();
            }
            // jezeli licznik bitew jest rowny lub wiekszy od 4 to orkowie beda atakowac coraz to wieksza grupa
            if (battleCounter >= 3 && battleCounter < 10)
            {
                for (int i = 1; i <= randomNumber.Next(3, 7); i++)
                {
                    OrcishWarrior orcishWarrior = new OrcishWarrior();
                }
                for (int i = 1; i <= randomNumber.Next(3, 7); i++)
                {
                    OrcishCrossbowman newCrossbowman = new OrcishCrossbowman();
                }
                for (int i = 1; i <= randomNumber.Next(1, 3); i++)
                {
                    OrcishCommander newCommander = new OrcishCommander();
                }
            }

            if (battleCounter >= 10)
            {
                for (int i = 1; i <= randomNumber.Next(7, 14); i++)
                {
                    OrcishWarrior orcishWarrior = new OrcishWarrior();
                }
                for (int i = 1; i <= randomNumber.Next(7, 14); i++)
                {
                    OrcishCrossbowman newCrossbowman = new OrcishCrossbowman();
                }
                for (int i = 1; i <= randomNumber.Next(3, 6); i++)
                {
                    OrcishCommander newCommander = new OrcishCommander();
                }
            }
            if (battleCounter >= 16)
            {
                for (int i = 1; i <= randomNumber.Next(12, 20); i++)
                {
                    OrcishWarrior orcishWarrior = new OrcishWarrior();
                }
                for (int i = 1; i <= randomNumber.Next(12, 20); i++)
                {
                    OrcishCrossbowman newCrossbowman = new OrcishCrossbowman();
                }
                for (int i = 1; i <= randomNumber.Next(4, 7); i++)
                {
                    OrcishCommander newCommander = new OrcishCommander();
                }
            }

        }

        /// <summary>
        /// Funkcja obliczajaca liczbe utraconych zasobow w wyniku spladrowania miasta przez orkow
        /// </summary>
        public static void plunder()
        {
            if (battleCounter == 0)
            {
                Resources.ResourcesFood -= 20;
                Resources.ResourcesWood -= 20;
                Resources.ResoucresStone -= 20;
                Resources.ResoucresIron -= 20;
                Resources.ResourcesFood -= 40;
                Resources.Population -= 10;
            }
            if (battleCounter == 1 || battleCounter == 2)
            {
                Resources.ResourcesFood -= 70;
                Resources.ResourcesWood -= 50;
                Resources.ResoucresStone -= 50;
                Resources.ResoucresIron -= 50;
                Resources.ResoucresCrystals -= 20;
                Resources.Population -= 20;
            }

            // orkowie zabierają więcej zasobów jeżeli licznik bitwe wskazuje 3 lub więcej
            if (battleCounter >= 3)
            {
                Resources.ResourcesFood -= 70 * battleCounter;
                Resources.ResourcesWood -= 50 * battleCounter;
                Resources.ResoucresStone -= 50 * battleCounter;
                Resources.ResoucresIron -= 50 * battleCounter;
                Resources.ResoucresCrystals -= 20 * battleCounter;
                Resources.Population -= 20 * battleCounter;
            }

            // orkowie po wygranej bitwie niszczą (obniżają poziom) pseudolosowy budynek 
            if (battleCounter >= 5)
            {
                Random randomNumber = new Random();
                // pseudlosowanie miejsca wypadku    1-chata mysliwych 2- tartak,  3- kamieniołom,  4-huta,  5-elfickie domy
                int destroyedBuilding = randomNumber.Next(1, 4);
                // pseudolosowanie o ile poziom budynku ulegnie zmianie
                int reductionLvlOfBuild = randomNumber.Next(1, 3);


                if (destroyedBuilding == 1)
                {
                    //MessageBox.Show("Orkowie spalili elficki dom!");
                    ElvishBuildings.LevelOfHouses -= reductionLvlOfBuild;
                }
                if (destroyedBuilding == 2)
                {
                    //MessageBox.Show("Orkowie zbeszcześcili świątynię!");
                    ElvishBuildings.LevelOfTemple -= reductionLvlOfBuild;
                }
                if (destroyedBuilding == 3)
                {
                    //MessageBox.Show("Orkowie spalili elficki fikuśny budynek!");
                    ElvishBuildings.LevelOfElvishBuilding -= reductionLvlOfBuild;
                }
            }
        }

    }
}