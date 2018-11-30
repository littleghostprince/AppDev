using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class Peg
    {
        public enum Colors
        {
            Grey,
            Black,
            White,
            Yellow,
            Red,
            Green,
            Blue,
            Num_Colors                
        }

        public static Colors CORRECT_COLOR = Colors.White;
        public static Colors CORRECT_COLOR_POSITION = Colors.Black;

        private Colors color = Colors.Grey;
        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }

        public void SetNextColor()
        {
            Color = Color + 1;
            if(Color > Colors.Blue)
            {
                Color = Colors.Black;
            }
        }

    }
}
