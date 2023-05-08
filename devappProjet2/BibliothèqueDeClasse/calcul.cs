using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothèqueDeClasse
{
    public class calcul
    {
        double InteretTotal, CoutTotal;
        double totalCapital, tauxInteret;
        int periode,nbMensualiteParAnnee;
        string frequence,nom, prenom;
        int nbPaiementTotal;
        double tauxPeriode, mensualite;
        List<Paiements> paiements;
        double Balance;



        public calcul() { }

        public calcul(double totalCapital, double tauxInteret, int periode, string frequence, string nom, string prenom)
        {
            TotalCapital = totalCapital;
            TauxInteret = tauxInteret;
            Periode = periode;
            Frequence = frequence;
            Nom = nom;
            Prenom = prenom;



            InteretTotal = (totalCapital * tauxInteret / 100);
            CoutTotal = InteretTotal + totalCapital;
            



            if (frequence == "Mensuel")
            {
                NbMensualiteParAnnee = 12;
            }
            if (frequence == "Bimensuel")
            {
                NbMensualiteParAnnee = 24;
            }
            if (frequence == "Bimestriel")
            {
                NbMensualiteParAnnee = 6;
            }

            NbPaiementTotal = ((periode / 12) * NbMensualiteParAnnee);
            TauxPeriode = ((tauxInteret / 100) / NbMensualiteParAnnee);

            Mensualite = (totalCapital * TauxPeriode) / (1 - Math.Pow((1 + TauxPeriode), -NbPaiementTotal));
            CreateListPaiements();
        }


        public List<Paiements> Paiements
        {
            get { return paiements; }
            set { paiements = value; }
        }
        public double Mensualite
        {
            get { return mensualite; }
            set { mensualite = value; }
        }
        public double TauxPeriode
        {
            get { return tauxPeriode; }
            set { tauxPeriode = value; }
        }
        public int NbPaiementTotal
        {
            get { return nbPaiementTotal; }
            set { nbPaiementTotal = value; }
        }
        public int NbMensualiteParAnnee
        {
            get { return nbMensualiteParAnnee; }
            set { nbMensualiteParAnnee = value; }
        }
        public double TotalCapital
        {
            get { return totalCapital; }
            set { totalCapital = value; }
        }
        public double TauxInteret
        {
            get { return tauxInteret; }
            set { tauxInteret = value; }
        }
        public int Periode
        {
            get { return periode; }
            set
            {
                periode = value;
            }
        }
        public string Frequence
        {
            get { return frequence; }
            set
            {
                frequence = value;
            }
        }
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
            }

        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }

        }

    private void CreateListPaiements()
    {
        Paiements = new List<Paiements>();
        Balance = TotalCapital;

        for (int i = 0; i < nbPaiementTotal; i++)
        {
            double PaiementInteret = Balance * tauxPeriode;
            double PaiementCapital = Mensualite - PaiementInteret;
            Balance = Balance - PaiementCapital;

            Paiements p = new Paiements(i + 1, Mensualite, PaiementCapital, PaiementInteret, Math.Abs(Balance));

            Paiements.Add(p);
        }
    }
}
}
