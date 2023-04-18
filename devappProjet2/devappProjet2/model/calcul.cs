using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devappProjet2.model
{
    internal class calcul
    {
        float totalCapital, tauxInteret;
        int periode;
        string? frequence,nom, prenom;
        

        public calcul() { }

        public calcul(float totalCapital, float tauxInteret, int periode, string? frequence, string? nom, string? prenom)
        {
            this.totalCapital = totalCapital;
            this.tauxInteret = tauxInteret;
            this.periode = periode;
            this.frequence = frequence;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}
