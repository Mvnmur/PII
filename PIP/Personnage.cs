using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP
{
    public class Personnage
    {
        public string Nom { get; set; }
        public string Profil { get; set; }
        public string Niveau { get; set; }
        public string Race { get; set; }
        public string Portrait { get; set; }
        public string Absolute { get; set; }
        public string PDV { get; set; }
        public List<string> Capacite { get; set; }
    }
}
