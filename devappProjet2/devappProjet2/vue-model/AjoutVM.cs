using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using devappProjet2.model;
using devappProjet2.vue;

namespace devappProjet2.vue_model
{
    internal class AjoutVM : INotifyPropertyChanged
    {
        private float _totalCapital, _tauxInteret;
        private int _periode;
        private string? _frequence, _nom, _prenom;

        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;


        //Fonction qui gère le lancement de l'événément PropertyChanged
        protected virtual void ValeurChangee(string nomPropriete)
        {
            //Vérifie si il y a au moins 1 abonné
            if (this.PropertyChanged != null)
            {
                //Lance l'événement -> tous les abonnés seront notifiés
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }
        #endregion


        public AjoutVM() 
        {
            Enregistrer = new CommandeRelais(Enregistrer_Execute, Enregistrer_CanExecute);

        }
        

        public float TotalCapital
        {
            get { return _totalCapital; }
            set
            {
                _totalCapital = value;
                ValeurChangee("TotalCapital");
            }
        }

        public float TauxInteret
        {
            get { return _tauxInteret; }
            set
            {
                _tauxInteret = value;
                ValeurChangee("TauxInteret");
            }
        }

        public int Periode
        {
            get { return _periode; }
            set
            {
                _periode = value;
                ValeurChangee("Periode");
            }
        }

        public string? Frequence
        {
            get { return _frequence; }
            set
            {
                _frequence = value;
                ValeurChangee("Frequence");
            }
        }

        public string? Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                ValeurChangee("Nom");
            }
        }

        public string? Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                ValeurChangee("Prenom");
            }
        }

        private ICommand _enregistrer;
        public ICommand Enregistrer
        {
            get { return _enregistrer; }
            set
            {
                _enregistrer = value;
            }
        }
        
        public void Enregistrer_Execute(object parameter)   
        {
            calcul c = new calcul(TotalCapital, TauxInteret, Periode, Frequence, Nom, Prenom);
            Serializer.EnregistrerNouveauCalcul(c);
        }
        public bool Enregistrer_CanExecute(object parameter)
        {
            return true;
        }
    }
}
