using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elfie_city
{

    public partial class FormBuildings : Form
    {
        // zmienna, ktora bedzie przechowywala koszty budowy budynku
        int[] cost;

        public FormBuildings()
        {
            InitializeComponent();
        }

        private void FormBuildings_Load(object sender, EventArgs e)
        {
            // ustawienie timera aktualizujacego wyswietlanie aktualnych kosztow budynkow na 0.5sec
            timerUpdaterLvlOfBuildingsAndCostOfConstruct.Interval = 500;
            timerUpdaterLvlOfBuildingsAndCostOfConstruct.Start();
    
        }

        /// <summary>
        /// Funkcja wyswietlajaca koszt ulepszenia budynku na kolejny poziom
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="costWood"></param>
        /// <param name="costStone"></param>
        /// <param name="costIron"></param>
        /// <param name="costCrystals"></param>
        public static void ConstructionCostLabels(int[] cost, Label costWood, Label costStone, Label costIron, Label costCrystals)
        {
            costWood.Text = cost[0].ToString();
            costStone.Text = cost[1].ToString();
            costIron.Text = cost[2].ToString();
            costCrystals.Text = cost[3].ToString();
        }

        /// <summary>
        /// Funkcja na podstawie otrzymanych labelow w postaci argumentow, ktore zawieraja liczbe zasobów 
        /// sprawdza czy uzytkownik moze wybudowac/rozbudowac budynek, jezeli TAK to odejmuje od obecnych zasobow koszty budynku i zwraca 1,
        /// jezeli NIE to zwraca 0
        /// </summary>
        /// <param name="costWood"></param>
        /// <param name="costStone"></param>
        /// <param name="costIron"></param>
        /// <param name="costCrystals"></param>
        /// <returns></returns>
        private bool IfEnoughtResources(Label costWood, Label costStone, Label costIron, Label costCrystals)
        {

            if (Resources.ResourcesWood >= Int32.Parse(costWood.Text) &&
                Resources.ResoucresStone >= Int32.Parse(costStone.Text) &&
                Resources.ResoucresIron >= Int32.Parse(costIron.Text) &&
                Resources.ResoucresCrystals >= Int32.Parse(costCrystals.Text)
                )
            {
                Resources.ResourcesWood -= Int32.Parse(costWood.Text);
                Resources.ResoucresStone -= Int32.Parse(costStone.Text);
                Resources.ResoucresIron -= Int32.Parse(costIron.Text);
                Resources.ResoucresCrystals -= Int32.Parse(costCrystals.Text);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Funkcja ulepsza budynek chata mysliwska albo wyswietla informacje o zbyt malej ilosci zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUgradeHuntingBuild_Click(object sender, EventArgs e)
        {
            // wywolanie funkcji sprawdzajacej czy ilosc zasobow jest wystarczajaca
            if (IfEnoughtResources(labelHuntingBuildingCostWood, labelHuntingBuildingCostStone, labelHuntingBuildingCostIron, labelHuntingBuildingCostCrystals) == true)
            {
                // zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfHuntingBuilding += 1;
                //HountingBuildingConstructionCost();
                cost = ElvishBuildings.HuntingBuildingCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelHuntingBuildingCostWood, labelHuntingBuildingCostStone, labelHuntingBuildingCostIron, labelHuntingBuildingCostCrystals);
            }
            else
            {
                // wyswietlenie wiadomosci
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }

        /// <summary>
        /// Funkcja ulepsza budynek tartak albo wyswietla informacje o zbyt malej ilosci zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonUpgradeWoodshet_Click(object sender, EventArgs e)
        {
            // wywolanie funkcji sprawdzajacej czy ilosc zasobow jest wystarczajaca
            if (IfEnoughtResources(labelWoodshetCostWood, labelWoodshetCostStone, labelWoodshetCostIron, labelWoodshetCostCrystals) == true)
            {
                // zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfWoodshet += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.WoodshetCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelWoodshetCostWood, labelWoodshetCostStone, labelWoodshetCostIron, labelWoodshetCostCrystals);

            }
            else
            {
                // wyswietlenie wiadomosci
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }

        /// <summary>
        /// Funkcja ulepsza budynek kamieniołom albo wyswietla informacje o zbyt malej ilosci zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeQuarry_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelQuarryCostWood, labelQuarryCostStone, labelQuarryCostIron, labelQuarryCostCrystals) == true)
            {

                // zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfQuarry += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.QuarryCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelQuarryCostWood, labelQuarryCostStone, labelQuarryCostIron, labelQuarryCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }
        /// <summary>
        /// Funckja ulepsza budynek huta lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeIronWorks_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelIronWorksCostWood, labelIronWorksCostStone, labelIronWorksCostIron, labelIronWorksCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfIronWorks += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.IronWorksCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelIronWorksCostWood, labelIronWorksCostStone, labelIronWorksCostIron, labelIronWorksCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }
        /// <summary>
        /// Funckja ulepsza budynek kopalnia krysztalow lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeCrystalMine_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelCrystalMineCostWood, labelCrystalMineCostStone, labelCrystalMineCostIron, labelCrystalMineCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfCrystalMine += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.CrystalMineCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelCrystalMineCostWood, labelCrystalMineCostStone, labelCrystalMineCostIron, labelCrystalMineCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }

        /// <summary>
        /// Funckja ulepsza budynek domy lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeHouses_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelHousesCostWood, labelHousesCostStone, labelHousesCostIron, labelHousesCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfHouses += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.HousesCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelHousesCostWood, labelHousesCostStone, labelHousesCostIron, labelHousesCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }

        /// <summary>
        /// Funckja ulepsza budynek świąynia lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeTemple_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelTempleCostWood, labelTempleCostStone, labelTempleCostIron, labelTempleCostCrystals) == true)
            {
                // zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfTemple += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.TempleCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelTempleCostWood, labelTempleCostStone, labelTempleCostIron, labelTempleCostCrystals);
                labelLevelOfTemple.Text = ElvishBuildings.LevelOfTemple.ToString();
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }
        }
        /// <summary>
        /// Funckja ulepsza budynek świąynia lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeElvishBuilding_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelElvishBuildingCostWood, labelElvishBuildingCostStone, labelElvishBuildingCostIron, labelElvishBuildingCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfElvishBuilding += 1;
                // pobranie ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.ElvishBuildingCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelElvishBuildingCostWood, labelElvishBuildingCostStone, labelElvishBuildingCostIron, labelElvishBuildingCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }

        }
        /// <summary>
        /// Funckja ulepsza budynek szkola sztuki walki lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonUpgradeMartialArtsSchool_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelMartialArtsSchoolCostWood, labelMartialArtsSchoolCostStone, labelMartialArtsSchoolCostIron, labelMartialArtsSchoolCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfMartialArtsSchool += 1;
                // pobranie nowej ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.MartialArtsSchoolCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelMartialArtsSchoolCostWood, labelMartialArtsSchoolCostStone, labelMartialArtsSchoolCostIron, labelMartialArtsSchoolCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }

            // maksymalny poziom budynku,  na 20lv szkolenie jednostek trwa 0sec
            if (ElvishBuildings.LevelOfMartialArtsSchool == 20)
            {
                buttonUpgradeMartialArtsSchool.Enabled = false;
            }
        }
        /// <summary>
        /// Funckja ulepsza budynek infrastruktura lub wyswietla informacje o niewystarczajacych ilosciach zasobow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpgradeInfrastructure_Click(object sender, EventArgs e)
        {
            if (IfEnoughtResources(labelInfrastructureCostWood, labelInfrastructureCostStone, labelInfrastructureCostIron, labelInfrastructureCostCrystals) == true)
            {
                // Zwiekszenie poziomu budynku
                ElvishBuildings.LevelOfInfrastructure += 1;
                // pobranie nowej ceny rozbudowy budynku z klasy Buildings
                cost = ElvishBuildings.InfrastructureCost();
                // wywolanie funkcji, ktora wyswietli koszty rozbudowy na kolejny poziom budynku
                ConstructionCostLabels(cost, labelInfrastructureCostWood, labelInfrastructureCostStone, labelInfrastructureCostIron, labelInfrastructureCostCrystals);
            }
            else
            {
                MessageBox.Show("Niewystarczająca ilość zasobów!");
            }

        }

        private void timerUpdaterLvlOfBuildingsAndCostOfConstruct_Tick(object sender, EventArgs e)
        {
            // wyswietlenie aktualnego pozimu budynku chata mysliwska
            labelLevelOfHuntingBuilding.Text = ElvishBuildings.LevelOfHuntingBuilding.ToString();
            // wyswietlenie aktualnego pozimu budynku tartak
            labelLevelOfWoodshet.Text = ElvishBuildings.LevelOfWoodshet.ToString();
            // wyswietlenie aktualnego pozimu budynku kamieniolom
            labelLevelOfQuarry.Text = ElvishBuildings.LevelOfQuarry.ToString();
            // wyswietlenie aktualnego pozimu budynku huta
            labelLevelOfIronWorks.Text = ElvishBuildings.LevelOfIronWorks.ToString();
            // wyswietlenie aktualnego pozimu budynku kopalnia krysztalow
            labelLevelOfCrystalsMine.Text = ElvishBuildings.LevelOfCrystalMine.ToString();
            // wyswietlenie aktualnego pozimu budynku domy
            labelLevelOfHouses.Text = ElvishBuildings.LevelOfHouses.ToString();
            // wyswietlenie aktualnego pozimu budynku swiatynia
            labelLevelOfTemple.Text = ElvishBuildings.LevelOfTemple.ToString();
            // wyswietlenie aktualnego pozimu budynku fikusne elfickie budynki
            labelLevelOfElvishBuilding.Text = ElvishBuildings.LevelOfElvishBuilding.ToString();
            // wyswietlenie aktualnego pozimu budynku szkola sztuk walki
            labelLevelOfMartialArtsSchool.Text = ElvishBuildings.LevelOfMartialArtsSchool.ToString();
            // wyswietlenie aktualnego pozimu budynku infrastruktura
            labelLevelOfInfrastructure.Text = ElvishBuildings.LevelOfInfrastructure.ToString();

            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.HuntingBuildingCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelHuntingBuildingCostWood, labelHuntingBuildingCostStone, labelHuntingBuildingCostIron, labelHuntingBuildingCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.WoodshetCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelWoodshetCostWood, labelWoodshetCostStone, labelWoodshetCostIron, labelWoodshetCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.QuarryCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelQuarryCostWood, labelQuarryCostStone, labelQuarryCostIron, labelQuarryCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.IronWorksCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelIronWorksCostWood, labelIronWorksCostStone, labelIronWorksCostIron, labelIronWorksCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.CrystalMineCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelCrystalMineCostWood, labelCrystalMineCostStone, labelCrystalMineCostIron, labelCrystalMineCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.HousesCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelHousesCostWood, labelHousesCostStone, labelHousesCostIron, labelHousesCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.TempleCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelTempleCostWood, labelTempleCostStone, labelTempleCostIron, labelTempleCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.ElvishBuildingCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelElvishBuildingCostWood, labelElvishBuildingCostStone, labelElvishBuildingCostIron, labelElvishBuildingCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.MartialArtsSchoolCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelMartialArtsSchoolCostWood, labelMartialArtsSchoolCostStone, labelMartialArtsSchoolCostIron, labelMartialArtsSchoolCostCrystals);
            // pobranie aktualnej ceny z klasy Buildings
            cost = ElvishBuildings.InfrastructureCost();
            // wyswietlenie aktualnej ceny w labelach, ktore sa argumentami wywolywanej funkcji
            ConstructionCostLabels(cost, labelInfrastructureCostWood, labelInfrastructureCostStone, labelInfrastructureCostIron, labelInfrastructureCostCrystals);
        }
    }
}
