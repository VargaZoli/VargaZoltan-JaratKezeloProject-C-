﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private class Jarat
        {
            public string JaratSzam { get; }
            public string RepterHonnan { get; }
            public string RepterHova { get; }
            public DateTime Indulas { get; }
            public int Keses { get; set; }

            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                JaratSzam = jaratSzam;
                RepterHonnan = repterHonnan;
                RepterHova = repterHova;
                Indulas = indulas;
                Keses = 0;
            }
        }

        private readonly Dictionary<string, Jarat> jaratok = new Dictionary<string, Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Már létezik ilyen járatszám.");
            }
             
            jaratok[jaratSzam] = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
        }

        public void Keses(string jaratSzam, int keses)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            var jarat = jaratok[jaratSzam];
            jarat.Keses += keses;

            if (jarat.Keses < 0)
            {
                throw new ArgumentException("A késés nem lehet negatív.");
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            var jarat = jaratok[jaratSzam];
            return jarat.Indulas.AddMinutes(jarat.Keses);
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            var result = new List<string>();

            foreach (var jarat in jaratok.Values)
            {
                if (jarat.RepterHonnan == repter)
                {
                    result.Add(jarat.JaratSzam);
                }
            }

            return result;
        }
    }
}

