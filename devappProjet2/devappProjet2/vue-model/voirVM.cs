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
        double _totalCapital;
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
                TotalCapital = value.TotalCapital;
                
                

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
                tauxPeriode = ((value.TauxInteret / 100) / nbMensualiteParAnnee);

                Mensualite = (value.TotalCapital * tauxPeriode) / (1 - Math.Pow((1 + tauxPeriode), -nbPaiementTotal));
                CreateListPaiements();
            }
            
        }
        public double InteretTotal
        {
            get { return _interetTotal; }
            set
            {
                _interetTotal = value;
            }
        }
        private double tauxPeriode { get; set; }

        public double TotalCapital
        {
            get { return _totalCapital; }
            set { _totalCapital = value; }
        }

        public double CoutTotal
        {
            get { return _coutTotal; }
            set
            {
                _coutTotal = value;
            }
        }
        public double Mensualite
        {
            get { return _mensualite; }
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
        double balance { get; set; }
        private void CreateListPaiements()
        {
            Paiements= new List<Paiements>();
            balance=TotalCapital;

            for(int i=0;i<nbPaiementTotal;i++)
            {
                double PaiementInteret = balance * tauxPeriode;
                double PaiementCapital = Mensualite - PaiementInteret;
                balance = balance - PaiementCapital;
                
                Paiements p = new Paiements(i+1,Mensualite,PaiementCapital,PaiementInteret,balance);

                Paiements.Add(p);
            }
        }
    }
}
