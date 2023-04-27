using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexColorMatch
{
    internal class HexColor
    {
        public HexColor(string hexCode, string value)
        {
            HexCode = hexCode;
            Name = value;
        }

        public string HexCode { get; }
        public string Name { get; }
    }
}
