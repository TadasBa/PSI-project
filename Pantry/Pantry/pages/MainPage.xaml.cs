using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pantry.models;
using System.IO;

namespace Pantry
{
    public partial class MainPage : TabbedPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        
    }
}
