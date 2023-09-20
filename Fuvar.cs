using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._20.Doga
{
    internal class Fuvar
    {
        int taxiAzonosító;
        DateTime indulas;
        int utazasiIdo;
        double megtettTavolsag;
        double viteldij;
        double borravalo;
        string fizetesModja;

        public Fuvar(int taxiAzonosító, DateTime indulas, int utazasiIdo, double megtettTavolsag, double viteldij, double borravalo, string fizetesModja)
        {
            this.taxiAzonosító = taxiAzonosító;
            this.indulas = indulas;
            this.utazasiIdo = utazasiIdo;
            this.megtettTavolsag = megtettTavolsag;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetesModja = fizetesModja;
        }

        public int TaxiAzonosító { get => taxiAzonosító;}
        public DateTime Indulas { get => indulas;}
        public int UtazasiIdo { get => utazasiIdo;}
        public double MegtettTavolsag { get => megtettTavolsag;}
        public double Viteldij { get => viteldij;}
        public double Borravalo { get => borravalo;}
        public string FizetesModja { get => fizetesModja;}
    }
}
