using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devappProjet2.model;
using devappProjet2.vue;

namespace devappProjet2.vue_model
{
    internal class voirVM
    {
        calcul _calcul;
        double _interetTotal;
        double _coutTotal;
        double _mensualite;
        int nbPaiementTotal;
        int nbMensualiteParAnnee;

        public voirVM() 
        {
            
        }

        public calcul Calcul
        {
            get { return _calcul; }
            set
            {
                _calcul = value;
                InteretTotal = (value.TotalCapital * value.TauxInteret / 100);
                CoutTotal = InteretTotal + value.TotalCapital;

                
                

                if(value.Frequence=="Mensuel")
                {
                    nbMensualiteParAnnee = 12;
                }
                if(value.Frequence == "Bimensuel")
                {
                    nbMensualiteParAnnee = 24;
                }
                if (value.Frequence == "Bimestriel")
                {
                    nbMensualiteParAnnee = 6;
                }

                nbPaiementTotal = ((value.Periode / 12) * nbMensualiteParAnnee);

                Mensualite = (CoutTotal * (value.TauxInteret/100) / (double)nbMensualiteParAnnee) / (1 - MathF.Pow((float)(1 + ((value.TauxInteret/100) / (double)nbMensualiteParAnnee)), nbPaiementTotal*-1));
                CreateListPaiements();
            }
            
        }
        public double InteretTotal
        {
            get { return Math.Round(_interetTotal); }
            set
            {
                _interetTotal = value;
            }
        }

        public double CoutTotal
        {
            get { return Math.Round(_coutTotal,2); }
            set
            {
                _coutTotal = value;
            }
        }
        public double Mensualite
        {
            get { return Math.Round(_mensualite); }
            set
            {
                _mensualite = value;
            }
        }
        private List<Paiements> _paiements;

        public List<Paiements> Paiements
        {
            get { return _paiements; }
            set
            {
                _paiements= value;
            }
        }

        private void CreateListPaiements()
        {
            Paiements= new List<Paiements>();

            for(int i=0;i<nbPaiementTotal;i++)
            {
                double total = 0;

                for(int j=0;j<i;j++)
                {
                    total += Paiements[j].Paiement;
                }

                total += Mensualite;

                Paiements p = new Paiements(i,Mensualite,Mensualite/2,Mensualite/2,CoutTotal-total);

                Paiements.Add(p);
            }
        }
    }
}
