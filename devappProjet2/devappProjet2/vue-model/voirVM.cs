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


        public voirVM() 
        {
            
        }

        public calcul Calcul
        {
            get { return _calcul; }
            set
            {
                _calcul = value;
            }
            
        }
       
        
    }
}
