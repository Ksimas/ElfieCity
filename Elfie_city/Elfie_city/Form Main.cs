using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Elfie_city
{
    public partial class FormMain : Form
    {
        // tworzenie obiektu, ktory bedzie wywolywal metode odpowiedzialna za muzyke w tle
        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.Marcin_Przybylowicz___Priscillas_Song__Wolven_Storm_Instrumental_);

        public FormMain()
        {
            InitializeComponent();

            for (int i = 1; i <= 3; i++)
            {
                OrcishWarrior orcishWarrior = new OrcishWarrior();
            }
            for (int i = 1; i <= 3; i++)
            {
                OrcishCrossbowman newCrossbowman = new OrcishCrossbowman();
            }
            // wlaczenie muzyki w tle
            soundPlayer.PlayLooping();

        }

        // zmienna zliczajaca liczbe atakow szczurow na miasto
        int ratAttackCounter = 1;
        // zmienna zliczajaca ilosc pozarow w magazynie
        int fireInWarehouseCounter = 1;


        /// <summary>
        /// Funkcja odpowiedzialna za glowne okno, ustawia tlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ustawia obraz Efliego miasta na tlo,  obraz znajduje sie w resources projektu
            pictureBoxBackgroundElfieCity.Image = Properties.Resources.imageOfElfieCity;


            // timer odmierza czas, 1000ms = 1 sekunda
            timerCounter.Interval = 2000;
            // wywołanie startu timera, ktory odpowiada za przyrost zasobow
            timerCounter.Start();

            // timer odmierzajacy czas do wyswietlenia ostrzezenia
            // 1 min przed atakiem orków
            timerWarnings.Interval = 210000;
            timerWarnings.Start();

            // 270 000ms = 4min 30sec 
            timerOrcsAttack.Interval = 270000;
            timerOrcsAttack.Start();

            // 1000ms = 1sekunda
            timerCheckIfDefeat.Interval = 1000;
            timerCheckIfDefeat.Start();

            // 10 000ms = 10sec
            timerCrystalsProduction.Interval = 10000;
            timerCrystalsProduction.Start();

            // 400 000 = 6min 20sec
            timerRatAttack.Interval = 400000;
            timerRatAttack.Start();

            // ustawienie timera i wystartowanie
            timerAccidents.Interval = 320000;
            timerAccidents.Start();

            // utstawienie timera wywolujacego pozar w magazynie
            timerFireInWarehouse.Interval = 500000;
            timerFireInWarehouse.Start();
        }

        /// <summary>
        /// Funkcja aktualizujaca ilosc zasobow[zywnosc, drewno, kamien, zelazo, populacja] na podstawie funkcji, ktore obliczaja przyrost 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timerProduction_Tick(object sender, EventArgs e)
        {
            // wpisuje do zmiennej wskazujacej ilosc zasobow jedzenia obecna ilosc + przyrost w jednostce czasu
            Resources.ResourcesFood += Resources.FoodGrowth();
            if (Resources.ResourcesFood < 0)
            {
                Resources.ResourcesFood = 0;
                labelResourcesFood.BackColor = Color.Red;
            }
            else
                labelResourcesFood.BackColor = Color.Transparent;
            // wyswietla/aktualizuje w label ilosc zasobow jedzenia
            labelResourcesFood.Text = Resources.ResourcesFood.ToString();
            // wyswietla/aktualizuje  ilosc zasobow drewna
            Resources.ResourcesWood += Resources.WoodGrowth();
            labelResourcesWood.Text = Resources.ResourcesWood.ToString();
            // zabezpieczenie przed ujemnną ilością surowców
            if (Resources.ResourcesWood < 0)
            {
                Resources.ResourcesWood = 0;
            }
            // wyswietla/aktualizuje ilosc zasobow kamienia
            Resources.ResoucresStone += Resources.StoneGrowth();
            labelResourcesStone.Text = Resources.ResoucresStone.ToString();
            // zabezpieczenie przed ujemnną ilością surowców
            if (Resources.ResoucresStone < 0)
            {
                Resources.ResoucresStone = 0;
            }
            // wyswietla/aktualizuje ilosc zasobow zelaza
            Resources.ResoucresIron += Resources.IronGrowth();
            labelResourcesIron.Text = Resources.ResoucresIron.ToString();
            // zabezpieczenie przed ujemnną ilością surowców
            if (Resources.ResoucresIron < 0)
            {
                Resources.ResoucresIron = 0;
            }
            // wysietla/aktualizuje populacje miasta
            Resources.Population += Resources.PopulationGrowth();
            labelResourcesPopulation.Text = Resources.Population.ToString();
        }
        /// <summary>
        /// Otwiera okno FormBuildings, gdzie mozna budowac budynki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            FormBuildings windowBuilding = new FormBuildings();
            windowBuilding.Show();
        }

        /// <summary>
        ///  przycisk odpowiedzialny za otworzenie okna z budynkami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTraining_Click(object sender, EventArgs e)
        {
            FormTraining windowTraining = new FormTraining();
            windowTraining.Show();
        }

        /// <summary>
        /// Timer odmierzajacy czas do ataku orkow na miasto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOrcsAttack_Tick(object sender, EventArgs e)
        {

            MessageBox.Show("ORKOWIE ATAKUJĄ!");
            int[] resultOfBattle = OrcsAttack.BattleVsOrcs();
            if (resultOfBattle[0] == 1)
            {
                MessageBox.Show("Miasto zostało obronione!");
                MessageAboutResultOfBattleVsOrcs(resultOfBattle);
            }
            else if (resultOfBattle[0] == 2)
            {
                MessageBox.Show("Nikt z bitwy nie wyszedł cało!");
                MessageAboutResultOfBattleVsOrcs(resultOfBattle);
            }
            else
            {
                MessageBox.Show("Obrońcy polegli! Miasto zostało złupione!");
                MessageAboutResultOfBattleVsOrcs(resultOfBattle);
            }
            timerWarnings.Start();
        }
        /// <summary>
        /// Funkcja wyswietlajaca MessageBox zawierajacy informacje o poleglych elfow w bitwie z orkami
        /// </summary>
        /// <param name="resultOfBattle"></param>
        private void MessageAboutResultOfBattleVsOrcs(int[] resultOfBattle)
        {
            MessageBox.Show("Miasto zaatakowało: " + resultOfBattle[1] + " orków wojoników, " + resultOfBattle[2] + " orków kuszników, "
                + resultOfBattle[3] + " orków dowódców. W bitwie poległo: " + resultOfBattle[4] + " elfich łuczników, " +
                +resultOfBattle[5] + " elfich wojowników, " + resultOfBattle[6] + " elfich mistrzów.");
        }

        /// <summary>
        /// Timer, ktory po odmierzeniu czasu wyswietla komunikat z ostrzezeniem o nadchodzacym ataku orkow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerWarnings_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Zwiadowcy donoszą, że lada moment orkowie zaatakują nasze miasto!", "Ostrzeżenie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            timerWarnings.Stop();
        }


        /// <summary>
        /// Timer co zadany interwał sprawdza, czy warunki kontyuowania symulacji sa spelnione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCheckIfDefeat_Tick(object sender, EventArgs e)
        {
            if (Defeat.EndBceauseOfLowPopulation() == true)
            {
                timerCheckIfDefeat.Stop();
                this.Enabled = false;
                timerWarnings.Stop();
                timerOrcsAttack.Stop();
                timerCounter.Stop();
                timerRatAttack.Stop();
                timerAccidents.Stop();
                timerCrystalsProduction.Stop();
                timerFireInWarehouse.Stop();
                MessageBox.Show("Populacja miasta zniżyła się do zbyt niskiego poziomu! Dalsza symulacja nie jest możliwa!");
            }
        }

        /// <summary>
        /// Timer odpowiedzialny jedynie za przyrost zasobów kryształu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCrystalsProduction_Tick(object sender, EventArgs e)
        {
            // wyswietla/aktualizuje ilosc zasobow krysztalow
            Resources.ResoucresCrystals += Resources.CrystalsGrowth();
            if (Resources.ResoucresCrystals < 0)
            {
                Resources.ResoucresCrystals = 0;
            }
            labelResourcesCrystals.Text = Resources.ResoucresCrystals.ToString();

        }
        /// <summary>
        /// Funkcja symulujaca atak szczurow na miasto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRatAttack_Tick(object sender, EventArgs e)
        {
            if (ElvishBuildings.LevelOfInfrastructure <= ratAttackCounter)
            {
                MessageBox.Show("Szczury! Sczury panoszą się po mieśce! One jedzą nasze zapasay żywności i niszczą zapasy drewna!");

                if (ElvishBuildings.LevelOfHuntingBuilding > ratAttackCounter)
                    Resources.ResourcesFood -= Convert.ToInt32(Math.Round(Resources.ResourcesFood * 0.70));
                Resources.ResourcesFood -= -50;
            }
            ratAttackCounter++;
        }

        /// <summary>
        /// Funkcja co jakis czas wywoluje katastrofe w jednym z pseudolosowanych miejsc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAccidents_Tick(object sender, EventArgs e)
        {
            Random randomNumber = new Random();
            // pseudlosowanie miejsca wypadku    1-chata mysliwych 2- tartak,  3- kamieniołom,  4-huta,  5-elfickie domy
            int accidentPlace = randomNumber.Next(1, 6);
            // pseudolosowanie o ile poziom budynku ulegnie zmianie
            int reductionLvlOfBuild = randomNumber.Next(1, 3);

            if (accidentPlace == 1)
            {
                MessageBox.Show("Nieszczęśliwy wypadek przydarzył się w chacie myśliwych! (Poziom budynku obniżył się)");
                ElvishBuildings.LevelOfHuntingBuilding -= reductionLvlOfBuild;
            }
            if (accidentPlace == 2)
            {
                MessageBox.Show("Nieszczęśliwy wypadek przydarzył się w tartaku! (Poziom budynku obniżył się)");
                ElvishBuildings.LevelOfWoodshet -= reductionLvlOfBuild;
            }
            if (accidentPlace == 3)
            {
                MessageBox.Show("Nieszczęśliwy wypadek przydarzył się w kamieniołomie! (Poziom budynku obniżył się)");
                ElvishBuildings.LevelOfQuarry -= reductionLvlOfBuild;
            }
            if (accidentPlace == 4)
            {
                MessageBox.Show("Nieszczęśliwy wypadek przydarzył się w hucie! (Poziom budynku obniżył się)");
                ElvishBuildings.LevelOfIronWorks -= reductionLvlOfBuild;
            }
            if (accidentPlace == 5)
            {
                MessageBox.Show("Jeden z domów nieszczęśliwie uległ zawaleniu! (Elfy nie mają gdzie mieszkać!)");
                ElvishBuildings.LevelOfHouses -= reductionLvlOfBuild;
            }
            if (ElvishBuildings.LevelOfElvishBuilding == 0)
            {
                timerAccidents.Interval = 60000;
            }
            else
                timerAccidents.Interval = ElvishBuildings.LevelOfElvishBuilding * 60000;
        }
        /// <summary>
        /// Timer wywolujacy pozar w magazynie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerFireInWarehouse_Tick(object sender, EventArgs e)
        {
            if (ElvishBuildings.LevelOfTemple < fireInWarehouseCounter)
            {
                MessageBox.Show("W magazynie wystąpił pożar! Wszystkie zapasy drewna spłonęły!");
                Resources.ResourcesWood = 0;
            }
            fireInWarehouseCounter++;
        }

        /// <summary>
        /// Funkcja otwierajaca okno menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Activate();
            menu.ShowDialog();z
        }
    }

}
