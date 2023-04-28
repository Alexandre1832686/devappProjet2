﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devappProjet2.model
{
    public class calcul
    {
        double totalCapital, tauxInteret;
        int periode;
        string? frequence,nom, prenom;
        

        public calcul() { }

        public calcul(double totalCapital, double tauxInteret, int periode, string? frequence, string? nom, string? prenom)
        {
            TotalCapital = totalCapital;
            TauxInteret = tauxInteret;
            Periode = periode;
            Frequence = frequence;
            Nom = nom;
            Prenom = prenom;
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
        public string? Frequence
        {
            get { return frequence; }
            set
            {
                frequence = value;
            }
        }
        public string? Nom
        {
            get { return nom; }
            set
            {
                nom = value;
            }

        }
        public string? Prenom
        {
            get { return prenom; }
            set { prenom = value; }

        }
    }
}
