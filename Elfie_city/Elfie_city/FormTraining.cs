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
    public partial class FormTraining : Form
    {

        public FormTraining()
        {
            InitializeComponent();
        }

        private void FormTraining_Load(object sender, EventArgs e)
        {
            // ustawia obraz elfickiego łucznika, obraz znajduje sie w resources projektu
            pictureBoxElvishArcher.Image = Properties.Resources.elvishArcher2;
            // ustawia obraz elfickiego wojownika, obraz znajduje sie w resources projektu
            pictureBoxElvishWarrior.Image = Properties.Resources.elvishWarrior;
            // ustawia obraz elfickiego mistrza, obraz znajduje sie w resources projektu
            pictureBoxElvishMaster.Image = Properties.Resources.elvishMaster2;

            labelElvishArcherQuantity.Text = ElvishArcher.ElvishList.Count.ToString();
            labelElvishWarriorQuantity.Text = ElvishWarrior.ElvishList.Count.ToString();
            labelElvishMasterQuantity.Text = ElvishMaster.ElvishList.Count.ToString();

            // Tworzenie obiektu klasy ElvishArcher i wyswietlnie w poszczegolnych labelach kosztow treningow jednostki elfi lucznik
            int[] cost = ElvishArcher.TrainingCost();
            labelElvishArcherTrainingCostFood.Text = cost[0].ToString();
            labelElvishArcherTrainingCostWood.Text = cost[1].ToString();
            labelElvishArcherTrainingCostStone.Text = cost[2].ToString();
            labelElvishArcherTrainingCostIron.Text = cost[3].ToString();
            labelElvishArcherTrainingCostCrystals.Text = cost[4].ToString();
            labelElvishArcherTrainingCostPopulation.Text = cost[5].ToString();

            // tworzenie obiektu klasy ElvishWarrior i wyswietlenie jego kosztow szkolenia
            cost = ElvishWarrior.TrainingCost();
            labelElvishWarriorTrainingCostFood.Text = cost[0].ToString();
            labelElvishWarriorTrainingCostWood.Text = cost[1].ToString();
            labelElvishWarriorTrainingCostStone.Text = cost[2].ToString();
            labelElvishWarriorTrainingCostIron.Text = cost[3].ToString();
            labelElvishWarriorTrainingCostCrystals.Text = cost[4].ToString();
            labelElvishWarriorTrainingCostPopulation.Text = cost[5].ToString();

            // Wyswietlnie w poszczegolnych labelach kosztow treningow jednostki elfi mistrz
            cost = ElvishMaster.TrainingCost();
            labelElvishMasterTrainingCostFood.Text = cost[0].ToString();
            labelElvishMasterTrainingCostWood.Text = cost[1].ToString();
            labelElvishMasterTrainingCostStone.Text = cost[2].ToString();
            labelElvishMasterTrainingCostIron.Text = cost[3].ToString();
            labelElvishMasterTrainingCostCrystals.Text = cost[4].ToString();
            labelElvishMasterTrainingCostPopulation.Text = cost[5].ToString();

            // wyswietli czas szkolenia poszczegolnyc jednostek
            labelElvishArcherTrainingCostTime.Text = (ElvishArcher.TrainingTime()/ 1000).ToString();
            labelElvishWarriorTrainingCostTime.Text = (ElvishWarrior.TrainingTime() / 1000).ToString();
            labelElvishMasterTrainingCostTime.Text = (ElvishMaster.TrainingTime() / 1000).ToString();
            // timer aktualizuje wyswietlana liczbe jednostek
            timerUpdater.Interval = 100;
            timerUpdater.Start();

        }

        /// <summary>
        /// Funckja sprawdzajaca czy uzytkownik posiada wystarczajaca ilosc zasobow, aby rozpoczac szkolenie jednostki
        /// </summary>
        /// <param name="costFood"></param>
        /// <param name="costWood"></param>
        /// <param name="costStone"></param>
        /// <param name="costIron"></param>
        /// <param name="costCrystals"></param>
        /// <param name="costPopulation"></param>
        /// <returns></returns>
        private bool IfEnoughtResources(Label costFood, Label costWood, Label costStone, Label costIron, Label costCrystals, Label costPopulation)
        {
            int freePopulation = Convert.ToInt32(Math.Round(Resources.Population / 2.0)) - ElvishArcher.ElvishList.Count - ElvishWarrior.ElvishList.Count - Int32.Parse(labelElvishMasterTrainingCostPopulation.Text) * ElvishMaster.ElvishList.Count;
            if (Resources.ResourcesFood >= Int32.Parse(costFood.Text) &&
                Resources.ResourcesWood >= Int32.Parse(costWood.Text) &&
                Resources.ResoucresStone >= Int32.Parse(costStone.Text) &&
                Resources.ResoucresIron >= Int32.Parse(costIron.Text) &&
                Resources.ResoucresCrystals >= Int32.Parse(costCrystals.Text) &&
                freePopulation >= Int32.Parse(costPopulation.Text)
                )
            {
                Resources.ResourcesFood -= Int32.Parse(costFood.Text);
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
        /// Funckja wywolywana podczas klikniecia na przycisk z zamiaerem treningu elfiego lucznika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonElvishArcherTrain_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy uzytkownik posiada wystarczajaca ilosc zasobow
            if (IfEnoughtResources(labelElvishArcherTrainingCostFood, labelElvishArcherTrainingCostWood, labelElvishArcherTrainingCostStone, labelElvishArcherTrainingCostIron, labelElvishArcherTrainingCostCrystals, labelElvishArcherTrainingCostPopulation) == true)
            {
                // ustawienie timera
                timerElvishArcherTraining.Interval = ElvishArcher.TrainingTime();
                // ustawienie timera odpowiedzialnego za progressbar
                timerElvishArcherProgressBar.Interval = ElvishArcher.TrainingTime() / 110+1;
                // wystartowanie timera odpowiedzialnego za progressbar
                timerElvishArcherProgressBar.Start();
                // wystartowanie timera
                timerElvishArcherTraining.Start();
                // zablokowanie klawisza
                buttonElvishArcherTrain.Enabled = false;

            }
            else
            {
                MessageBox.Show("Brak wystarczajacych ilosci zasobow");
            }
        }
        /// <summary>
        /// Funkcja wywolywana podczas klikniecia na przyskich w zamiarze szkolenia elfickiego wojownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonElvishWarriorTrain_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy uzytkownik posiada wystarczajaca ilosc zasobow
            if (IfEnoughtResources(labelElvishWarriorTrainingCostFood, labelElvishWarriorTrainingCostWood, labelElvishWarriorTrainingCostStone, labelElvishWarriorTrainingCostIron, labelElvishWarriorTrainingCostCrystals, labelElvishWarriorTrainingCostPopulation) == true)
            {
                // ustawienie timera 
                timerElvishWarriorTraining.Interval = ElvishWarrior.TrainingTime();
                // ustawienie timera odpowiedzialnego za progressbar
                timerElvishWarriorProgressBar.Interval = timerElvishWarriorTraining.Interval / 110+1;
                // wystartowanie timera odpowiedzialnego za progressbar
                timerElvishWarriorProgressBar.Start();
                // wystartowanie timera
                timerElvishWarriorTraining.Start();
                // zablokowanie klawisza
                buttonElvishWarriorTrain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Brak wystarczajacych ilosci zasobow");
            }
        }

        /// <summary>
        /// funkcja reagujaca na klikniecie przycisku odpowiedzialnego za szkolenie elfkieckiego mistrza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonElvishMasterTrain_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy uzytkownik posiada wystarczajaca ilosc zasobow
            if (IfEnoughtResources(labelElvishMasterTrainingCostFood, labelElvishMasterTrainingCostWood, labelElvishMasterTrainingCostStone, labelElvishMasterTrainingCostIron, labelElvishMasterTrainingCostCrystals, labelElvishMasterTrainingCostPopulation) == true)
            {
                // ustawienie timera
                timerElvishMasterTraining.Interval = ElvishMaster.TrainingTime();
                // ustawienie timera odpowiedzialnego za progressbar
                timerElvishMasterProgressBar.Interval = timerElvishMasterTraining.Interval / 110+1;
                // wystartowanie timera odpowiedzialnego za progressbar
                timerElvishMasterProgressBar.Start();
                // wystartowanie timera
                timerElvishMasterTraining.Start();
                // zablokowanie klawisza
                buttonElvishMasterTrain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Brak wystarczajacych ilosci zasobow");
            }
        }
        /// <summary>
        /// Timer odmierzajacy czas szkolenia elfickiego lucznika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerElvishArcherTraining_Tick(object sender, EventArgs e)
        {
            // zatrzymuje timer
            timerElvishArcherTraining.Stop();
            // zatrzymuje timer odpowiedzialny za progressbar
            timerElvishArcherProgressBar.Stop();
            // resetuje progressBar
            progressBarElvishArcherTraining.Value = 0;
            // odblokowuje klawisz szkolenia kolejnego elfickiego lucnzika

            ElvishArcher newArcher = new ElvishArcher();

            buttonElvishArcherTrain.Enabled = true;

        }

        /// <summary>
        /// timer odmierzajacy czas szkolenia jednostki elficki wojownik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerElvishWarriorTraining_Tick(object sender, EventArgs e)
        {
            // zatrzymuje timer
            timerElvishWarriorTraining.Stop();
            // zatrzymanie timera od progressBaru
            timerElvishWarriorProgressBar.Stop();
            // stworzenie jednostki
            ElvishWarrior newWarrior = new ElvishWarrior();
            // zresetowanie progressBaru
            progressBarElvishWarriorTraining.Value = 0;
            // odblokowuje klawisz szkolenia kolejnego elfickiego wojownika
            buttonElvishWarriorTrain.Enabled = true;
        }

        /// <summary>
        /// timer odmierzajacy czas szkolenia jednostki elficki mistrz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerElvishMasterTraining_Tick(object sender, EventArgs e)
        {
            // zatrzymuje timer
            timerElvishMasterTraining.Stop();
            // zatrzymuje timer od progressBaru
            timerElvishMasterProgressBar.Stop();
            // stworzenie obiektu klasy elfickiego mistrza
            ElvishMaster newMaster = new ElvishMaster();
            // wyzerowanie progressbara
            progressBarElvishMasterTraining.Value = 0;
            // odblokowuje klawisz szkolenia elfickiego mistrza
            buttonElvishMasterTrain.Enabled = true;
        }

        /// <summary>
        /// timer aktualizujacy obecna ilosc jednostek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdater_Tick(object sender, EventArgs e)
        {

            labelElvishArcherQuantity.Text = ElvishArcher.ElvishList.Count.ToString();
            labelElvishWarriorQuantity.Text = ElvishWarrior.ElvishList.Count.ToString();
            labelElvishMasterQuantity.Text = ElvishMaster.ElvishList.Count.ToString();
            
            labelElvishArcherTrainingCostTime.Text = (ElvishArcher.TrainingTime() / 1000).ToString();
            labelElvishWarriorTrainingCostTime.Text = (ElvishWarrior.TrainingTime() / 1000).ToString();
            labelElvishMasterTrainingCostTime.Text = (ElvishMaster.TrainingTime() / 1000).ToString();

        }

        private void timerElvishArcherProgressBar_Tick(object sender, EventArgs e)
        {
            progressBarElvishArcherTraining.Increment(1);
        }

        private void timerElvishWarriorProgressBar_Tick(object sender, EventArgs e)
        {
            progressBarElvishWarriorTraining.Increment(1);
        }

        private void timerElvishMasterProgressBar_Tick(object sender, EventArgs e)
        {
            progressBarElvishMasterTraining.Increment(1);

        }
        
    }
}