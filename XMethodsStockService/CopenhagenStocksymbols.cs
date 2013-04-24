using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YahooFinance
{
    public class CopenhagenStocksymbols
    {
        public static IEnumerable<string> SymbolsFromFile()
        {
            return File.ReadAllLines("symbols.txt").Where(x => !x.Contains("//") && !x.Equals(""));
        }
    }
}