using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devappProjet2.model;
using devappProjet2.vue;
using BibliothèqueDeClasse;

namespace devappProjet2.vue_model
{
    internal class voirVM
    {
        calcul _calcul;
        double _mensualite, _coutTotal,_interetTotal;


        public voirVM() 
        {
            
        }

        public calcul Calcul
        {
            get { return _calcul; }
            set
            {
                _calcul = value;
                Mensualite = value.Mensualite;
                CoutTotal = value.TotalCapital + value.InteretTotal;
                InteretTotal = value.InteretTotal;
            }
            
        }
        
        public double Mensualite
        {
            get { return _mensualite; }
            set { _mensualite = value; }
        }
        public double CoutTotal
        {
            get { return _coutTotal; }
            set { _coutTotal = value; }
        }
        public double InteretTotal
        {
            get { return _interetTotal; }
            set { _interetTotal = value; }
        }

    }
}
