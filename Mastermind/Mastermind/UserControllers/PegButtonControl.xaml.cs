﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mastermind.Models;

namespace Mastermind.UserControls
{
    /// <summary>
    /// Interaction logic for PegButtonControl.xaml
    /// </summary>
    public partial class PegButtonControl : UserControl
    {
		public Mastermind.Models.Peg Peg { get; set; }

        public PegButtonControl(Mastermind.Models.Peg peg)
        {
			Peg = peg;

            InitializeComponent();
			DataContext = this;
        }

		private void PegButton_Click(object sender, RoutedEventArgs e)
		{
			Peg.SetNextColor();
		}
	}
}
