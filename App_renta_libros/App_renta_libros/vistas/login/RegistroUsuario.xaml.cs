using Firebase.Auth;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using System.Text.RegularExpressions;

namespace App_renta_libros.vistas.login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroUsuario : ContentPage
    {
        public string webApiKey = "AIzaSyBoNvnnjA_nYdAO9792DUD3ekrShAA3v6M";
        public RegistroUsuario()
        {
            InitializeComponent();
        }
        private async void register_user(object sender, EventArgs e)
        {
            Boolean pass1 = true, pass2 = true;
            if (String.IsNullOrWhiteSpace(email_register.Text) | String.IsNullOrWhiteSpace(password_register.Text) | String.IsNullOrWhiteSpace(password_repeat_register.Text))
            {
                await this.DisplayToastAsync("Los campos no deben de estar vacíos", 2000);
            }
            else
            {
                if (!CheckEmail(email_register.Text))
                {
                    await this.DisplayToastAsync("El correo no tiene un formato adecuado", 2000);
                    pass1 = false;
                }
                if (password_register.Text.Length > 6)
                {
                    if (!password_register.Text.Equals(password_repeat_register.Text))
                    {
                        pass2 = false;
                        await this.DisplayToastAsync("Las contraseñas no coinciden", 2000);
                    }
                }
                else {
                    pass2 = false;
                    await this.DisplayToastAsync("Las contraseña debe ser mayor a 6 caracteres ", 2000);
                }
                if (pass1&&pass2) {
                    try
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                        await authProvider.CreateUserWithEmailAndPasswordAsync(email_register.Text, password_register.Text);
                        await this.DisplayToastAsync("El usuario ha sido registrado", 1000);
                        await Navigation.PushAsync(new LoginApp());
                    }
                    catch (Exception ex)
                    {
                        await this.DisplayToastAsync("Error al registrar el usuario", 2000);
                    }
                }
            }
        }
        public Boolean CheckEmail(string email)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (string.IsNullOrWhiteSpace(email)) return false;
            return EmailRegex.IsMatch(email);
        }
        async private void regresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginApp());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}