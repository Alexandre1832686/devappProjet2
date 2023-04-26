using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using devappProjet2.model;
using devappProjet2.vue;

namespace devappProjet2.vue_model
{
    public class ListVM : INotifyPropertyChanged
    {
        private  ObservableCollection<calcul> _liste;
        private calcul calcul;

        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;


        //Fonction qui gère le lancement de l'événément PropertyChanged
        protected virtual void ValeurChange(string nomPropriete)
        {
            //Vérifie si il y a au moins 1 abonné
            if (this.PropertyChanged != null)
            {
                //Lance l'événement -> tous les abonnés seront notifiés
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        #endregion
        public ListVM() 
        {
            Serializer.GetToutLesCalculs();
            Liste = ListeCalculs.listeCalculs;
            VoirPlus = new CommandeRelais(VoirPlus_Execute, VoirPlus_CanExecute);
            Supprimer = new CommandeRelais(Supprimer_Execute, Supprimer_CanExecute);
        }

        public  ObservableCollection<calcul> Liste 
        { 
            get { return _liste; }
            set 
            { 
                _liste = value;
                ValeurChange("Liste");
            }
        }


        private ICommand _voirPlus;
        public ICommand VoirPlus
        {
            get { return _voirPlus; }
            set
            {
                _voirPlus = value;
            }
        }

        public void VoirPlus_Execute(object parameter)
        {
            voir voir = new voir(Calcul);
            voir.Show();
        }
        public bool VoirPlus_CanExecute(object parameter)
        {
            if (Calcul != null)
                return true;

            return false;
        }

        private ICommand _supprimer;
        public ICommand Supprimer
        {
            get { return _supprimer; }
            set
            {
                _supprimer = value;
            }
        }

        public void Supprimer_Execute(object parameter)
        {
            bool verif = Serializer.Supprimer(Calcul);
            string stringMessage;
            if (verif)
            {
                stringMessage = "Supprimé avec succès";
            }
            else
            {
                stringMessage = "Problème avec la suppression...";

            }
            Message m = new Message(stringMessage);
            m.Show();
        }
        public bool Supprimer_CanExecute(object parameter)
        {
            if(Calcul!= null)
                return true;
            
            return false;
        }


        public calcul Calcul
        {
            get { return calcul; }
            set
            {
                calcul = value;
                ValeurChange("Calcul");
            }
        }
    }
}
