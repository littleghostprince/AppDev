using System;
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
	/// Interaction logic for PegControl.xaml
	/// </summary>
	public partial class PegControl : UserControl
	{
		public Mastermind.Models.Peg Peg { get; set; }

		public PegControl(Mastermind.Models.Peg peg)
		{
			Peg = peg;

			InitializeComponent();
			DataContext = this;
		}
	}
}
