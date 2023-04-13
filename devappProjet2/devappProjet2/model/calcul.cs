using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devappProjet2.model
{
    internal class calcul
    {
        float totalCapital;
        float tauxInteret;
        int periode;
        string? frequence;

        public calcul() { }

        public calcul(float totalCapital, float tauxInteret, int periode, string? frequence)
        {
            this.totalCapital = totalCapital;
            this.tauxInteret = tauxInteret;
            this.periode = periode;
            this.frequence = frequence;
        }
    }
}
