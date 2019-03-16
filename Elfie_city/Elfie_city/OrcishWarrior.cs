using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class OrcishWarrior : OrcishUnit
    {
        // Statyczna lista obiektow tej klasy
        public static List<OrcishWarrior> OrcishList = new List<OrcishWarrior>();

        // statyczna zmienna przechowujaca obrazenia elfickiego wojownika
        public static new int Damage = 3;
        // statyczna zmienna przechowujaca punkty zycia elfickiego wojownika
        public static new int HealthPoints = 15;

        public OrcishWarrior()
        {
            OrcishList.Add(this);
        }
    }
}
