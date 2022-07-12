using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_renta_libros.vistas.menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuApp : TabbedPage
    {
        public MenuApp()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}