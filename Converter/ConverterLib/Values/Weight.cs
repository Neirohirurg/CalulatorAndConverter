using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Weight : IValue
    {
        private string _name = "Масса";
        public string GetName() { return _name; }

        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            {"Милиграммы",                       0.001},
            {"Караты",                             0.2},
            {"Граммы",                               1},
            {"Унции",                            28.35},
            {"Килограммы",                        1000},
            {"Пуды",                             16380},
            {"Центнеры",                        100000},
            {"Тонны",                          1000000},
        };

        public Dictionary<string, double> GetCoefDict() { return _coefList; }
    }
}
