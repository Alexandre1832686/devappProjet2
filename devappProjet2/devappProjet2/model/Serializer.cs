using devappProjet2.vue_model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devappProjet2.model
{
    internal class Serializer
    {
        #region private functions

        private static void writeCalcul(calcul c)
        {
            ListeCalculs.listeCalculs.Add(c);
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<calcul>));
                var path = System.IO.Directory.GetCurrentDirectory() + "//Serialization.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                writer.Serialize(file, ListeCalculs.listeCalculs);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static ObservableCollection<calcul> readCalcul()
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

            return retour;
        }

        #endregion
        #region public functions
        public static bool EnregistrerNouveauCalcul(calcul c)
        {
            if (c == null)
                return false;
            else
            {
                writeCalcul(c);
                return true;
            }
        }

        
        public static ListeCalculs GetToutLesCalculs(ListeCalculs liste)
        {
            if(liste == null)
            {
                liste = new ListeCalculs();
            }

            liste = readCalcul();

            return liste;
        }
        #endregion

        
    }
}
