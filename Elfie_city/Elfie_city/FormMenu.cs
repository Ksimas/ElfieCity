using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Elfie_city
{
    public partial class FormMenu : Form
    {
        // obiekt klas XmlDocument
        XmlDocument xDoc = new XmlDocument();

        // zmienne przechowujace ścieżkę do pliku z danymi
        public static string first_part = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        public static string path = first_part + "/data.xml";

        public FormMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja zamykająca okienko
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Funkcja zapisująca obecny stan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // otwieranie pliku 

            xDoc.Load(path);

            // Tworzenie elementów

            XmlNode save = xDoc.CreateElement("save");

            XmlNode saveName = xDoc.CreateElement("saveName");

            // zasoby
            XmlNode resources = xDoc.CreateElement("resources");
            XmlNode food = xDoc.CreateElement("food");
            XmlNode wood = xDoc.CreateElement("wood");
            XmlNode stone = xDoc.CreateElement("stone");
            XmlNode iron = xDoc.CreateElement("iron");
            XmlNode crystals = xDoc.CreateElement("crystals");
            XmlNode population = xDoc.CreateElement("population");

            // poziomy budynkow
            XmlNode elvishBuildings = xDoc.CreateElement("elvishBuildings");
            XmlNode huntingBuild = xDoc.CreateElement("huntingBuild");
            XmlNode woodshet = xDoc.CreateElement("woodshet");
            XmlNode quarry = xDoc.CreateElement("quarry");
            XmlNode ironWorks = xDoc.CreateElement("ironWorks");
            XmlNode crystalMine = xDoc.CreateElement("crystalMine");
            XmlNode houses = xDoc.CreateElement("houses");
            XmlNode temple = xDoc.CreateElement("temple");
            XmlNode elvishBuilding = xDoc.CreateElement("elvishBuilding");
            XmlNode martialArtsSchool = xDoc.CreateElement("martialArtsSchool");
            XmlNode infrastructure = xDoc.CreateElement("infrastructure");

            // liczby jednostek
            XmlNode elvishUnits = xDoc.CreateElement("elvishUnits");
            XmlNode elvishArcher = xDoc.CreateElement("elvishArcher");
            XmlNode elvishWarrior = xDoc.CreateElement("elvishWarrior");
            XmlNode elvishMaster = xDoc.CreateElement("elvishMaster");

            XmlNode orcishUnits = xDoc.CreateElement("orcishUnits");
            XmlNode orcishCrossbowman = xDoc.CreateElement("orcishCrossbowman");
            XmlNode orcishWarrior = xDoc.CreateElement("orcishWarrior");
            XmlNode orcishCommander = xDoc.CreateElement("orcishCommander");

            // licznik potyczek z orkami
            XmlNode battleCounter = xDoc.CreateElement("battleCounter");


            // inicjalizacja stworzonych elementów

            saveName.InnerText = textBoxSaveName.Text;

            food.InnerXml = Resources.ResourcesFood.ToString();
            wood.InnerXml = Resources.ResourcesWood.ToString();
            stone.InnerXml = Resources.ResoucresStone.ToString();
            iron.InnerXml = Resources.ResoucresIron.ToString();
            crystals.InnerXml = Resources.ResoucresCrystals.ToString();
            population.InnerXml = Resources.Population.ToString();

            huntingBuild.InnerXml = ElvishBuildings.LevelOfHuntingBuilding.ToString();
            woodshet.InnerXml = ElvishBuildings.LevelOfWoodshet.ToString();
            quarry.InnerXml = ElvishBuildings.LevelOfWoodshet.ToString();
            ironWorks.InnerXml = ElvishBuildings.LevelOfIronWorks.ToString();
            crystalMine.InnerXml = ElvishBuildings.LevelOfCrystalMine.ToString();
            houses.InnerXml = ElvishBuildings.LevelOfHouses.ToString();
            temple.InnerXml = ElvishBuildings.LevelOfTemple.ToString();
            elvishBuilding.InnerXml = ElvishBuildings.LevelOfElvishBuilding.ToString();
            martialArtsSchool.InnerXml = ElvishBuildings.LevelOfMartialArtsSchool.ToString();
            infrastructure.InnerXml = ElvishBuildings.LevelOfInfrastructure.ToString();

            elvishArcher.InnerXml = ElvishArcher.ElvishList.Count.ToString();
            elvishWarrior.InnerXml = ElvishWarrior.ElvishList.Count.ToString();
            elvishMaster.InnerXml = ElvishMaster.ElvishList.Count.ToString();

            orcishCrossbowman.InnerXml = OrcishCrossbowman.OrcishList.Count.ToString();
            orcishWarrior.InnerXml = OrcishWarrior.OrcishList.Count.ToString();
            orcishCommander.InnerXml = OrcishCommander.OrcishList.Count.ToString();

            battleCounter.InnerXml = OrcsAttack.battleCounter.ToString();


            // powiązywanie elementów z węzłem 

            resources.AppendChild(food);
            resources.AppendChild(wood);
            resources.AppendChild(stone);
            resources.AppendChild(iron);
            resources.AppendChild(crystals);
            resources.AppendChild(population);

            elvishBuildings.AppendChild(huntingBuild);
            elvishBuildings.AppendChild(woodshet);
            elvishBuildings.AppendChild(quarry);
            elvishBuildings.AppendChild(ironWorks);
            elvishBuildings.AppendChild(crystalMine);
            elvishBuildings.AppendChild(houses);
            elvishBuildings.AppendChild(temple);
            elvishBuildings.AppendChild(elvishBuilding);
            elvishBuildings.AppendChild(martialArtsSchool);
            elvishBuildings.AppendChild(infrastructure);

            elvishUnits.AppendChild(elvishArcher);
            elvishUnits.AppendChild(elvishWarrior);
            elvishUnits.AppendChild(elvishMaster);

            orcishUnits.AppendChild(orcishCrossbowman);
            orcishUnits.AppendChild(orcishWarrior);
            orcishUnits.AppendChild(orcishCommander);

            save.AppendChild(saveName);
            save.AppendChild(resources);
            save.AppendChild(elvishBuildings);
            save.AppendChild(elvishUnits);
            save.AppendChild(orcishUnits);
            save.AppendChild(battleCounter);

            xDoc.DocumentElement.AppendChild(save);


            // zapisywanie 

            xDoc.Save(path);
            this.Close();
            MessageBox.Show("Zapisano!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Funkcja wczytująca wcześniej zapisany stan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // próba otworzenia pliku
            try
            {
                xDoc.Load(path);
            }
            catch
            {
            MessageBox.Show("Otworzenie pliku z zapisami nie powiodło sie", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            // szukanie zapisu o podanej nazwie
            foreach (XmlNode node in xDoc.SelectNodes("saves/save"))
            {
                // jezeli znalazlo podaną nazwę zapisu w bazie xml to wczytuje z niej zawarte dane
                if (node.SelectSingleNode("saveName").InnerText == textBoxSaveName.Text)
                {
                    // wczytanie zasobów
                    Resources.ResourcesFood = Int32.Parse(node.SelectSingleNode("resources/food").InnerXml);
                    Resources.ResourcesWood = Int32.Parse(node.SelectSingleNode("resources/wood").InnerXml);
                    Resources.ResoucresStone = Int32.Parse(node.SelectSingleNode("resources/stone").InnerXml);
                    Resources.ResoucresIron = Int32.Parse(node.SelectSingleNode("resources/iron").InnerXml);
                    Resources.ResoucresCrystals = Int32.Parse(node.SelectSingleNode("resources/crystals").InnerXml);
                    Resources.Population = Int32.Parse(node.SelectSingleNode("resources/population").InnerXml);

                    // wczytanie poziomow budynkow
                    ElvishBuildings.LevelOfHuntingBuilding = Int32.Parse(node.SelectSingleNode("elvishBuildings/huntingBuild").InnerXml);
                    ElvishBuildings.LevelOfWoodshet = Int32.Parse(node.SelectSingleNode("elvishBuildings/woodshet").InnerXml);
                    ElvishBuildings.LevelOfQuarry = Int32.Parse(node.SelectSingleNode("elvishBuildings/quarry").InnerXml);
                    ElvishBuildings.LevelOfIronWorks = Int32.Parse(node.SelectSingleNode("elvishBuildings/ironWorks").InnerXml);
                    ElvishBuildings.LevelOfCrystalMine = Int32.Parse(node.SelectSingleNode("elvishBuildings/crystalMine").InnerXml);
                    ElvishBuildings.LevelOfHouses = Int32.Parse(node.SelectSingleNode("elvishBuildings/houses").InnerXml);
                    ElvishBuildings.LevelOfTemple = Int32.Parse(node.SelectSingleNode("elvishBuildings/temple").InnerXml);
                    ElvishBuildings.LevelOfElvishBuilding = Int32.Parse(node.SelectSingleNode("elvishBuildings/elvishBuilding").InnerXml);
                    ElvishBuildings.LevelOfMartialArtsSchool = Int32.Parse(node.SelectSingleNode("elvishBuildings/martialArtsSchool").InnerXml);
                    ElvishBuildings.LevelOfInfrastructure = Int32.Parse(node.SelectSingleNode("elvishBuildings/infrastructure").InnerXml);

                    // stworzenie takiej samej liczby jednostek elfow
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("elvishUnits/elvishArcher").InnerXml); i++)
                    {
                        ElvishArcher loadArcher = new ElvishArcher();
                    }
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("elvishUnits/elvishWarrior").InnerXml); i++)
                    {
                        ElvishWarrior loadWarrior = new ElvishWarrior();
                    }
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("elvishUnits/elvishMaster").InnerXml); i++)
                    {
                        ElvishMaster loadMaster = new ElvishMaster();
                    }
                    // stworzenie takiej samej liczby jednostek orków
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("orcishUnits/orcishCrossbowman").InnerXml); i++)
                    {
                        OrcishCrossbowman loadOrcishCrossbowman = new OrcishCrossbowman();
                    }
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("orcishUnits/orcishWarrior").InnerXml); i++)
                    {
                        OrcishWarrior loadWarrior = new OrcishWarrior();
                    }
                    for (int i = 1; i <= Int32.Parse(node.SelectSingleNode("orcishUnits/orcishCommander").InnerXml); i++)
                    {
                        OrcishCommander loadCommander = new OrcishCommander();
                    }

                    // wczytanie licznika potyczek
                    OrcsAttack.battleCounter = Int32.Parse(node.SelectSingleNode("battleCounter").InnerXml);

                    // zamkniecie okienka
                    this.Close();
                    // wyswietlenie wiadomosci
                    MessageBox.Show("Wczytano!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             
            }
        }
    }
}