using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _09._20.Doga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBeolvasas_Click(object sender, RoutedEventArgs e)
        {
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(fajl.FileName); 
                sr.ReadLine();
                while (!sr.EndOfStream)
                { 
                string sor = sr.ReadLine();

                string[] mezok = sor.Split(";");
                    Fuvar kifejezesek = new Fuvar(Convert.ToInt32(mezok[0]), Convert.ToDateTime(mezok[1]), Convert.ToInt32(mezok[2]), Convert.ToDouble(mezok[3]), Convert.ToDouble(mezok[4]), Convert.ToDouble(mezok[5]), mezok[6]);
                    fuvarok.Add(kifejezesek);
                
                
                
                }
                
                
                sr.Close();
            }
            
        }

        private void btnHarmas_Click(object sender, RoutedEventArgs e)
        {
            lblHarmas.Content = $"3. feladat : {fuvarok.Count()} fuvar";
        }

        private void btnNegyes_Click(object sender, RoutedEventArgs e)
        {
            lblNegyes.Content = $"4. feladat : {fuvarok.Where(x => x.TaxiAzonosító == 6185).Count()} fuvar alatt: {fuvarok.Where(x => x.TaxiAzonosító == 6185).Sum(x => x.Viteldij + x.Borravalo)}$";
        }

        private void btnOtos_Click(object sender, RoutedEventArgs e)
        {
            int bankKartya = fuvarok.Count(x => x.FizetesModja == "bankkártya");
            int keszpenz = fuvarok.Count(x => x.FizetesModja == "készpénz");
            int ingyenes = fuvarok.Count(x => x.FizetesModja == "ingyenes");
            int vitatott = fuvarok.Count(x => x.FizetesModja == "vitatott");
            int ismeretlen = fuvarok.Count(x => x.FizetesModja == "ismeretlen");

            lbOtos.Items.Add($"5. feladat\n \tbankkártya: {bankKartya} fuvar\n \tkészpénz: {keszpenz} fuvar\n \tvitatott: {vitatott} fuvar\n \tingyenes: {ingyenes} fuvar\n \tismeretlen: {ismeretlen} fuvar\t");
        }

        private void btnHatos_Click(object sender, RoutedEventArgs e)
        {
            lblHatos.Content = $"6. feladat: {Math.Round(fuvarok.Sum(x => x.MegtettTavolsag * 1.6),2)}km";
        }

        private void btnNyolcas_Click(object sender, RoutedEventArgs e)
        {
            lblNyolcas.Content = "8. feladat : hibak.txt";
            using (StreamWriter sw = new StreamWriter("hibak.txt"))
            {
                sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                fuvarok.Where(x => x.UtazasiIdo > 0 && x.Viteldij > 0 && x.MegtettTavolsag == 0).OrderBy(x => x.Indulas).ToList().ForEach
                    (x => sw.WriteLine($"{x.TaxiAzonosító};{x.Indulas};{x.UtazasiIdo};{x.MegtettTavolsag};{x.Viteldij};{x.Borravalo};{x.FizetesModja}"));
            }

        }
    }
}
