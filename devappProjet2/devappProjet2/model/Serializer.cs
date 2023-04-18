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
        private static List<calcul> lesCalculs = new List<calcul>();


        #region private functions

        private static void writeCalcul(calcul c)
        {
            lesCalculs.Add(c);
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<calcul>));
                var path = System.IO.Directory.GetCurrentDirectory() + "//Serialization.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                writer.Serialize(file, lesCalculs);
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<calcul> readCalcul()
        {
        List<calcul> retour = new List<calcul>();
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<calcul>));
                    
                using (Stream reader = new FileStream("SerializationMembreDepense.xml", FileMode.Open))
                {
                    retour = (List<calcul>)writer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (InvalidOperationException e)
            {
                var path = System.IO.Directory.GetCurrentDirectory() + "//SerializationMembreDepense.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                file.Close();
                return null;
            }
            catch (FileNotFoundException e)
            {
                var path = System.IO.Directory.GetCurrentDirectory() + "//SerializationMembreDepense.xml";
                System.IO.FileStream file = System.IO.File.Create(path);
                file.Close();
                return null;
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

        
        public static List<calcul> GetToutLesCalculs()
        {
            if (lesCalculs.Count == 0)
                lesCalculs = readCalcul();

            return lesCalculs;
        }
        #endregion

    }
}
