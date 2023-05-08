using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothèqueDeClasse
{
    public class Paiements
    {
        int _mois;
        double _paiement, _capital, _interet, _balance;

        public Paiements() { }

        public Paiements(int mois, double paiement, double capital, double interet, double balance)
        {
            Mois = mois;
            Paiement = paiement;
            Capital = capital;
            Interet = interet;
            Balance = balance;
        }

        public int Mois
        {
            get { return _mois; }
            set { _mois = value; }
        }
        public double Paiement
        {
            get { return _paiement; }
            set { _paiement = value; }
        }
        public double Capital
        {
            get { return _capital; }
            set { _capital = value; }
        }
        public double Interet
        {
            get { return _interet; }
                        set
            {
                _interet = value;
            }
        }
        public double Balance
        {
            get { return _balance; }
                        set
            {
                _balance = value;
            }
        }
    }
}
