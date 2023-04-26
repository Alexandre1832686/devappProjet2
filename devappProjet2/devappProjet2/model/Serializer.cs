using devappProjet2.vue_model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace devappProjet2.model
{
    internal class Serializer
    {
        #region private functions

        private static void writeCalcul()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<calcul>));
                var path = System.IO.Directory.GetCurrentDirectory() + "//Serialization.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                writer.Serialize(file, ListeCalculs.listeCalculs);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            readCalcul();
        }

        private static void readCalcul()
        {
            ObservableCollection<calcul> retour = new ObservableCollection<calcul>();
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<calcul>));
                    
                using (Stream reader = new FileStream("Serialization.xml", FileMode.Open))
                {
                    retour = (ObservableCollection<calcul>)writer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (InvalidOperationException e)
            {
                var path = System.IO.Directory.GetCurrentDirectory() + "//Serialization.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                var path = System.IO.Directory.GetCurrentDirectory() + "//Serialization.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                file.Close();
            }

            if (retour != null)
                ListeCalculs.listeCalculs = retour;
            else
                ListeCalculs.listeCalculs = new ObservableCollection<calcul>();
        }

        #endregion
        #region public functions
        public static bool EnregistrerNouveauCalcul(calcul c)
        {
            if (c == null)
                return false;
            else
            {
                ListeCalculs.listeCalculs.Add(c);
                writeCalcul();
                return true;
            }
        }

        
        public static void GetToutLesCalculs()
        {
           readCalcul();
        }
        #endregion
        public static bool Supprimer(calcul c)
        {
            bool verif = false;
            if (c == null) return false;

            foreach(calcul cal in ListeCalculs.listeCalculs)
            {
                if(IsEqualsTo(c,cal))
                {
                    ListeCalculs.listeCalculs.Remove(cal);
                    verif = true;
                    break;
                }
            }

            writeCalcul();
            return verif;
        }
        

        private static bool IsEqualsTo(calcul c1, calcul c2)
        {
            bool verif = true;
            if(c1.TauxInteret != c2.TauxInteret) verif = false;
            if (c1.Periode != c2.Periode) verif = false;
            if (c1.Prenom != c2.Prenom) verif = false;
            if (c1.Nom != c2.Nom) verif = false;
            if (c1.TotalCapital != c2.TotalCapital) verif = false;
            if (c1.Frequence != c2.Frequence) verif = false;
            return verif;
        }
    }
}
