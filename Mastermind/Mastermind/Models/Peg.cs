﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class Peg : INotifyPropertyChanged, ICloneable
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
        public static Colors NULL_COLOR = Colors.Grey;

        private Colors color = Colors.Grey;

        public event PropertyChangedEventHandler PropertyChanged;

        public Colors Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }

        }

        public void SetNextColor()
        {
            Color = Color + 1;
            if(Color > Colors.Blue)
            {
                Color = Colors.Black;
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new Peg
            {
                Color = this.Color,
            };
        }
    }
}
