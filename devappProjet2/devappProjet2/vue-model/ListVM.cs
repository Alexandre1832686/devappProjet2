using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devappProjet2.model;

namespace devappProjet2.vue_model
{
    public class ListVM
    {
        static ObservableCollection<calcul> _liste = new ObservableCollection<calcul>();
        public ListVM() 
        {
            PeuplerLaListe();
        }

        public static ObservableCollection<calcul> Liste 
        { 
            get { return _liste; }
            set { _liste = value; }
        }

        public static void PeuplerLaListe()
        {
            Liste = Serializer.GetToutLesCalculs();
        }
    }
}
