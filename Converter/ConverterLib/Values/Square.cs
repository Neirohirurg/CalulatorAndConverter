using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Square : IValue
    {
        private string _name = "Площадь";
        public string GetName() { return _name; }

        private Dictionary<string, double> _coefList = new Dictionary<string, double>()
        {
            {"кв.см",                                1},
            {"кв.дюймы",                          6.45},
            {"кв.футы",                         929.03},
            {"кв.м",                             10000},
            {"Сотки",                          1000000},
            {"Акры",                          40468600},
            {"Гектары",                      100000000},
            {"кв.км",                      10000000000},
            {"кв.мили",                 25899881103.36},

        };

        public Dictionary<string, double> GetCoefDict() { return _coefList; }
    }
}
