using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_renta_libros.vistas.login;

namespace App_renta_libros.vistas.menu.secciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiData : ContentPage
    {
        public MiData()
        {
            InitializeComponent();
            user.Text = Preferences.Get("User", string.Empty);
        }
        async private void close(object sender, EventArgs e)
        {
            Preferences.Set("User", String.Empty);
            await Navigation.PushAsync(new LoginApp());
        }
    }
}