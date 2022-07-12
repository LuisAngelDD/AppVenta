using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using App_renta_libros.vistas.login;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Firebase.Auth;
using Newtonsoft.Json;
using App_renta_libros.vistas.menu;

namespace App_renta_libros.vistas.login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginApp : ContentPage
    {
        public string webApiKey = "AIzaSyBoNvnnjA_nYdAO9792DUD3ekrShAA3v6M";
        public LoginApp()
        {
            InitializeComponent();
            CheckData();
        }
        async private void CheckData()
        {
            if (!Preferences.Get("User", String.Empty).Equals(""))
            {
                await Navigation.PushAsync(new MenuApp());
            }
        }
        async private void login(object sender, EventArgs e)
        {
            Boolean pass1 = true, pass2 = true;
                if (String.IsNullOrWhiteSpace(email_login.Text)) {
                    pass1 = false;
                    await this.DisplayToastAsync("El campo correo no debe estar vacio", 2000);
                }
                if (String.IsNullOrWhiteSpace(password_login.Text)) {
                    await this.DisplayToastAsync("Ingrese la contraseña de su cuenta", 2000);
                    pass2 = false;
                }
                if (pass1&&pass2) {
                    try
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                        var auth = await authProvider.SignInWithEmailAndPasswordAsync(email_login.Text, password_login.Text);
                        var user = auth.User.LocalId;
                        var content = await auth.GetFreshAuthAsync();
                        var serializedContent = JsonConvert.SerializeObject(content);
                        Preferences.Set("MyFirebaseRefreshtoken", serializedContent);
                        Preferences.Set("User", email_login.Text);
                        await Navigation.PushAsync(new MenuApp());
                    }
                    catch (Exception)
                    {
                        await this.DisplayToastAsync("Ocurrió un error al iniciar sesion", 2000);
                        await this.DisplayToastAsync("Verifique que su correo y contraseña sean los correctos", 2000);
                    }
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}