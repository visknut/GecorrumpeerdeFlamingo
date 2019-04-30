using System;
using System.Collections.Generic;
using System.Text;

namespace GecorrumpeerdeFlamingo.Entities
{
    public class Input : Component
    {
        public List<string> Symbols { get; set; }
        public List<string> ActiveSymbols { get; set; }

        public Input(List<string> symbols)
        {
            if (symbols.Count != 4)
            {
                throw new ArgumentException();
            }
            Symbols = symbols;
            ActiveSymbols = new List<string>(symbols);
            ;
        }

        public override string ToString()
        {
            var description = "";
            if (Active)
            {
                description += "\nEen input component met vier knoppen. Op de knoppen staan de volgende symbolen in Unicode:\n";
            }
            else
            {
                description += "\nEen uitgeschakelde input component met vier knoppen. Op de knoppen staan de volgende symbolen in Unicode:\n";
            }


            foreach (var symbol in Symbols)
            {
                if (ActiveSymbols.Contains(symbol))
                {
                    description += $"    + {symbol} (aan)\n";
                }
                else
                {
                    description += $"    + {symbol} (uit)\n";
                }
                
            }

            return description;
        }
    }
}
