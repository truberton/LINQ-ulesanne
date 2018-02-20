using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoÜlesanne
{
    class Program
    {
        static void Main(string[] args)
        {
            var autod = new List<Auto>
            {
                new Auto(){KW = 87, Tootja = "BMW", Mudel = "316i", Värv = "Must"},
                new Auto(){KW = 89, Tootja = "Honda", Mudel = "Civic '07", Värv = "Must"},
                new Auto(){KW = 87, Tootja = "Honda", Mudel = "Civic '17", Värv = "Punane"},
                new Auto(){KW = 107, Tootja = "Audi", Mudel = "A8", Värv = "Must"},
                new Auto(){KW = 97, Tootja = "Renault", Mudel = "Captur", Värv = "Valge"},
                new Auto(){KW = 94, Tootja = "Ford", Mudel = "Ranger '17", Värv = "Must"},
                new Auto(){KW = 112, Tootja = "Peugeot", Mudel = "2008 linnamaastur", Värv = "Hõbe"},
                new Auto(){KW = 92, Tootja = "Renault", Mudel = "Megane", Värv = "Hõbe"},
                new Auto(){KW = 92, Tootja = "Volkswagen", Mudel = "Golf", Värv = "Lilla"},
                new Auto(){KW = 85, Tootja = "Tesla", Mudel = "Model X", Värv = "Must"},
            };
            #region KW
            var KW = (from auto in autod
                      orderby auto.KW descending
                      select auto).ToList();
            Console.WriteLine("KW järjestus:");
            foreach (var auto in KW)
            {
                Console.WriteLine(auto.Tootja + " " + auto.Mudel + " " + auto.KW);
            }
            Console.WriteLine();
            #endregion

            #region o ja e

            var o = autod.Where(x => x.Tootja.ToLower().Contains("o")).ToList();
            var e = autod.Where(x => x.Tootja.ToLower().Contains("e")).ToList();

            Console.WriteLine("o on järgenvates autode tootjates:");
            foreach (var auto in o)
            {
                Console.WriteLine(auto.Tootja);
            }
            Console.WriteLine();

            Console.WriteLine("e on järgnevates autode tootjates");
            foreach (var auto in e)
            {
                Console.WriteLine(auto.Tootja);
            }
            Console.WriteLine();


            #endregion

            #region Mudel>4

            var Pikkus = (from auto in autod
                          where auto.Mudel.Length > 4
                          select auto).ToList();

            Console.WriteLine("Mudelid mille nimes on rohkem kui 4 tähte:");
            foreach (var mudel in Pikkus)
            {
                Console.WriteLine(mudel.Mudel);
            }
            Console.WriteLine();

            #endregion

            #region Võimsaim ja nõrgeim

            var Võimsaim = autod.Max(x => x.KW);
            var VõimsaimKoosMudeliga = (from auto in autod
                                        where auto.KW == Võimsaim
                                        select auto).ToList();

            foreach (var auto in VõimsaimKoosMudeliga)
            {
                Console.WriteLine(auto.Mudel + " KW: " + auto.KW);
            }

            Console.WriteLine("Võimsaim: " + Võimsaim);

            var Nõrgeim = autod.Min(x => x.KW);
            var NõrgeimKoosMudeliga = (from auto in autod
                                       where auto.KW == Nõrgeim
                                       select auto).ToList();

            foreach (var auto in NõrgeimKoosMudeliga)
            {
                Console.WriteLine(auto.Mudel + " KW: " + auto.KW);
            }
            Console.WriteLine("Nõrgeim: " + Nõrgeim);

            #endregion
            Console.ReadLine();
        }
    }
}
