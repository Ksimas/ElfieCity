using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class OrcishCrossbowman : OrcishUnit
    {
        // Statyczna lista obiektow tej klasy
        public static List<OrcishCrossbowman> OrcishList = new List<OrcishCrossbowman>();

        // statyczna zmienna przechowujaca obrazenia elfickiego wojownika
        public static new int Damage = 5;
        // statyczna zmienna przechowujaca punkty zycia elfickiego wojownika
        public static new int HealthPoints = 5;

        public OrcishCrossbowman()
        {
            OrcishList.Add(this);
        }
    }
}
