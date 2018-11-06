using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBox.Models
{
    class Pokeman
    {
        public enum eType
        {
            FIRE,
            WATER
        }
        public string name { get; set; }
        public eType type { get; set; }
        public int index { get; set; }
    }
}
