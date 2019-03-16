using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public class OrcishCommander : OrcishUnit
    {
        // lista zawierajaca obiekty klasy ElvishArcher
        public static List<OrcishCommander> OrcishList = new List<OrcishCommander>();

        // statyczna zmienna przechowujaca obrazenia elfickiego lucznika
        public static new int Damage = 12;
        // statyczna zmienna przechowujaca punkty zycia elfickiego lucznika
        public static new int HealthPoints = 80;

        public OrcishCommander()
        {
            OrcishList.Add(this);
        }
    }
}
