using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcheAlerta.Models;
using TcheAlerta.ViewModels.Alertas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcheAlerta.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardViewTemplate : ContentView
    {
		public CardViewTemplate ()
		{          
            InitializeComponent ();
		}             
    }
}