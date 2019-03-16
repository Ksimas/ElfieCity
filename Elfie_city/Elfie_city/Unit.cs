using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elfie_city
{
    public abstract class Unit
    {
        // punkty życia jednostki
        public int HealthPoints { get; set; }
        // zadawane obrażenia jednostki
        public int Damage { get; set; }
        // liczba jednostek

    }
}
