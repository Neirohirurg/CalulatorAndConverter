using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Information : IValue
    {
        private string _name = "Информация";
        public string GetName() { return _name; }

        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            {"Бит",                                 1},
            {"Байт",                                8},
            {"КилоБайт",                     1024 * 8},
            {"Мегабайт",        Math.Pow(1024, 2) * 8},
            {"ГигаБайт",        Math.Pow(1024, 3) * 8},
            {"ТераБайт",        Math.Pow(1024, 4) * 8},
            {"ПетаБайт",        Math.Pow(1024, 5) * 8},
            {"ЭкзоБайт",        Math.Pow(1024, 6) * 8},
            {"ЗеттаБайт",       Math.Pow(1024, 7) * 8},
            {"ЙоттаБайт",       Math.Pow(1024, 8) * 8},
        };

        public Dictionary<string, double> GetCoefDict() {  return _coefList; }
    }
}
